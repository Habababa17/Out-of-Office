namespace Out_of_Office.Forms
{
    partial class FiltersForm
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
            searchButton = new Button();
            filterButton = new Button();
            searchTextBox = new RichTextBox();
            SuspendLayout();
            // 
            // searchButton
            // 
            searchButton.Location = new Point(458, 25);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(95, 23);
            searchButton.TabIndex = 0;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            // 
            // filterButton
            // 
            filterButton.Location = new Point(12, 25);
            filterButton.Name = "filterButton";
            filterButton.Size = new Size(93, 23);
            filterButton.TabIndex = 1;
            filterButton.Text = "Set Filters";
            filterButton.UseVisualStyleBackColor = true;
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(111, 26);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(341, 23);
            searchTextBox.TabIndex = 2;
            searchTextBox.Text = "";
            // 
            // FiltersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(565, 60);
            Controls.Add(searchTextBox);
            Controls.Add(filterButton);
            Controls.Add(searchButton);
            Name = "FiltersForm";
            Text = "FiltersForm";
            ResumeLayout(false);
        }

        #endregion

        private Button searchButton;
        private Button filterButton;
        private RichTextBox searchTextBox;
    }
}