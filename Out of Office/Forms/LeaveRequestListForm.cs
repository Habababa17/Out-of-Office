using Microsoft.Extensions.DependencyInjection;
using Out_of_Office.Forms.Creators;
using Out_of_Office.Forms.ListControl;
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
    public partial class LeaveRequestListForm : ListForm<LeaveRequestDto, LeaveRequestFiltersDto>
    {

        private int Creatorstate = 1;//state meant for updating
        public LeaveRequestListForm() : base() { }

        public LeaveRequestListForm(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            dataGrid.RowHeaderMouseClick += DataGrid_RowHeaderMouseClick;
            ShowEmbeddedForm(new LeaveRequestControl(_serviceProvider));
            //ShowFilterForm(new (collection, new EmployeeFiltersDto()));
        }

        public override void DataGrid_RowHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            //get selected leave request to update
            var selectedLeaveRequest = (LeaveRequestDto)dataGrid.Rows[e.RowIndex].DataBoundItem; 

            LeaveRequestCreatorForm leaveRequestForm = new LeaveRequestCreatorForm(_serviceProvider, Creatorstate, selectedLeaveRequest);
            
            leaveRequestForm.ShowDialog();
        }

        public override async Task InitializeAsync()
        {

            this.collection = (await this._serviceProvider.GetRequiredService<ILeaveRequestService>().GetLeaveRequestsAsync()).LeaveRequests;
        }

        //private void UpdateLeaveRequest(LeaveRequestDto entity) 
        //{
        //    this._serviceProvider.GetRequiredService<ILeaveRequestService>().UpdateLeaveRequestAsync(entity);
        //}


    }
}
