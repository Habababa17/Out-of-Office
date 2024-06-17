using Out_of_Office.Models.DB_Models;
using Out_of_Office.Models.Dto_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Helpers.Converters
{
    public static class ApprovalRequestConverter
    {
        public static ApprovalRequestDto ToDto(ApprovalRequestModel model)
        {
            return new ApprovalRequestDto
            {
                ID = model.ID,
                Approver = model.Approver,
                LeaveRequest = model.LeaveRequest,
                Status = model.Status,
                Comment = model.Comment
            };
        }

        public static ApprovalRequestModel ToModel(ApprovalRequestDto dto)
        {
            return new ApprovalRequestModel
            {
                ID = dto.ID,
                Approver = dto.Approver,
                LeaveRequest = dto.LeaveRequest,
                Status = dto.Status,
                Comment = dto.Comment
            };
        }
    }
}
