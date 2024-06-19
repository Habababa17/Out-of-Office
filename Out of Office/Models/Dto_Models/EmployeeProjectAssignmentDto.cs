using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models.Dto_Models
{
    public class EmployeeProjectAssignmentDto
    {
        public Guid EmployeeID { get; set; }
        public Guid ProjectID { get; set; }
    }
}
