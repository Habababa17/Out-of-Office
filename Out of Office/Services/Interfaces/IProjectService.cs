using Out_of_Office.Models.DB_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Services.Interfaces
{
    public interface IProjectService
    {
        public Task AddProject(ProjectModel project); //TODO change to dto
    }
}
