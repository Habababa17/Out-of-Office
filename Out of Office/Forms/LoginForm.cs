using Microsoft.Extensions.DependencyInjection;
using Out_of_Office.Models.Dto_Models;
using Out_of_Office.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Out_of_Office.Forms
{
    public partial class LoginForm : Form
    {
        private IServiceProvider _serviceProvider;
        private IEmployeeService _employeeService;
        private Button confirmLoginButton;
        private ComboBox employeeSelectionList;
        EmployeeListDto employees;

        public LoginForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _employeeService = serviceProvider.GetRequiredService<IEmployeeService>();
            InitializeComponent();
        }

        protected override async void OnLoad(EventArgs e)
        {
            await InitializeAsync();
            UpdateUI();
        }
        private void UpdateUI()
        {
            employeeSelectionList.DataSource = employees.Employees.Select(e => e.FullName).ToList();
            confirmLoginButton.Enabled = true;
        }
        private void InitializeComponent()
        {
            confirmLoginButton = new Button();
            employeeSelectionList = new ComboBox();
            SuspendLayout();
            // 
            // confirmLoginButton
            // 
            confirmLoginButton.Enabled = false;
            confirmLoginButton.Location = new Point(229, 27);
            confirmLoginButton.Name = "confirmLoginButton";
            confirmLoginButton.Size = new Size(75, 23);
            confirmLoginButton.TabIndex = 1;
            confirmLoginButton.Text = "Login";
            confirmLoginButton.UseVisualStyleBackColor = true;
            confirmLoginButton.Click += confirmLoginButton_Click;
            // 
            // employeeSelectionList
            // 
            employeeSelectionList.FormattingEnabled = true;
            employeeSelectionList.Location = new Point(12, 27);
            employeeSelectionList.Name = "employeeSelectionList";
            employeeSelectionList.Size = new Size(201, 23);
            employeeSelectionList.TabIndex = 2;
            // 
            // LoginForm
            // 
            ClientSize = new Size(318, 77);
            Controls.Add(employeeSelectionList);
            Controls.Add(confirmLoginButton);
            Name = "LoginForm";
            Text = "Choose Employee to login as";
            Load += On_Load;
            ResumeLayout(false);
        }

        private async Task InitializeAsync()
        {
            employees = await _employeeService.GetUsersAsync();
        }

        private void On_Load(object sender, EventArgs e)
        {
            this.OnLoad(e);
        }

        private void confirmLoginButton_Click(object sender, EventArgs e)
        {
            if (employeeSelectionList.SelectedIndex != -1)
            {
                //helper contains info on logged in user
                Helpers.AuthorizationHelper.SetLoggedInUser(employees.Employees[employeeSelectionList.SelectedIndex]);

                //main form working
                this.Hide(); 
                MainForm mainForm = new MainForm(_serviceProvider);
                mainForm.FormClosed += MainForm_FormClosed; 
                mainForm.Show(); 
            }
            else
            {
                MessageBox.Show("Please select an employee to login.");
            }
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show(); 
        }

    }
}
