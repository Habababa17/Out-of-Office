using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models.Enums
{
    public enum AbsenceReasonEnum
    {
        [EnumMember(Value = "Vacation")]
        Vacation = 1,

        [EnumMember(Value = "Sick Leave")]
        SickLeave = 2
    }
}
