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
    public class ProjectRepository : Repository<ProjectModel>, IProjectRepository
    {
        public ProjectRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ProjectModel?> GetAsync(Guid id)
        {

            return await _dbContext.Project
                .FirstOrDefaultAsync(c => c.ID == id);

        }
    }
}
