using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.ApplicationServices;
using Out_of_Office.Forms.Interfaces;
using Out_of_Office.Helpers;
using Out_of_Office.Models.Dto_Models;
using Out_of_Office.Models.Enums;
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

namespace Out_of_Office.Forms.Creators
{
    public partial class EmployeeCreatorForm : Form
    {
        protected IServiceProvider _serviceProvider;
        protected EmployeeDto _employeeDto;
        protected EmployeeFiltersDto _filters;
        public EmployeeCreatorForm()
        {
            
        }
        private void SetUpComponent()
        {
            InitializeComponent();

            subdivisionComboBox.DataSource = Enum.GetValues(typeof(SubdivisionEnum));
            subdivisionComboBox.DisplayMember = "DisplayText";
            positionComboBox.DataSource = Enum.GetValues(typeof(PositionEnum));
            positionComboBox.DisplayMember = "DisplayText";
            statusComboBox.DataSource = Enum.GetValues(typeof(StatusEnum));
            statusComboBox.DisplayMember = "DisplayText";

        }
        public EmployeeCreatorForm(IServiceProvider serviceProvider, EmployeeDto employeeDto) : this() //Edit Employee Constructor
        {
            _serviceProvider = serviceProvider;
            _employeeDto = employeeDto;

            SetUpComponent();

            SaveButton.Click += SaveButtonEdit_Click;

            subdivisionComboBox.SelectedItem = employeeDto.Subdivision;
            positionComboBox.SelectedItem = employeeDto.Position;           
            statusComboBox.SelectedItem = employeeDto.Status;
            balanceTextBox.Value = employeeDto.OutOfOfficeBalance;
            nameTextBox.Text = employeeDto.FullName;
            SetupPartner(employeeDto.PeoplePartner);



            if (!(AuthorizationHelper.loggedInUser.Position == PositionEnum.HRManager)) //HR edit 
            {
                subdivisionComboBox.Enabled = false;
                positionComboBox.Enabled = false;
                statusComboBox.Enabled = false;
                balanceTextBox.Enabled = false;
                partnerComboBox.Enabled = false;
                nameTextBox.Enabled = false;
            }

            if (AuthorizationHelper.loggedInUser.ID == employeeDto.ID) //allow user to edit themselves
            {
                nameTextBox.Enabled = true;

            }



        }
        private async void SetupPartner(Guid? id)
        {
            if(id.HasValue)
            {
                var userList = new List<EmployeeDto>
                {
                    (await _serviceProvider.GetRequiredService<IEmployeeService>()
                    .GetEmployeeAsync(id?? throw new Exception("employee null value"))),
                };
                partnerComboBox.DataSource = userList;
                partnerComboBox.SelectedItem = userList[0];
                partnerComboBox.DisplayMember = "FullName";
            }
        }

        public EmployeeCreatorForm(IServiceProvider serviceProvider) : this() //Add employee Constructor
        {
            _employeeDto = new EmployeeDto();
            _serviceProvider = serviceProvider;

            SetUpComponent();
            SaveButton.Click += SaveButtonAdd_Click;
            //TODO partnerComboBox should be able to choose all HR managers,
            //placeholder: now its adding partner as HR user who created the employee
            var userList = new List<EmployeeDto>
                {
                    AuthorizationHelper.loggedInUser //assuming user is of HR position
                };
            partnerComboBox.DataSource = userList;
            partnerComboBox.DisplayMember = "FullName";
            partnerComboBox.ValueMember = "ID";

            //set deafult value for balance
            balanceTextBox.Value = 5;

        }
        public EmployeeCreatorForm(ref EmployeeFiltersDto filters)
        {
            _filters = filters;

            SetUpComponent();
            SaveButton.Click += SaveButtonFilters_Click;
            nameTextBox.Text = _filters.FullName ;
            subdivisionComboBox.SelectedItem = filters.SubdivisionEnum ;
            positionComboBox.SelectedItem = filters.PositionEnum ;
            statusComboBox.SelectedItem = filters.StatusEnum ;
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async Task AddEmployee()
        {
            await _serviceProvider.GetRequiredService<IEmployeeService>().AddEmployeeAsync(_employeeDto);
        }
        private async Task UpdateEmployee()
        {
            await _serviceProvider.GetRequiredService<IEmployeeService>().UpdateEmployeeAsync(_employeeDto);
        }
        private void CreateEmployeeDtoFromForm()
        {
            if (_employeeDto.ID == Guid.Empty)
                _employeeDto.ID = new Guid();
            _employeeDto.Status = (StatusEnum)statusComboBox.SelectedValue;
            _employeeDto.OutOfOfficeBalance = (int)balanceTextBox.Value;
            _employeeDto.FullName = nameTextBox.Text;
            _employeeDto.PeoplePartner = ((EmployeeDto)partnerComboBox.SelectedItem).ID;
            _employeeDto.Position = (PositionEnum)positionComboBox.SelectedItem;
            _employeeDto.Subdivision = (SubdivisionEnum)subdivisionComboBox.SelectedItem;

        }
        private void CreateFilters()
        { 
            _filters.FullName = string.IsNullOrEmpty(nameTextBox.Text) ? null : nameTextBox.Text;
            _filters.SubdivisionEnum = (SubdivisionEnum?)subdivisionComboBox.SelectedItem;
            _filters.PositionEnum = (PositionEnum?)positionComboBox.SelectedItem;
            _filters.StatusEnum = (StatusEnum?)statusComboBox.SelectedItem;
        }
        private void SaveButtonAdd_Click(object sender, EventArgs e)
        {
            CreateEmployeeDtoFromForm();
            AddEmployee();
            Close();
        }
        private void SaveButtonEdit_Click(object sender, EventArgs e)
        {
            CreateEmployeeDtoFromForm();
            UpdateEmployee();
            Close();
        }
        private void SaveButtonFilters_Click(object sender, EventArgs e)
        {
            CreateFilters();
            Close();
        }
    }
}
