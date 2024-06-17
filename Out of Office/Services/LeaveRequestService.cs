using Out_of_Office.Data.IRepositories;
using Out_of_Office.Data.Repositories;
using Out_of_Office.Helpers.Converters;
using Out_of_Office.Models.Dto_Models;
using Out_of_Office.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await _leaveRequestRepository.AddAsync(lr);
        }

        public async Task<LeaveRequestListDto> GetLeaveRequestsAsync(LeaveRequestFiltersDto? filtersDto = null)
        {
            var leaveRequestsList = await _leaveRequestRepository.GetAllAsync();
            LeaveRequestListDto leaveRequestsListDto = new LeaveRequestListDto();
            foreach (var lr in leaveRequestsList)
                leaveRequestsListDto.LeaveRequests.Add(LeaveRequestConverter.ToDto(lr));
            return leaveRequestsListDto;
        }

        public async Task UpdateLeaveRequestAsync(LeaveRequestDto leaveRequestDto)
        {
            var lr = Helpers.Converters.LeaveRequestConverter.ToModel(leaveRequestDto);
            await _leaveRequestRepository.UpdateAsync(lr);
        }
    }
}
