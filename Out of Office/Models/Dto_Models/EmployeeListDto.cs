using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models.Dto_Models
{
    public partial class EmployeeListDto : IEquatable<EmployeeListDto>
    {
        [DataMember(Name = "employees", EmitDefaultValue = false)]
        public List<EmployeeDto> Employees { get; set; }

        public EmployeeListDto()
        {
            Employees = new List<EmployeeDto>();
        }

        public bool Equals(EmployeeListDto? other)
        {
            throw new NotImplementedException();
        }
    }
}
