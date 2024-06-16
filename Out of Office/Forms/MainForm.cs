using Microsoft.Extensions.DependencyInjection;
using Out_of_Office.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Out_of_Office.Forms
{
    public partial class MainForm : Form
    {
        IServiceProvider _serviceProvider;
        private TableLayoutPanel tableLayoutPanel3;
        private Button[] selectionListButtons;

        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            infoGroupBox = new GroupBox();
            positionTextBox = new TextBox();
            nameTextBox = new TextBox();
            listSelectiongroupBox = new GroupBox();
            approvalRequestsSelectionButton = new Button();
            leaveRequestsSelectionButton = new Button();
            projectsSelectionButton = new Button();
            employeesSelectionButton = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            infoGroupBox.SuspendLayout();
            listSelectiongroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 77.01422F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 22.9857826F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 98F));
            tableLayoutPanel1.Size = new Size(929, 563);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.045454F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.9545441F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 19.67213F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 80.3278656F));
            tableLayoutPanel2.Size = new Size(923, 557);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(infoGroupBox, 0, 0);
            tableLayoutPanel3.Controls.Add(listSelectiongroupBox, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 19.7149639F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 80.2850342F));
            tableLayoutPanel3.Size = new Size(151, 551);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // infoGroupBox
            // 
            infoGroupBox.Controls.Add(positionTextBox);
            infoGroupBox.Controls.Add(nameTextBox);
            infoGroupBox.Dock = DockStyle.Fill;
            infoGroupBox.Location = new Point(3, 3);
            infoGroupBox.Name = "infoGroupBox";
            infoGroupBox.Size = new Size(145, 102);
            infoGroupBox.TabIndex = 2;
            infoGroupBox.TabStop = false;
            // 
            // positionTextBox
            // 
            positionTextBox.Enabled = false;
            positionTextBox.Location = new Point(1, 51);
            positionTextBox.Name = "positionTextBox";
            positionTextBox.Size = new Size(144, 23);
            positionTextBox.TabIndex = 1;
            // 
            // nameTextBox
            // 
            nameTextBox.Enabled = false;
            nameTextBox.Location = new Point(1, 22);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(144, 23);
            nameTextBox.TabIndex = 0;
            // 
            // listSelectiongroupBox
            // 
            listSelectiongroupBox.Controls.Add(approvalRequestsSelectionButton);
            listSelectiongroupBox.Controls.Add(leaveRequestsSelectionButton);
            listSelectiongroupBox.Controls.Add(projectsSelectionButton);
            listSelectiongroupBox.Controls.Add(employeesSelectionButton);
            listSelectiongroupBox.Dock = DockStyle.Fill;
            listSelectiongroupBox.Location = new Point(3, 111);
            listSelectiongroupBox.Name = "listSelectiongroupBox";
            listSelectiongroupBox.Size = new Size(145, 437);
            listSelectiongroupBox.TabIndex = 1;
            listSelectiongroupBox.TabStop = false;
            listSelectiongroupBox.Text = "List Selection";
            listSelectiongroupBox.Enter += listSelectiongroupBox_Enter;
            // 
            // approvalRequestsSelectionButton
            // 
            approvalRequestsSelectionButton.Location = new Point(21, 266);
            approvalRequestsSelectionButton.Name = "approvalRequestsSelectionButton";
            approvalRequestsSelectionButton.Size = new Size(101, 23);
            approvalRequestsSelectionButton.TabIndex = 3;
            approvalRequestsSelectionButton.Text = "Approval Requests";
            approvalRequestsSelectionButton.UseVisualStyleBackColor = true;
            // 
            // leaveRequestsSelectionButton
            // 
            leaveRequestsSelectionButton.Location = new Point(21, 196);
            leaveRequestsSelectionButton.Name = "leaveRequestsSelectionButton";
            leaveRequestsSelectionButton.Size = new Size(101, 23);
            leaveRequestsSelectionButton.TabIndex = 2;
            leaveRequestsSelectionButton.Text = "Leave Requests";
            leaveRequestsSelectionButton.UseVisualStyleBackColor = true;
            // 
            // projectsSelectionButton
            // 
            projectsSelectionButton.Location = new Point(21, 130);
            projectsSelectionButton.Name = "projectsSelectionButton";
            projectsSelectionButton.Size = new Size(101, 23);
            projectsSelectionButton.TabIndex = 1;
            projectsSelectionButton.Text = "Projects";
            projectsSelectionButton.UseVisualStyleBackColor = true;
            projectsSelectionButton.Click += projectsSelectionButton_Click;
            // 
            // employeesSelectionButton
            // 
            employeesSelectionButton.Location = new Point(21, 61);
            employeesSelectionButton.Name = "employeesSelectionButton";
            employeesSelectionButton.Size = new Size(101, 23);
            employeesSelectionButton.TabIndex = 0;
            employeesSelectionButton.Text = "Employees";
            employeesSelectionButton.UseVisualStyleBackColor = true;
            employeesSelectionButton.Click += employeesSelectionButton_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(929, 563);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            Text = "Out of Office";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            infoGroupBox.ResumeLayout(false);
            infoGroupBox.PerformLayout();
            listSelectiongroupBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void SetSelectionListAvalibility()
        {

            bool[] avalibilities = AvalibilityHelper.SelectionListAvalibility(AuthorizationHelper.position);
            if (avalibilities.Length != selectionListButtons.Length)
            {
                throw new Exception($"amount of selection buttons isn't ${selectionListButtons.Length}");
            }
            for (int i = 0; i < selectionListButtons.Length; i++)
            {
                selectionListButtons[i].Enabled = avalibilities[i];
            }
        }

        private void SetInfo()
        {

            nameTextBox.Text = AuthorizationHelper.loggedInUser.FullName;
            positionTextBox.Text = AuthorizationHelper.loggedInUser.Position.ToString();

        }
        public MainForm(IServiceProvider serviceProvider)
        {

            _serviceProvider = serviceProvider;

            InitializeComponent();

            //set correct Enable state depending on user's position
            selectionListButtons = new Button[]
            {
                employeesSelectionButton,
                projectsSelectionButton,
                leaveRequestsSelectionButton,
                approvalRequestsSelectionButton
            };
            SetSelectionListAvalibility();

            //fill text boxes with info about the user
            SetInfo();



        }


        private void OpenForm<T>() where T : Form
        {
            var form = _serviceProvider.GetRequiredService<T>();
            form.Show();
        }

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox listSelectiongroupBox;
        private GroupBox infoGroupBox;
        public TextBox nameTextBox;
        public TextBox positionTextBox;
        private Button employeesSelectionButton;
        private Button approvalRequestsSelectionButton;
        private Button leaveRequestsSelectionButton;
        private Button projectsSelectionButton;

        private void employeesSelectionButton_Click(object sender, EventArgs e)
        {

        }

        private void listSelectiongroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void projectsSelectionButton_Click(object sender, EventArgs e)
        {
            ListForm form = new EmployeeListForm(_serviceProvider); //TODO fix
            ShowEmbeddedForm(form);

        }

        private void ShowEmbeddedForm(ListForm embeddedForm)
        {
            embeddedForm.TopLevel = false;
            embeddedForm.FormBorderStyle = FormBorderStyle.None;
            embeddedForm.Dock = DockStyle.Fill;

            tableLayoutPanel2.Controls.Add(embeddedForm, 1, 0);
            embeddedForm.Show();
        }
    }
}
