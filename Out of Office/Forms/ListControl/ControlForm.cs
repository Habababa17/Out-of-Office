using Out_of_Office.Forms.Creators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Out_of_Office.Forms.ListControl
{
    public abstract partial class ControlForm : Form
    {

        protected IServiceProvider _serviceProvider;
        public ControlForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }
        protected abstract void newButton_Click(object sender, EventArgs e);
    }
}
