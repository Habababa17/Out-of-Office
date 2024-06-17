using Microsoft.Extensions.DependencyInjection;
using Out_of_Office.Forms.Creators;
using Out_of_Office.Models.Dto_Models;
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

namespace Out_of_Office.Forms.ListControl
{
    public partial class LeaveRequestControl : Form
    {
        protected int Creatorstate = 0; //0 indicates adding a new record to db

        protected IServiceProvider _serviceProvider;
        public LeaveRequestControl(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        private void newLeaveRequestButton_Click(object sender, EventArgs e)
        {
            LeaveRequestCreatorForm leaveRequestForm = new LeaveRequestCreatorForm(_serviceProvider, Creatorstate);
            leaveRequestForm.ShowDialog();

        }





    }
}
