using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models.Dto_Models
{
    public class EmployeeProjectAssignmentListDto
    {
        [DataMember(Name = "approvalRequests", EmitDefaultValue = false)]
        public List<ApprovalRequestDto> ApprovalRequests { get; set; }

        public EmployeeProjectAssignmentListDto()
        {
            ApprovalRequests = new List<ApprovalRequestDto>();
        }
    }
}
