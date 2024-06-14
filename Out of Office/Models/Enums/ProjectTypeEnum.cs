using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models.Enums
{
    public enum ProjectTypeEnum
    {
        [EnumMember(Value = "Internal")]
        Internal = 1,

        [EnumMember(Value = "External")]
        External = 2
    }
}
