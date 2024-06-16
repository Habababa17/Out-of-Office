using Out_of_Office.Data.IRepositories;
using Out_of_Office.DB_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Data.Repositories
{
    public class EmployeeRepository : Repository<EmployeeModel>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

    }
}
