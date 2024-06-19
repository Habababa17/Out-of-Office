using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models.Enums
{
    public enum SubmitStateEnum
    {
        [EnumMember(Value = "New")]
        New = 1,

        [EnumMember(Value = "Submitted")]
        Submitted = 2,

        [EnumMember(Value = "Canceled")]
        Canceled = 3,

        [EnumMember(Value = "Accepted")]
        Accepted = 4,

        [EnumMember(Value = "Denied")]
        Denied = 5,
    }
}
