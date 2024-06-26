﻿using Out_of_Office.Forms.Creators;
using Out_of_Office.Helpers;
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
    public partial class EmployeeControl : ControlForm
    {

        //protected int Creatorstate = 0; //0 indicates adding a new record to db

        public EmployeeControl(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            InitializeComponent();
            if (AuthorizationHelper.loggedInUser.Position == Models.Enums.PositionEnum.HRManager)
            {
                newButton.Enabled = true;
            }
            else
            {
                newButton.Enabled = false;
            }

        }
        protected override void newButton_Click(object sender, EventArgs e)
        {
            EmployeeCreatorForm leaveRequestForm = new EmployeeCreatorForm(_serviceProvider);
            leaveRequestForm.ShowDialog();
        }
    }
}
