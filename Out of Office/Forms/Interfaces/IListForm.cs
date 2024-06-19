using Out_of_Office.Models.Dto_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Forms.Interfaces
{
    public interface IListForm 
    {
        public void dataGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e);
        public void SortDataGrid(string propertyName, SortOrder sortOrder);
        protected abstract void DataGrid_RowHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e);
        public abstract Task InitializeAsync();
    }
}
