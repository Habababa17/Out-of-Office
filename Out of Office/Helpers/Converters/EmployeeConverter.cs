using Out_of_Office.DB_Models;
using Out_of_Office.Models.Dto_Models;
using Out_of_Office.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Helpers.Converters
{
    public static class EmployeeConverter
    {
        public static EmployeeDto ToDto(EmployeeModel model)
        {
            return new EmployeeDto
            {
                ID = model.ID,
                FullName = model.FullName,
                Subdivision = (SubdivisionEnum)model.Subdivision,
                Position = (PositionEnum)model.Position,
                Status = (StatusEnum)model.Status,
                PeoplePartner = model.PeoplePartner,
                OutOfOfficeBalance = model.OutOfOfficeBalance,
                Photo = model.Photo
            };
        }

        public static EmployeeModel ToModel(EmployeeDto dto)
        {
            return new EmployeeModel
            {
                ID = dto.ID,
                FullName = dto.FullName,
                Subdivision = (int)dto.Subdivision,
                Position = (int)dto.Position,
                Status = (int)dto.Status,
                PeoplePartner = dto.PeoplePartner,
                OutOfOfficeBalance = dto.OutOfOfficeBalance,
                Photo = dto.Photo
            };
        }
    }
}
