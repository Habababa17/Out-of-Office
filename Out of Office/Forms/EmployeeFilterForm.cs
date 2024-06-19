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
    public partial class EmployeeFilterForm : FilterForm<EmployeeDto, EmployeeFiltersDto>
    {
        public EmployeeFilterForm(List<EmployeeDto> dtos, EmployeeFiltersDto filters) : base(dtos, filters) 
        {
            //InitializeComponent();
        }
        protected override void setButton_Click(object sender, EventArgs e)
        {
            new EmployeeCreatorForm(ref _filters).ShowDialog();

        }
    }
}
