using Out_of_Office.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models.Dto_Models
{
    public class LeaveRequestDto
    {
        public Guid ID { get; set; }
        public Guid Employee { get; set; }
        public AbsenceReasonEnum AbsenceReason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Comment { get; set; }
        public SubmitStateEnum Status { get; set; }
    }
}
