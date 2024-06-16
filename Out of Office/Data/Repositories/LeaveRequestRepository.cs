using Out_of_Office.Data.IRepositories;
using Out_of_Office.Models.DB_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Data.Repositories
{
    internal class LeaveRequestRepository : Repository<LeaveRequestModel>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
