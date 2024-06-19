using Out_of_Office.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models.Dto_Models
{
    public class EmployeeDto
    {
        public Guid ID { get; set; }

        public string FullName { get; set; }

        public SubdivisionEnum Subdivision { get; set; }

        public PositionEnum Position { get; set; }

        public StatusEnum Status { get; set; }

        public Guid? PeoplePartner { get; set; }

        public int OutOfOfficeBalance { get; set; }

        public byte[]? Photo { get; set; }
    }
}
