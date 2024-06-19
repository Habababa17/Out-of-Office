using Out_of_Office.Models.Dto_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Services.Interfaces
{
    public interface ILeaveRequestService
    {
        public Task AddLeaveRequestAsync(LeaveRequestDto leaveRequestDto);
        public Task UpdateLeaveRequestAsync(Guid leaveRequestID, LeaveRequestDto leaveRequestDto);
        public Task<LeaveRequestListDto> GetLeaveRequestsAsync(LeaveRequestFiltersDto? filtersDto = null);
        public Task<LeaveRequestDto> GetLeaveRequestAsync(Guid leaveRequestId);
    }
}
