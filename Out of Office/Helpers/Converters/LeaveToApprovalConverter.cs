using Out_of_Office.Models.DB_Models;
using Out_of_Office.Models.Dto_Models;
using Out_of_Office.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Helpers.Converters
{
    public static class LeaveToApprovalConverter
    {
        public static ApprovalRequestDto ToDto(LeaveRequestModel model)
        {
            return new ApprovalRequestDto
            {
                ID = null,
                Approver = null,
                LeaveRequest = model.ID,
                Status = (SubmitStateEnum)model.Status,
                Comment = null
            };
        }
    }
}
