namespace Out_of_Office.Forms.InfoForms
{
    partial class LeaveRequestInfoForm
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
            requesterNameTextBox = new TextBox();
            reasonTextBox = new TextBox();
            startDateTextBox = new TextBox();
            endDateTextBox = new TextBox();
            commentTextBox = new RichTextBox();
            ConfirmButton = new Button();
            denyButton = new Button();
            approverCommentBox = new RichTextBox();
            SuspendLayout();
            // 
            // requesterNameTextBox
            // 
            requesterNameTextBox.Enabled = false;
            requesterNameTextBox.Location = new Point(12, 37);
            requesterNameTextBox.Name = "requesterNameTextBox";
            requesterNameTextBox.Size = new Size(120, 23);
            requesterNameTextBox.TabIndex = 0;
            requesterNameTextBox.TextChanged += textBox1_TextChanged;
            // 
            // reasonTextBox
            // 
            reasonTextBox.Enabled = false;
            reasonTextBox.Location = new Point(138, 37);
            reasonTextBox.Name = "reasonTextBox";
            reasonTextBox.Size = new Size(115, 23);
            reasonTextBox.TabIndex = 1;
            // 
            // startDateTextBox
            // 
            startDateTextBox.Enabled = false;
            startDateTextBox.Location = new Point(12, 97);
            startDateTextBox.Name = "startDateTextBox";
            startDateTextBox.Size = new Size(120, 23);
            startDateTextBox.TabIndex = 2;
            // 
            // endDateTextBox
            // 
            endDateTextBox.Enabled = false;
            endDateTextBox.Location = new Point(138, 97);
            endDateTextBox.Name = "endDateTextBox";
            endDateTextBox.Size = new Size(115, 23);
            endDateTextBox.TabIndex = 3;
            // 
            // commentTextBox
            // 
            commentTextBox.Enabled = false;
            commentTextBox.Location = new Point(12, 144);
            commentTextBox.Name = "commentTextBox";
            commentTextBox.Size = new Size(241, 113);
            commentTextBox.TabIndex = 4;
            commentTextBox.Text = "";
            // 
            // ConfirmButton
            // 
            ConfirmButton.Location = new Point(330, 217);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.Size = new Size(75, 23);
            ConfirmButton.TabIndex = 5;
            ConfirmButton.Text = "Confirm";
            ConfirmButton.UseVisualStyleBackColor = true;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // denyButton
            // 
            denyButton.Location = new Point(450, 217);
            denyButton.Name = "denyButton";
            denyButton.Size = new Size(75, 23);
            denyButton.TabIndex = 6;
            denyButton.Text = "Deny";
            denyButton.UseVisualStyleBackColor = true;
            denyButton.Click += denyButton_Click;
            // 
            // approverCommentBox
            // 
            approverCommentBox.Location = new Point(321, 24);
            approverCommentBox.Name = "approverCommentBox";
            approverCommentBox.Size = new Size(232, 170);
            approverCommentBox.TabIndex = 7;
            approverCommentBox.Text = "Add a coment...";
            approverCommentBox.TextChanged += approverCommentBox_TextChanged;
            // 
            // LeaveRequestInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(568, 274);
            Controls.Add(approverCommentBox);
            Controls.Add(denyButton);
            Controls.Add(ConfirmButton);
            Controls.Add(commentTextBox);
            Controls.Add(endDateTextBox);
            Controls.Add(startDateTextBox);
            Controls.Add(reasonTextBox);
            Controls.Add(requesterNameTextBox);
            Name = "LeaveRequestInfoForm";
            Text = "LeaveRequestInfoForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox requesterNameTextBox;
        private TextBox reasonTextBox;
        private TextBox startDateTextBox;
        private TextBox endDateTextBox;
        private RichTextBox commentTextBox;
        private Button ConfirmButton;
        private Button denyButton;
        private RichTextBox approverCommentBox;
    }
}