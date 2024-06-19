using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models.Dto_Models
{
    public partial class LeaveRequestListDto : IEquatable<LeaveRequestListDto>
    {
        [DataMember(Name = "leaveRequests", EmitDefaultValue = false)]
        public List<LeaveRequestDto> LeaveRequests { get; set; }

        public LeaveRequestListDto()
        {
            LeaveRequests = new List<LeaveRequestDto>();
        }

        public bool Equals(LeaveRequestListDto? other)
        {
            throw new NotImplementedException();
        }
    }
}
