using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class ProjectCreatorForm : Form
    {
        protected IServiceProvider _serviceProvider;
        protected ProjectDto _projectDto;

        public ProjectCreatorForm() //only exists for designer
        {

        }

        private void SetUpComponent()
        {
            InitializeComponent();

            projectTypeComboBox.DataSource = Enum.GetValues(typeof(ProjectTypeEnum));
            projectTypeComboBox.DisplayMember = "DisplayText";
            statusComboBox.DataSource = Enum.GetValues(typeof(StatusEnum));
            statusComboBox.DisplayMember = "DisplayText";

        }
        public ProjectCreatorForm(IServiceProvider serviceProvider, ProjectDto projectDto) : this() //Edit/View Project Constructor
        {
            _serviceProvider = serviceProvider;
            _projectDto = projectDto;

            
            SetUpComponent();
            saveButton.Click += saveButton_Click_Edit;

            var userList = new List<SimpleEmployeeDto> 
                {
                   new SimpleEmployeeDto
                   { 
                       ID =_projectDto.ProjectManager,
                       FullName = _projectDto.ProjectManagerName,
                   }, //assuming user is of Manager position
                };
            managerComboBox.DataSource = userList;
            managerComboBox.DisplayMember = "FullName";

            nameTextBox.Text = _projectDto.ProjectName;
            projectTypeComboBox.SelectedItem = _projectDto.ProjectType;
            startTimePicker.Value = _projectDto.StartDate;
            endTimePicker.Value = _projectDto.EndDate;
            managerComboBox.SelectedItem = _projectDto.ProjectManagerName;
            commentTextBox.Text = _projectDto.Comment;
            statusComboBox.SelectedItem = _projectDto.Status;

            if (_projectDto.ProjectManager != AuthorizationHelper.loggedInUser.ID)
            {
                nameTextBox.Enabled = false;
                projectTypeComboBox.Enabled = false;
                startTimePicker.Enabled = false;
                endTimePicker.Enabled = false;
                managerComboBox.Enabled = false;
                commentTextBox.Enabled = false;
                statusComboBox.Enabled = false;
            }
        }
        public ProjectCreatorForm(IServiceProvider serviceProvider) : this() //Add Project Constructor
        {
            _projectDto = new ProjectDto();
            _serviceProvider = serviceProvider;

            SetUpComponent();
            saveButton.Click += saveButton_Click_Add;

            var userList = new List<SimpleEmployeeDto> {
                new SimpleEmployeeDto()
                    {
                    ID = AuthorizationHelper.loggedInUser.ID,
                    FullName = AuthorizationHelper.loggedInUser.FullName,
                    },
                };
            managerComboBox.DataSource = userList;
            managerComboBox.DisplayMember = "FullName";
            managerComboBox.ValueMember = "ID";
            seeEmployeesButton.Visible = false; //add employees only to existing project
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void saveButton_Click_Edit(object sender, EventArgs e)
        {
            GetDtoFromForm();
            UpdateProject();
            Close();
        }
        private void saveButton_Click_Add(object sender, EventArgs e)
        {
            GetDtoFromForm();
            AddProject();
            Close();
        }
        private void GetDtoFromForm()
        {
            if (_projectDto.ID == Guid.Empty)
                _projectDto.ID = Guid.NewGuid();
            _projectDto.ProjectName = nameTextBox.Text;
            _projectDto.ProjectType = (ProjectTypeEnum)projectTypeComboBox.SelectedItem;
            _projectDto.StartDate = startTimePicker.Value;
            _projectDto.EndDate = endTimePicker.Value;
            _projectDto.ProjectManager = ((SimpleEmployeeDto)managerComboBox.SelectedItem).ID;
            _projectDto.Comment = commentTextBox.Text;
            _projectDto.Status = (StatusEnum)statusComboBox.SelectedItem;
        }
        private async Task UpdateProject()
        {
            await _serviceProvider.GetRequiredService<IProjectService>().UpdateProjectAsync(_projectDto);
        }
        private async Task AddProject()
        {
            await _serviceProvider.GetRequiredService<IProjectService>().AddProjectAsync(_projectDto);
        }
        private void seeEmployeesButton_Click(object sender, EventArgs e)
        {
            EmployeeProjectManagerForm form = new EmployeeProjectManagerForm(_serviceProvider, _projectDto);
            form.ShowDialog();
        }
    }
}
