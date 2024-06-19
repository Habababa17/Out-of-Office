using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models.Dto_Models
{
    public class ProjectListDto : IEquatable<ProjectListDto>
    {
        public List<ProjectDto> projects { get; set; }
        public ProjectListDto()
        {
            projects = new List<ProjectDto>();
        }
        public bool Equals(ProjectListDto? other)
        {
            throw new NotImplementedException();
        }
    }
}
