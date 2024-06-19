using Microsoft.EntityFrameworkCore;
using Out_of_Office.Data.IRepositories;
using Out_of_Office.Helpers;
using Out_of_Office.Models.DB_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Data.Repositories
{
    public class LeaveRequestRepository : Repository<LeaveRequestModel>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<LeaveRequestModel?> GetAsync(Guid id)
        {
            return await _dbContext.LeaveRequest
                .FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task<IEnumerable<LeaveRequestModel>> GetUserLeaveRequestsAsync()
        {
            return await _dbContext.Set<LeaveRequestModel>()
                .Where(e => e.Employee == AuthorizationHelper.loggedInUser.ID)
                .ToListAsync();
                
        }

    }
}
