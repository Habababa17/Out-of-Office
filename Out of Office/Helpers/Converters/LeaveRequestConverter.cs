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
    public static class LeaveRequestConverter
    {
        public static LeaveRequestDto ToDto(LeaveRequestModel model)
        {
            return new LeaveRequestDto
            {
                ID = model.ID,
                Employee = model.Employee,
                AbsenceReason = (AbsenceReasonEnum)model.AbsenceReason,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Comment = model.Comment,
                Status = (SubmitStateEnum)model.Status
            };
        }

        public static LeaveRequestModel ToModel(LeaveRequestDto dto)
        {
            return new LeaveRequestModel
            {
                ID = dto.ID,
                Employee = dto.Employee,
                AbsenceReason = (int)dto.AbsenceReason,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Comment = dto.Comment,
                Status = (int)dto.Status
            };
        }
    }
}
