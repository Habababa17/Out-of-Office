using Microsoft.EntityFrameworkCore;
using Out_of_Office.Data.IRepositories;
using Out_of_Office.Models.DB_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Data.Repositories
{
    public class EmployeeProjectAssignmentRepository : Repository<EmployeeProjectAssignmentModel>, IEmployeeProjectAssignmentRepository
    {
        public EmployeeProjectAssignmentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<EmployeeProjectAssignmentModel> GetByIdAsync(Guid projectId, Guid employeeId) //doesnt work
        {
            return await _dbContext.EmployeeProjectAssignment
                                      .FirstOrDefaultAsync(e => (e.ProjectID == projectId && e.EmployeeID == employeeId));
        }

        //public Task<EmployeeProjectAssignmentListDto> GetProjectAssignmentsAsync(Guid projectID)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
