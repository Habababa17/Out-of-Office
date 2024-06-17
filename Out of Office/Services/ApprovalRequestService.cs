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
    public class ApprovalRequestService : IApprovalRequestService
    {
        private IApprovalRequestRepository _approvalRequestRepository;
        public ApprovalRequestService(IApprovalRequestRepository approvalRequestRepository)
        {
            _approvalRequestRepository = approvalRequestRepository;
        }

        public async Task<ApprovalRequestListDto> GetApprovalRequestsAsync(ApprovalRequestFiltersDto? filtersDto = null)
        {
            var approvalRequestsList = await _approvalRequestRepository.GetAllAsync();
            ApprovalRequestListDto approvalRequestsListDto = new ApprovalRequestListDto();
            foreach (var ar in approvalRequestsList)
            {
                approvalRequestsListDto.ApprovalRequests.Add(ApprovalRequestConverter.ToDto(ar));
            }
            return approvalRequestsListDto;
        }
    }
}
