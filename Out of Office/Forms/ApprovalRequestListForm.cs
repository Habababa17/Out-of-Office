using Microsoft.Extensions.DependencyInjection;
using Out_of_Office.Forms.Creators;
using Out_of_Office.Forms.InfoForms;
using Out_of_Office.Forms.ListControl;
using Out_of_Office.Helpers;
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
    public partial class ApprovalRequestListForm : ListForm<ApprovalRequestDto, ApprovalRequestFiltersDto>
    {
        public ApprovalRequestListForm() : base() { }

        public ApprovalRequestListForm(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            dataGrid.RowHeaderMouseClick += DataGrid_RowHeaderMouseClick;
        }
        public override async Task InitializeAsync()
        {
            switch (AuthorizationHelper.position)
            {
                case Models.Enums.PositionEnum.HRManager:
                    this.collection = (await this._serviceProvider.GetRequiredService<IApprovalRequestService>().GetApprovalRequestsAsync()).ApprovalRequests;
                    break;
                case Models.Enums.PositionEnum.ProjectManager:
                    this.collection = (await this._serviceProvider.GetRequiredService<IApprovalRequestService>().GetApprovalRequestsAsync()).ApprovalRequests;
                    break;
                case Models.Enums.PositionEnum.Employee:
                    this.collection = (await this._serviceProvider.GetRequiredService<IApprovalRequestService>().GetUsersApprovalRequestsAsync(AuthorizationHelper.loggedInUser.ID)).ApprovalRequests;
                    break;
                default:
                    break;
            }
            UpdateUI();
        }

        public override void DataGrid_RowHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            //get selected approval request to update
            var selectedApprovalRequest = (ApprovalRequestDto)dataGrid.Rows[e.RowIndex].DataBoundItem;
            
            LeaveRequestInfoForm infoForm = new LeaveRequestInfoForm(_serviceProvider, selectedApprovalRequest.LeaveRequest);
            infoForm.ShowDialog();
        }
    }
}
