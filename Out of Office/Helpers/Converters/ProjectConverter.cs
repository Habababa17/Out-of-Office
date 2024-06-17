using Out_of_Office.Models.DB_Models;
using Out_of_Office.Models.Dto_Models;
using Out_of_Office.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Helpers.Converters
{
    public static class ProjectConverter
    {
        public static ProjectDto ToDto(ProjectModel model)
        {
            return new ProjectDto
            {
                ID = model.ID,
                ProjectType = (ProjectTypeEnum)model.ProjectType,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                ProjectManager = model.ProjectManager,
                Comment = model.Comment,
                Status = (ProjectStatusEnum)model.Status,
            };
        }

        public static ProjectModel ToModel(ProjectDto dto)
        {
            return new ProjectModel
            {
                ID = dto.ID,
                ProjectType = (int)dto.ProjectType,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                ProjectManager = dto.ProjectManager,
                Comment = dto.Comment,
                Status = (int)dto.Status,
            };
        }
    }
}
