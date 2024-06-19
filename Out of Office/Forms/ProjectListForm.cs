using Microsoft.Extensions.DependencyInjection;
using Out_of_Office.Forms.Creators;
using Out_of_Office.Forms.ListControl;
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

namespace Out_of_Office.Forms
{
    public partial class ProjectListForm : ListForm<ProjectDto, ProjectFiltersDto>
    {

        public ProjectListForm() : base() { }
        public ProjectListForm(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            dataGrid.RowHeaderMouseClick += DataGrid_RowHeaderMouseClick;
            ShowEmbeddedForm(new ProjectControl(_serviceProvider));
        }

        public override void DataGrid_RowHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            //get selected leave request to update
            var selectedProject = (ProjectDto)dataGrid.Rows[e.RowIndex].DataBoundItem;

            ProjectCreatorForm leaveRequestForm = new ProjectCreatorForm(_serviceProvider, selectedProject);

            leaveRequestForm.ShowDialog();
        }

        public override async Task InitializeAsync()
        {
            collection = (await this._serviceProvider.GetRequiredService<IProjectService>().GetProjectsAsync()).projects;
        }




    }
}
