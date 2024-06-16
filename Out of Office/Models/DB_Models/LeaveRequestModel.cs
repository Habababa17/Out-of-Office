using Out_of_Office.DB_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Out_of_Office.Models.Enums;
namespace Out_of_Office.Models.DB_Models
{
    public class LeaveRequestModel
    {
        public Guid ID { get; set; }
        public Guid Employee { get; set; }

        [ForeignKey("AbsenceReason")]
        public AbsenceReasonEnum AbsenceReason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Comment { get; set; }
        public string Status { get; set; }

        // Navigation properties
        public EmployeeModel EmployeeObject { get; set; }
    }
}
