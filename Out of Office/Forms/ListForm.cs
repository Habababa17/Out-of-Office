using Microsoft.Extensions.DependencyInjection;
using Out_of_Office.Forms.Interfaces;
using Out_of_Office.Models.Dto_Models;
using Out_of_Office.Services;
using Out_of_Office.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Out_of_Office.Forms
{
    // partial class ListForm
    public abstract partial class ListForm<T, F> 
        : Form, IListForm where F : Filter<T>
    {
        protected IServiceProvider _serviceProvider;
        //protected List<EmployeeDto> collection;
        protected List<T> collection;
        private string currentSortColumn;
        private SortOrder currentSortOrder;
        private Form currentControlForm;
        private FilterForm<T, F> filterForm;
        public ListForm()
        {
            InitializeComponent();
        }
        public ListForm(List<T> collection)
        {
            this.collection = collection;
        }
        public ListForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            InitializeComponent();
        }

        protected override async void OnLoad(EventArgs e)
        {
            await InitializeAsync();
            UpdateUI();
        }
        public virtual async Task InitializeAsync()
        {
            throw new Exception("List Form class wrong usage");
            //collection = (await _serviceProvider.GetRequiredService<IEmployeeService>().GetUsersAsync()).Employees;
        }
        protected void UpdateUI(List<T> newCollection = null)
        {
            
            if (newCollection != null)
            {
                collection = newCollection;
            }
            dataGrid.DataSource = null;
            dataGrid.DataSource = collection;
        }

        public void dataGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Determine which column was clicked and get its property name
            string propertyName = dataGrid.Columns[e.ColumnIndex].DataPropertyName;

            // Toggle sort direction if same column is clicked
            if (propertyName.Equals(currentSortColumn, StringComparison.OrdinalIgnoreCase))
            {
                currentSortOrder = (currentSortOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                currentSortColumn = propertyName;
                currentSortOrder = SortOrder.Ascending;
            }

            // Sort the DataGridView by the selected column
            SortDataGrid(propertyName, currentSortOrder);
        }
        public void SortDataGrid(string propertyName, SortOrder sortOrder)
        {
            // Get the property info of the specified property name
            var prop = typeof(T).GetProperty(propertyName);
            //var prop = typeof(EmployeeDto).GetProperty(propertyName);


            // Sort the list based on the selected property and sort order using LINQ
            if (sortOrder == SortOrder.Ascending)
            {
                collection = collection.OrderBy(e => prop.GetValue(e, null)).ToList();
            }
            else
            {
                collection = collection.OrderByDescending(e => prop.GetValue(e, null)).ToList();

            }

            // Update current sort column and order
            currentSortColumn = propertyName;
            currentSortOrder = sortOrder;

            // Rebind the sorted list to the DataGridView
            dataGrid.DataSource = null;
            dataGrid.DataSource = collection;
        }

        protected void ShowFilterForm(FilterForm<T, F> form)
        {
            if (filterForm != null)
            {
                groupBox1.Controls.Remove(filterForm);
                filterForm.Dispose();
            }
            filterForm = form;


            filterForm.TopLevel = false;
            filterForm.FormBorderStyle = FormBorderStyle.None;
            filterForm.Dock = DockStyle.Fill;

            groupBox1.Controls.Add(filterForm);
            filterForm.Show();
        }
        protected void ShowEmbeddedForm(Form embeddedForm)
        {
            //remove the previously added list form if it exists
            if (currentControlForm != null)
            {
                
                tableLayoutPanel1.Controls.Remove(currentControlForm);
                currentControlForm.Dispose();
            }
            currentControlForm = embeddedForm;

            //add new list form
            embeddedForm.TopLevel = false;
            embeddedForm.FormBorderStyle = FormBorderStyle.None;
            embeddedForm.Dock = DockStyle.Fill;

            tableLayoutPanel1.Controls.Add(embeddedForm, 0, 2);
            embeddedForm.Show();
        }
        public abstract void DataGrid_RowHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e);
    }
}
