namespace Out_of_Office.Forms.ListControl
{
    partial class ControlForm
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
            newButton = new Button();
            SuspendLayout();
            // 
            // newButton
            // 
            newButton.Location = new Point(21, 12);
            newButton.Name = "newButton";
            newButton.Size = new Size(81, 23);
            newButton.TabIndex = 0;
            newButton.Text = "New";
            newButton.UseVisualStyleBackColor = true;
            newButton.Click += newButton_Click;
            // 
            // ControlForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 66);
            Controls.Add(newButton);
            Name = "ControlForm";
            Text = "LeaveRequestControl";
            ResumeLayout(false);
        }

        #endregion

        protected Button newButton;
    }
}