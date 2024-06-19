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
    public class EmployeeProjectAssignmentModel
    {
        [Key]
        public Guid EmployeeID { get; set; }

        [Key]
        public Guid ProjectID { get; set; }

        public virtual EmployeeModel Employee { get; set; }
        public virtual ProjectModel Project { get; set; }

    }
}
