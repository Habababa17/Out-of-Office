using Out_of_Office.Forms.Creators;
using Out_of_Office.Models.Dto_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Out_of_Office.Forms
{
    public partial class EmployeeFilterForm : FilterForm<EmployeeDto, EmployeeFiltersDto>
    {
        public EmployeeFilterForm(ref List<EmployeeDto> dtos, EmployeeFiltersDto filters, Action<List<EmployeeDto>> action) : base(ref dtos, filters, action) 
        {
            //InitializeComponent();
        }
        protected override void setButton_Click(object sender, EventArgs e)
        {
            new EmployeeCreatorForm(ref _filters).ShowDialog();
            _filteredCollection = _filters.Filtrate(_collection);
            update(_filteredCollection);
        }

        protected override void textBox1_TextChanged(object sender, EventArgs e)
        {
            _filters.amountOfRows = (int)textBox1.Value;
            _filteredCollection = _filters.Filtrate(_collection);
            update(_filteredCollection);
        }


    }
}
