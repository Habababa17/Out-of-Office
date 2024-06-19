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
        [Required]
        [Key]
        public Guid ID { get; set; }

        [Required]
        [ForeignKey("Approver")]
        public Guid Approver { get; set; }

        [Required]
        [ForeignKey("LeaveRequest")]
        public Guid LeaveRequest { get; set; }

        [Required]
        [ForeignKey("Status")]
        public int Status { get; set; } 

        public string? Comment { get; set; }

    }
}
