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
        [Key]
        public Guid ID { get; set; }

        [Required]
        [ForeignKey("ProjectType")]
        public ProjectTypeEnum ProjectType { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public Guid ProjectManager { get; set; }

        public string? Comment { get; set; }

        [Required]
        [StringLength(10)]
        public string Status { get; set; } = "Active"; // Default value is "Active"

        // Navigation properties

        [ForeignKey("ProjectManager")]
        public EmployeeModel ProjectManagerObject { get; set; }
    }
}
