using Microsoft.Extensions.DependencyInjection;
using Out_of_Office.Models.Dto_Models;
using Out_of_Office.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Out_of_Office.Forms
{
    public partial class ApprovalRequestListForm : ListForm<ApprovalRequestDto>
    {
        public ApprovalRequestListForm() : base() { }

        public ApprovalRequestListForm(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
        public override async Task InitializeAsync()
        {
            this.collection = (await this._serviceProvider.GetRequiredService<IApprovalRequestService>().GetApprovalRequestsAsync()).ApprovalRequests;
        }


    }
}
