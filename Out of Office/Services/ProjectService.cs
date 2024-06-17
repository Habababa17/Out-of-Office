using Out_of_Office.Data.IRepositories;
using Out_of_Office.Data.Repositories;
using Out_of_Office.Helpers.Converters;
using Out_of_Office.Models.DB_Models;
using Out_of_Office.Models.Dto_Models;
using Out_of_Office.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }


        public async Task AddProject(ProjectModel project)
        {
            await _projectRepository.AddAsync(project);
        }

        public async Task<ProjectListDto> GetProjectsAsync(ProjectFiltersDto? filtersDto = null)
        {
            var projectList = await _projectRepository.GetAllAsync();
            ProjectListDto projectListListDto = new ProjectListDto();
            foreach (var proj in projectList)
                projectListListDto.projects.Add(ProjectConverter.ToDto(proj));
            return projectListListDto;
        }
    }
}
