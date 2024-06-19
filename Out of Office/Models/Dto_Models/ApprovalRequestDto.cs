using Out_of_Office.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models.Dto_Models
{
    public class ApprovalRequestDto
    {
        public Guid? ID { get; set; }
        public Guid? Approver { get; set; }
        public Guid LeaveRequest { get; set; }
        public SubmitStateEnum Status { get; set; }
        public string? Comment { get; set; }
    }
}
