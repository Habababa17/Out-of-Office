using Out_of_Office.DB_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Out_of_Office.Models.Enums;

namespace Out_of_Office.Models.DB_Models
{
    public class ProjectModel
    {
        [Required]
        [Key]
        public Guid ID { get; set; }

        public string?   ProjectName { get; set; }

        [Required]
        [ForeignKey("ProjectType")]
        public int ProjectType { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public Guid ProjectManager { get; set; }

        public string? Comment { get; set; }

        [Required]
        [ForeignKey("Status")]
        public int Status { get; set; } 
    }
}
