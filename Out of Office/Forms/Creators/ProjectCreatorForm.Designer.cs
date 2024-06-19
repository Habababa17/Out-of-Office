namespace Out_of_Office.Forms.Creators
{
    partial class ProjectCreatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            nameTextBox = new TextBox();
            projectTypeComboBox = new ComboBox();
            startTimePicker = new DateTimePicker();
            endTimePicker = new DateTimePicker();
            commentTextBox = new RichTextBox();
            statusComboBox = new ComboBox();
            saveButton = new Button();
            cancelButton = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            managerComboBox = new ComboBox();
            seeEmployeesButton = new Button();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(93, 9);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(200, 23);
            nameTextBox.TabIndex = 0;
            // 
            // projectTypeComboBox
            // 
            projectTypeComboBox.FormattingEnabled = true;
            projectTypeComboBox.Location = new Point(350, 82);
            projectTypeComboBox.Name = "projectTypeComboBox";
            projectTypeComboBox.Size = new Size(200, 23);
            projectTypeComboBox.TabIndex = 1;
            // 
            // startTimePicker
            // 
            startTimePicker.Location = new Point(93, 82);
            startTimePicker.Name = "startTimePicker";
            startTimePicker.Size = new Size(200, 23);
            startTimePicker.TabIndex = 2;
            // 
            // endTimePicker
            // 
            endTimePicker.Location = new Point(93, 122);
            endTimePicker.Name = "endTimePicker";
            endTimePicker.Size = new Size(200, 23);
            endTimePicker.TabIndex = 3;
            // 
            // commentTextBox
            // 
            commentTextBox.Location = new Point(93, 162);
            commentTextBox.Name = "commentTextBox";
            commentTextBox.Size = new Size(457, 86);
            commentTextBox.TabIndex = 5;
            commentTextBox.Text = "";
            // 
            // statusComboBox
            // 
            statusComboBox.FormattingEnabled = true;
            statusComboBox.Location = new Point(350, 122);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.Size = new Size(200, 23);
            statusComboBox.TabIndex = 6;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(475, 267);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 7;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(378, 267);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 8;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Control;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.ForeColor = SystemColors.ActiveCaptionText;
            textBox1.Location = new Point(12, 47);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(75, 16);
            textBox1.TabIndex = 9;
            textBox1.Text = "Managed by:";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Control;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.ForeColor = SystemColors.ActiveCaptionText;
            textBox2.Location = new Point(12, 12);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(48, 16);
            textBox2.TabIndex = 10;
            textBox2.Text = "Project:";
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.Control;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.ForeColor = SystemColors.ActiveCaptionText;
            textBox3.Location = new Point(12, 88);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(62, 16);
            textBox3.TabIndex = 11;
            textBox3.Text = "Start Date:";
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.Control;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.ForeColor = SystemColors.ActiveCaptionText;
            textBox4.Location = new Point(12, 124);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(62, 16);
            textBox4.TabIndex = 12;
            textBox4.Text = "End Date:";
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.Control;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.ForeColor = SystemColors.ActiveCaptionText;
            textBox5.Location = new Point(305, 85);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(39, 16);
            textBox5.TabIndex = 13;
            textBox5.Text = "Status:";
            // 
            // textBox6
            // 
            textBox6.BackColor = SystemColors.Control;
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.ForeColor = SystemColors.ActiveCaptionText;
            textBox6.Location = new Point(305, 124);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(39, 16);
            textBox6.TabIndex = 14;
            textBox6.Text = "Type:";
            // 
            // textBox7
            // 
            textBox7.BackColor = SystemColors.Control;
            textBox7.BorderStyle = BorderStyle.None;
            textBox7.ForeColor = SystemColors.ActiveCaptionText;
            textBox7.Location = new Point(12, 165);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(75, 16);
            textBox7.TabIndex = 15;
            textBox7.Text = "Comment:";
            // 
            // managerComboBox
            // 
            managerComboBox.FormattingEnabled = true;
            managerComboBox.Location = new Point(93, 44);
            managerComboBox.Name = "managerComboBox";
            managerComboBox.Size = new Size(200, 23);
            managerComboBox.TabIndex = 16;
            // 
            // seeEmployeesButton
            // 
            seeEmployeesButton.Location = new Point(93, 267);
            seeEmployeesButton.Name = "seeEmployeesButton";
            seeEmployeesButton.Size = new Size(166, 23);
            seeEmployeesButton.TabIndex = 17;
            seeEmployeesButton.Text = "See Employees On Project";
            seeEmployeesButton.UseVisualStyleBackColor = true;
            seeEmployeesButton.Click += seeEmployeesButton_Click;
            // 
            // ProjectCreatorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(558, 306);
            Controls.Add(seeEmployeesButton);
            Controls.Add(managerComboBox);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(statusComboBox);
            Controls.Add(commentTextBox);
            Controls.Add(endTimePicker);
            Controls.Add(startTimePicker);
            Controls.Add(projectTypeComboBox);
            Controls.Add(nameTextBox);
            Name = "ProjectCreatorForm";
            Text = "ProjectCreatorForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameTextBox;
        private ComboBox projectTypeComboBox;
        private DateTimePicker startTimePicker;
        private DateTimePicker endTimePicker;
        private RichTextBox commentTextBox;
        private ComboBox statusComboBox;
        private Button saveButton;
        private Button cancelButton;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private ComboBox managerComboBox;
        private Button seeEmployeesButton;
    }
}