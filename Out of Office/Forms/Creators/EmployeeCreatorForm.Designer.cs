namespace Out_of_Office.Forms.Creators
{
    partial class EmployeeCreatorForm 
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
            subdivisionComboBox = new ComboBox();
            positionComboBox = new ComboBox();
            statusComboBox = new ComboBox();
            pictureBox = new PictureBox();
            SaveButton = new Button();
            cancelButton = new Button();
            partnerComboBox = new ComboBox();
            balanceTextBox = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)balanceTextBox).BeginInit();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(258, 172);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(152, 23);
            nameTextBox.TabIndex = 0;
            // 
            // subdivisionComboBox
            // 
            subdivisionComboBox.FormattingEnabled = true;
            subdivisionComboBox.Location = new Point(113, 12);
            subdivisionComboBox.Name = "subdivisionComboBox";
            subdivisionComboBox.Size = new Size(121, 23);
            subdivisionComboBox.TabIndex = 1;
            // 
            // positionComboBox
            // 
            positionComboBox.FormattingEnabled = true;
            positionComboBox.Location = new Point(113, 60);
            positionComboBox.Name = "positionComboBox";
            positionComboBox.Size = new Size(121, 23);
            positionComboBox.TabIndex = 2;
            // 
            // statusComboBox
            // 
            statusComboBox.FormattingEnabled = true;
            statusComboBox.Location = new Point(113, 109);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.Size = new Size(121, 23);
            statusComboBox.TabIndex = 3;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(258, 12);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(152, 143);
            pictureBox.TabIndex = 6;
            pictureBox.TabStop = false;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(339, 207);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(71, 23);
            SaveButton.TabIndex = 7;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(258, 207);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 8;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // partnerComboBox
            // 
            partnerComboBox.FormattingEnabled = true;
            partnerComboBox.Location = new Point(113, 160);
            partnerComboBox.Name = "partnerComboBox";
            partnerComboBox.Size = new Size(121, 23);
            partnerComboBox.TabIndex = 9;
            // 
            // balanceTextBox
            // 
            balanceTextBox.Location = new Point(113, 207);
            balanceTextBox.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            balanceTextBox.Name = "balanceTextBox";
            balanceTextBox.Size = new Size(120, 23);
            balanceTextBox.TabIndex = 10;
            balanceTextBox.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // EmployeeCreatorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 242);
            Controls.Add(balanceTextBox);
            Controls.Add(partnerComboBox);
            Controls.Add(cancelButton);
            Controls.Add(SaveButton);
            Controls.Add(pictureBox);
            Controls.Add(statusComboBox);
            Controls.Add(positionComboBox);
            Controls.Add(subdivisionComboBox);
            Controls.Add(nameTextBox);
            Name = "EmployeeCreatorForm";
            Text = "EmployeeCreatorForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)balanceTextBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameTextBox;
        private ComboBox subdivisionComboBox;
        private ComboBox positionComboBox;
        private ComboBox statusComboBox;
        private PictureBox pictureBox;
        private Button SaveButton;
        private Button cancelButton;
        private ComboBox partnerComboBox;
        private NumericUpDown balanceTextBox;
    }
}