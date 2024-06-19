using Out_of_Office.Models.DB_Models;
using Out_of_Office.Models.Dto_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Helpers.Converters
{
    public static class EmployeeProjectAssignmentConverter
    {

        public static EmployeeProjectAssignmentDto ToDto(EmployeeProjectAssignmentModel model)
        {
            return new EmployeeProjectAssignmentDto
            {
                EmployeeID = model.EmployeeID,
                ProjectID = model.ProjectID
            };
        }

        public static EmployeeProjectAssignmentModel ToModel(EmployeeProjectAssignmentDto dto)
        {
            return new EmployeeProjectAssignmentModel
            {
                EmployeeID = dto.EmployeeID,
                ProjectID = dto.ProjectID
            };
        }

    }
}
