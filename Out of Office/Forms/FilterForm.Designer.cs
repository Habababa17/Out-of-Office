namespace Out_of_Office.Forms
{
    partial class FilterForm<T, F>
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
            textBox1 = new TextBox();
            setButton = new Button();
            searchButton = new Button();
            resetButton = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(232, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(277, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // setButton
            // 
            setButton.Location = new Point(12, 11);
            setButton.Name = "setButton";
            setButton.Size = new Size(104, 23);
            setButton.TabIndex = 1;
            setButton.Text = "Set Filters";
            setButton.UseVisualStyleBackColor = true;
            setButton.Click += setButton_Click;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(515, 11);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(75, 24);
            searchButton.TabIndex = 2;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // resetButton
            // 
            resetButton.Location = new Point(122, 11);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(104, 24);
            resetButton.TabIndex = 3;
            resetButton.Text = "Reset Filters";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // FilterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(602, 40);
            Controls.Add(resetButton);
            Controls.Add(searchButton);
            Controls.Add(setButton);
            Controls.Add(textBox1);
            Name = "FilterForm";
            Text = "FilterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button setButton;
        private Button searchButton;
        private Button resetButton;
    }
}