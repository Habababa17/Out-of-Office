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
    public class EmployeeProjectAssignment
    {
        [Key]
        public Guid EmployeeID { get; set; }

        [Key]
        public Guid ProjectID { get; set; }

        // Navigation properties
        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }

        [ForeignKey("ProjectID")]
        public Project Project { get; set; }
    }
}
