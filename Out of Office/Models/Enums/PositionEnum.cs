using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models.Enums
{
    public enum PositionEnum
    {
        [EnumMember(Value = "HRManager")]
        HRManager = 1,

        [EnumMember(Value = "ProjectManager")]
        ProjectManager = 2,

        [EnumMember(Value = "Employee")]
        Employee = 3
    }
}
