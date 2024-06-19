using Microsoft.Extensions.DependencyInjection;
using Out_of_Office.Helpers;
using Out_of_Office.Models.Dto_Models;
using Out_of_Office.Models.Enums;
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

namespace Out_of_Office.Forms.Creators
{
    public partial class LeaveRequestCreatorForm : Form
    {
        protected IServiceProvider _serviceProvider;
        protected int _state;
        protected LeaveRequestDto? _leaveRequestDto;
        public LeaveRequestCreatorForm(IServiceProvider serviceProvider, int state, LeaveRequestDto leaveRequestDto) : this(serviceProvider, state)
        {
            _leaveRequestDto = leaveRequestDto;
        }
        public LeaveRequestCreatorForm(IServiceProvider serviceProvider, int state)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _state = state;


            abscenceReasonComboBox.DataSource = Enum.GetValues(typeof(AbsenceReasonEnum));
            abscenceReasonComboBox.DisplayMember = "DisplayText";

        }

        private void AddLeaveRequest(LeaveRequestDto entity)
        {
            this._serviceProvider.GetRequiredService<ILeaveRequestService>().AddLeaveRequestAsync(entity);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ExceptionHelper.HandleException(() => AddorUpdateEntry(SubmitStateEnum.New), "Error with saving");
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            ExceptionHelper.HandleException(() => AddorUpdateEntry(SubmitStateEnum.Submitted), "Error with submiting");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ExceptionHelper.HandleException(() => AddorUpdateEntry(SubmitStateEnum.Canceled), "Error with canceling");
        }




        private async Task AddorUpdateEntry(SubmitStateEnum submitStateEnum) //this should be done by strategy d.p. and generic types
        {
            Enum.TryParse(abscenceReasonComboBox.SelectedItem.ToString(), out AbsenceReasonEnum selectedValue);


            LeaveRequestDto entity = new LeaveRequestDto()
            {
                ID = Guid.NewGuid(),
                Employee = Helpers.AuthorizationHelper.loggedInUser.ID,
                AbsenceReason = selectedValue,
                StartDate = startDateTime.Value,
                EndDate = endDateTime.Value,
                Comment = commentTextBox.Text,
                Status = submitStateEnum
            }; 
            switch (_state)
            {

                case 0: //add new Leave Request
                    if (submitStateEnum == SubmitStateEnum.Canceled)
                    {
                        return;
                    }

                    await _serviceProvider.GetRequiredService<ILeaveRequestService>().AddLeaveRequestAsync(entity);
                    break;
                case 1: //Update Leave Request
                    if (this._leaveRequestDto != null)
                    {
                        await _serviceProvider.GetRequiredService<ILeaveRequestService>().UpdateLeaveRequestAsync(_leaveRequestDto.ID,  entity);
                        _leaveRequestDto = null;
                    }
                    
                    break;
                default:
                    throw new Exception("incorect state of LeaveRequestCreatorForm");
            }
            Close();
        }

    }
}
