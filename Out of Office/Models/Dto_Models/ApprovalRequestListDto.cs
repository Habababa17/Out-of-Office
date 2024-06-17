using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models.Dto_Models
{
    public partial class ApprovalRequestListDto : IEquatable<ApprovalRequestListDto>
    {
        [DataMember(Name = "approvalRequests", EmitDefaultValue = false)]
        public List<ApprovalRequestDto> ApprovalRequests { get; set; }

        public ApprovalRequestListDto()
        {
            ApprovalRequests = new List<ApprovalRequestDto>();
        }

        public bool Equals(ApprovalRequestListDto? other)
        {
            throw new NotImplementedException();
        }
    }
}
