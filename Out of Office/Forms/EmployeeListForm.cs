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
    public partial class EmployeeListForm : ListForm
    {

        public EmployeeListForm() : base() { }

        public EmployeeListForm(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            
        }
    }
}
