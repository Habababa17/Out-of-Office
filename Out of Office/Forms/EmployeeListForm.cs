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
    public partial class EmployeeListForm : ListForm<EmployeeDto, EmployeeFiltersDto>
    {

        public EmployeeListForm() : base() { }


        public EmployeeListForm(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            dataGrid.RowHeaderMouseClick += DataGrid_RowHeaderMouseClick;
            ShowEmbeddedForm(new EmployeeControl(_serviceProvider));
        }

        public override async Task InitializeAsync()
        {
            switch (AuthorizationHelper.position)
            {
                case Models.Enums.PositionEnum.HRManager:
                    this.collection = (await this._serviceProvider.GetRequiredService<IEmployeeService>().GetUsersAsync()).Employees;
                    break;
                case Models.Enums.PositionEnum.ProjectManager:
                    this.collection = (await this._serviceProvider.GetRequiredService<IEmployeeService>().GetUsersFromProjectsAsync(AuthorizationHelper.loggedInUser.ID)).Employees;
                    break;
                case Models.Enums.PositionEnum.Employee:
                    this.collection = new List<EmployeeDto> { AuthorizationHelper.loggedInUser };
                    break;
                default:
                    break;
            }


            ShowFilterForm(new EmployeeFilterForm(ref collection, new EmployeeFiltersDto(), newCollection => this.UpdateUI(newCollection)));
        }

        public override void DataGrid_RowHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            var selectedEmployee = (EmployeeDto)dataGrid.Rows[e.RowIndex].DataBoundItem;

            EmployeeCreatorForm infoForm = new EmployeeCreatorForm(_serviceProvider, selectedEmployee);
            infoForm.ShowDialog();
        }
    }
}
