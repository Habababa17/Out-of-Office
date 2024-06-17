namespace Out_of_Office.Forms.Creators
{
    partial class LeaveRequestCreatorForm
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
            abscenceReasonComboBox = new ComboBox();
            startDateTime = new DateTimePicker();
            endDateTime = new DateTimePicker();
            saveButton = new Button();
            submitButton = new Button();
            cancelButton = new Button();
            commentTextBox = new RichTextBox();
            SuspendLayout();
            // 
            // abscenceReasonComboBox
            // 
            abscenceReasonComboBox.FormattingEnabled = true;
            abscenceReasonComboBox.Location = new Point(12, 45);
            abscenceReasonComboBox.Name = "abscenceReasonComboBox";
            abscenceReasonComboBox.Size = new Size(121, 23);
            abscenceReasonComboBox.TabIndex = 0;
            // 
            // startDateTime
            // 
            startDateTime.Location = new Point(139, 45);
            startDateTime.Name = "startDateTime";
            startDateTime.Size = new Size(199, 23);
            startDateTime.TabIndex = 1;
            // 
            // endDateTime
            // 
            endDateTime.Location = new Point(344, 45);
            endDateTime.Name = "endDateTime";
            endDateTime.Size = new Size(200, 23);
            endDateTime.TabIndex = 2;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(552, 97);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 3;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // submitButton
            // 
            submitButton.Location = new Point(633, 97);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(75, 23);
            submitButton.TabIndex = 4;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(714, 97);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // commentTextBox
            // 
            commentTextBox.Location = new Point(564, 12);
            commentTextBox.Name = "commentTextBox";
            commentTextBox.Size = new Size(225, 79);
            commentTextBox.TabIndex = 6;
            commentTextBox.Text = "";
            // 
            // LeaveRequestCreatorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(812, 132);
            Controls.Add(commentTextBox);
            Controls.Add(cancelButton);
            Controls.Add(submitButton);
            Controls.Add(saveButton);
            Controls.Add(endDateTime);
            Controls.Add(startDateTime);
            Controls.Add(abscenceReasonComboBox);
            Name = "LeaveRequestCreatorForm";
            Text = "LeaveRequestCreatorForm";
            ResumeLayout(false);
        }

        #endregion

        private ComboBox abscenceReasonComboBox;
        private DateTimePicker startDateTime;
        private DateTimePicker endDateTime;
        private Button saveButton;
        private Button submitButton;
        private Button cancelButton;
        private RichTextBox commentTextBox;
    }
}