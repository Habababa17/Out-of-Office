using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models.Enums
{
    public enum SubdivisionEnum
    {
        [EnumMember(Value = "Subdivision1")]
        Subdivision1 = 1,

        [EnumMember(Value = "Subdivision2")]
        Subdivision2 = 2
    }
}
