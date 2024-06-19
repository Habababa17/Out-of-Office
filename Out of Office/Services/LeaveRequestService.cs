using Out_of_Office.Data.IRepositories;
using Out_of_Office.Data.Repositories;
using Out_of_Office.Helpers;
using Out_of_Office.Helpers.Converters;
using Out_of_Office.Models.Dto_Models;
using Out_of_Office.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Out_of_Office.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private ILeaveRequestRepository _leaveRequestRepository;
        
        public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task AddLeaveRequestAsync(LeaveRequestDto leaveRequestDto)
        {
            var lr = Helpers.Converters.LeaveRequestConverter.ToModel(leaveRequestDto);
            BalanceHelper.CheckBalance(leaveRequestDto.StartDate, leaveRequestDto.EndDate);
            await _leaveRequestRepository.AddAsync(lr);
        }

        public async Task<LeaveRequestDto> GetLeaveRequestAsync(Guid leaveRequestId)
        {
            var leaveRequestModel = await _leaveRequestRepository.GetAsync(leaveRequestId);
            if (leaveRequestModel == null) 
            {
            throw new ArgumentNullException(nameof(leaveRequestModel));
            }
            return Helpers.Converters.LeaveRequestConverter.ToDto(leaveRequestModel);

        }

        public async Task<LeaveRequestListDto> GetLeaveRequestsAsync(LeaveRequestFiltersDto? filtersDto = null)
        {
            var leaveRequestsList = await _leaveRequestRepository.GetUserLeaveRequestsAsync();
            LeaveRequestListDto leaveRequestsListDto = new LeaveRequestListDto();
            foreach (var lr in leaveRequestsList)
                leaveRequestsListDto.LeaveRequests.Add(LeaveRequestConverter.ToDto(lr));

            return leaveRequestsListDto;
        }

        public async Task UpdateLeaveRequestAsync(Guid leaveRequestID, LeaveRequestDto leaveRequestDto)
        {
            var leaveRequest = await _leaveRequestRepository.GetAsync(leaveRequestID);
            if (leaveRequest == null)
            {
                throw( new ArgumentNullException(nameof(leaveRequest)));
            }
            if (leaveRequest.Employee != AuthorizationHelper.loggedInUser.ID)
            {
                throw (new UnauthorizedAccessException());
            }
            leaveRequest.Status = (int)leaveRequestDto.Status;
            leaveRequest.StartDate = leaveRequestDto.StartDate;
            leaveRequest.EndDate = leaveRequestDto.EndDate;
            leaveRequest.AbsenceReason = (int)leaveRequestDto.AbsenceReason;
            leaveRequest.Comment = leaveRequestDto.Comment;

            BalanceHelper.CheckBalance(leaveRequestDto.StartDate, leaveRequestDto.EndDate);

            await _leaveRequestRepository.UpdateAsync(leaveRequest);
        }




    }
}
