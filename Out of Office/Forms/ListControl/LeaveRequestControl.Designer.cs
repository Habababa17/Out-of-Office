namespace Out_of_Office.Forms.ListControl
{
    partial class LeaveRequestControl
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
            newLeaveRequestButton = new Button();
            SuspendLayout();
            // 
            // newLeaveRequestButton
            // 
            newLeaveRequestButton.Location = new Point(21, 12);
            newLeaveRequestButton.Name = "newLeaveRequestButton";
            newLeaveRequestButton.Size = new Size(81, 23);
            newLeaveRequestButton.TabIndex = 0;
            newLeaveRequestButton.Text = "New";
            newLeaveRequestButton.UseVisualStyleBackColor = true;
            newLeaveRequestButton.Click += newLeaveRequestButton_Click;
            // 
            // LeaveRequestControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 186);
            Controls.Add(newLeaveRequestButton);
            Name = "LeaveRequestControl";
            Text = "LeaveRequestControl";
            ResumeLayout(false);
        }

        #endregion

        private Button newLeaveRequestButton;
    }
}