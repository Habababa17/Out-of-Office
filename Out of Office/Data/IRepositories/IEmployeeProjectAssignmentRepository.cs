using Out_of_Office.Models.DB_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Data.IRepositories
{
    public interface IEmployeeProjectAssignmentRepository : IRepository<EmployeeProjectAssignmentModel>
    {
        //public Task<EmployeeProjectAssignmentListDto> GetProjectAssignmentsAsync(Guid projectID);
        public Task<EmployeeProjectAssignmentModel> GetByIdAsync(Guid projectId, Guid employeeId);
    }
}
