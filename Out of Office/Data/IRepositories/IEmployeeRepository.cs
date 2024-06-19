using Microsoft.EntityFrameworkCore;
using Out_of_Office.DB_Models;
using Out_of_Office.Models.DB_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Data.IRepositories
{
    public interface IEmployeeRepository : IRepository<EmployeeModel>
    {
        public Task<EmployeeModel?> GetAsync(Guid id);

    }
}
