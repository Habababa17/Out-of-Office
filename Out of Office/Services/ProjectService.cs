using Out_of_Office.Data.IRepositories;
using Out_of_Office.Data.Repositories;
using Out_of_Office.Helpers;
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
        private readonly IEmployeeProjectAssignmentRepository _employeeProjectAssignmentRepository;
        IEmployeeRepository _employeeRepository;
        public ProjectService(IProjectRepository projectRepository, IEmployeeProjectAssignmentRepository employeeProjectAssignmentRepository, IEmployeeRepository employeeRepository)
        {
            _projectRepository = projectRepository;
            _employeeProjectAssignmentRepository = employeeProjectAssignmentRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task AddProjectAsync(ProjectDto projectDto)
        {
            var project = Helpers.Converters.ProjectConverter.ToModel(projectDto);
            await _projectRepository.AddAsync(project);
        }

        public async Task<ProjectListDto> GetProjectsAsync(ProjectFiltersDto? filtersDto = null)
        {
            var projectList = await _projectRepository.GetAllAsync();

            switch (AuthorizationHelper.loggedInUser.Position)
            {
                case Models.Enums.PositionEnum.HRManager:

                    break;

                case Models.Enums.PositionEnum.ProjectManager:
                    projectList = projectList.Where(e => e.ProjectManager == AuthorizationHelper.loggedInUser.ID).ToList();
                    break;

                case Models.Enums.PositionEnum.Employee:
                    //get projects ids employee is assigned to
                    var userProjects = (await _employeeProjectAssignmentRepository.GetAllAsync())
                        .Where(e => e.EmployeeID == AuthorizationHelper.loggedInUser.ID)
                        .Select(e => e.ProjectID)
                        .ToList();

                    //get projects employee is assigned to
                    projectList = projectList.Where(e => userProjects.Contains(e.ID)).ToList();
                    break;

                default:
                    throw new Exception("wrong role");
            }
            
            ProjectListDto projectListListDto = new ProjectListDto();
            foreach (var proj in projectList)
                projectListListDto.projects.Add(ProjectConverter.ToDto(proj));


            //add name of proj manager to projects
            foreach (var project in projectListListDto.projects)
            {
                var manager = await _employeeRepository.GetAsync(project.ProjectManager);
                project.ProjectManagerName = manager.FullName;
            }


            return projectListListDto;
        }

        public async Task UpdateProjectAsync(ProjectDto project)
        {
            var projectModel = await _projectRepository.GetAsync(project.ID);
            var updatedmodel = ProjectConverter.ToModel(project);

            projectModel.ProjectManager = updatedmodel.ProjectManager;
            projectModel.ProjectName = updatedmodel.ProjectName;
            projectModel.Status = updatedmodel.Status;
            projectModel.Comment = updatedmodel.Comment;
            projectModel.StartDate = updatedmodel.StartDate;
            projectModel.EndDate = updatedmodel.EndDate;
            projectModel.ProjectType = updatedmodel.ProjectType;

            try
            {
                await _projectRepository.UpdateAsync(projectModel);
            }
            catch (Exception ex) { }
        }
    }
}
