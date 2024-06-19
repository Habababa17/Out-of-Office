using Microsoft.Extensions.DependencyInjection;
using Out_of_Office.Forms.Interfaces;
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

namespace Out_of_Office.Forms.Creators
{
    public partial class EmployeeProjectManagerForm : Form
    {
        private IServiceProvider _serviceProvider;
        private EmployeeListDto _employeesOnProject;
        private EmployeeListFromCollectionForm? _form1;
        private EmployeeListDto _availableEmployees;
        private EmployeeListFromCollectionForm? _form2;
        private ProjectDto _project;
        public EmployeeProjectManagerForm()
        {
            InitializeComponent();
        }

        public EmployeeProjectManagerForm(IServiceProvider serviceProvider, ProjectDto project)
        {
            _project = project;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            InitializeAsync();


        }
        private async void InitializeAsync()
        {
            _employeesOnProject = await _serviceProvider.GetRequiredService<IEmployeeService>().GetEmployeesOnProjectAsync(_project.ID);
            var allEmployees = await _serviceProvider.GetRequiredService<IEmployeeService>().GetEmployeesAsync();
            _availableEmployees = new EmployeeListDto() 
            {
                Employees = allEmployees.Employees
                    .Where(e => !_employeesOnProject.Employees
                    .Any(p => p.ID == e.ID))
                    .ToList()
            };
            ShowEmbeddedForms(new EmployeeListFromCollectionForm(_employeesOnProject.Employees, DeassignEmployee),
                              new EmployeeListFromCollectionForm(_availableEmployees.Employees, AssignEmployee));
        }

        private void AssignEmployee(Guid employeeID)
        {
            _employeesOnProject.Employees.Add(_availableEmployees.Employees.First(e => e.ID == employeeID));
            _availableEmployees.Employees.RemoveAll(e => e.ID == employeeID);
            _form1.SetCollection(_employeesOnProject.Employees);
            _form2.SetCollection(_availableEmployees.Employees);
            //ShowEmbeddedForms(new EmployeeListFromCollectionForm(_employeesOnProject.Employees, DeassignEmployee), new EmployeeListFromCollectionForm(_availableEmployees.Employees, AssignEmployee));
            
        }
        private void DeassignEmployee(Guid employeeID)
        {
            _availableEmployees.Employees.Add(_employeesOnProject.Employees.First(e => e.ID == employeeID));
            _employeesOnProject.Employees.RemoveAll(e => e.ID == employeeID);
            _form1.SetCollection(_employeesOnProject.Employees);
            _form2.SetCollection(_availableEmployees.Employees);
            //ShowEmbeddedForms(new EmployeeListFromCollectionForm(_employeesOnProject.Employees, DeassignEmployee), new EmployeeListFromCollectionForm(_availableEmployees.Employees, AssignEmployee));
        }

        private void ShowEmbeddedForms(EmployeeListFromCollectionForm form1, EmployeeListFromCollectionForm form2) //this code is bad but no time
        {
            //remove the previously added list form if it exists
            //if (_form1 != null && tableLayoutPanel1.Controls.Contains(_form1))
            //{
            //    tableLayoutPanel1.Controls.Remove(_form1);
            //    _form1.Dispose();
            //}
            ////remove the previously added list form if it exists
            //if (_form2 != null && tableLayoutPanel1.Controls.Contains(_form2))
            //{
            //    tableLayoutPanel1.Controls.Remove(_form2);
            //    _form2.Dispose();
            //}
            tableLayoutPanel1.Controls.Clear();
            _form1 = form1;
            _form2 = form2;

            //add new list form
            _form1.TopLevel = false;
            _form1.FormBorderStyle = FormBorderStyle.None;
            _form1.Dock = DockStyle.Fill;

            tableLayoutPanel1.Controls.Add(_form1, 0, 0);
            _form1.Show();

            //add new list form
            _form2.TopLevel = false;
            _form2.FormBorderStyle = FormBorderStyle.None;
            _form2.Dock = DockStyle.Fill;

            tableLayoutPanel1.Controls.Add(_form2, 0, 1);

            _form2.Show();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            _serviceProvider.GetRequiredService<IEmployeeProjectAssignmentService>().UpdateProjectAssignments(_employeesOnProject, _availableEmployees, _project.ID);
            Close();
        }
    }
}
