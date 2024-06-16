using Out_of_Office.DB_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models.DB_Models
{
    public class ApprovalRequestModel
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public Guid Approver { get; set; }

        [Required]
        public Guid LeaveRequest { get; set; }

        [Required]
        [StringLength(10)]
        public string Status { get; set; } = "New"; // Default value is "New"

        public string? Comment { get; set; }

        // Navigation properties
        [ForeignKey("Approver")]
        public EmployeeModel ApproverObject { get; set; }

        [ForeignKey("LeaveRequest")]
        public LeaveRequestModel LeaveRequestObject { get; set; }
    }
}
