using Out_of_Office.Forms.Creators;
using Out_of_Office.Models.Dto_Models;
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
    public partial class EmployeeListFromCollectionForm : EmployeeListForm
    {
        Action<Guid> _onClick;
        public EmployeeListFromCollectionForm()
        {
            InitializeComponent();
        }
        public EmployeeListFromCollectionForm(List<EmployeeDto> employees, Action<Guid> action) : base()
        {
            _onClick = action;
            collection = employees;
            dataGrid.RowHeaderMouseClick += DataGrid_RowHeaderMouseClick; // 
        }
        public override async Task InitializeAsync()
        {
            
        }
        protected override async void OnLoad(EventArgs e)
        {
            UpdateUI();
        }
        public override void DataGrid_RowHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            var x = collection.Count;
            var selectedEmployee = (EmployeeDto)dataGrid.Rows[e.RowIndex].DataBoundItem;
            _onClick(selectedEmployee.ID);
            UpdateUI();
        }
        public void SetCollection(List<EmployeeDto> employees)
        {
            collection = employees;
            UpdateUI();
        }

    }
}
