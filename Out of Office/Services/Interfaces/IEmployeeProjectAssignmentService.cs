using Out_of_Office.Models.Dto_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Services.Interfaces
{
    public interface IEmployeeProjectAssignmentService
    {
        public abstract Task<EmployeeProjectAssignmentListDto> GetProjectAssignmentsAsync(Guid projectID);
        public abstract Task UpdateProjectAssignments(EmployeeListDto assignedEmployees, EmployeeListDto unassignedEmployees, Guid projectID);
    }
}
