using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models.Enums
{
    public enum StatusEnum
    {
        [EnumMember(Value = "Active")]
        Active = 1,

        [EnumMember(Value = "Inactive")]
        Inactive = 2
    }
}
