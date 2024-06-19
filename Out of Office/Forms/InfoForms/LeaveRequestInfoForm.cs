using Microsoft.Extensions.DependencyInjection;
using Out_of_Office.Helpers;
using Out_of_Office.Models.Dto_Models;
using Out_of_Office.Models.Enums;
using Out_of_Office.Services;
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

namespace Out_of_Office.Forms.InfoForms
{
    public partial class LeaveRequestInfoForm : Form
    {
        private IServiceProvider _serviceProvider;
        private Guid _id;
        public LeaveRequestInfoForm(IServiceProvider serviceProvider, Guid lrID)
        {
            _id = lrID;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            LeaveRequestDto lr = await _serviceProvider.GetRequiredService<ILeaveRequestService>().GetLeaveRequestAsync(_id);
            EmployeeDto emp = await _serviceProvider.GetRequiredService<IEmployeeService>().GetEmployeeAsync(lr.Employee);
            requesterNameTextBox.Text = emp.FullName;
            reasonTextBox.Text = lr.AbsenceReason.ToString();
            startDateTextBox.Text = lr.StartDate.ToString();
            endDateTextBox.Text = lr.EndDate.ToString();
            commentTextBox.Text = lr.Comment;

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            FinalizeApporalRequest(SubmitStateEnum.Accepted);
        }

        private void denyButton_Click(object sender, EventArgs e)
        {
            FinalizeApporalRequest(SubmitStateEnum.Denied);
        }

        private async void FinalizeApporalRequest(SubmitStateEnum submitState)
        {
            ApprovalRequestDto dto = new ApprovalRequestDto()
            {
                ID = new Guid(),
                Approver = AuthorizationHelper.loggedInUser.ID,
                LeaveRequest = _id,
                Status = submitState,
                Comment = approverCommentBox.Text,
            };
            await _serviceProvider.GetRequiredService<IApprovalRequestService>().AddApprovalRequestAsync(dto);
            Close();

        }

        private void approverCommentBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
