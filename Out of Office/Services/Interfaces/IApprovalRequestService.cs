using Out_of_Office.Helpers.Converters;
using Out_of_Office.Models.Dto_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Services.Interfaces
{
    public interface IApprovalRequestService
    {
        public Task<ApprovalRequestListDto> GetApprovalRequestsAsync(ApprovalRequestFiltersDto? filtersDto = null);
        public Task AddApprovalRequestAsync(ApprovalRequestDto approvalRequest);
    }
}
