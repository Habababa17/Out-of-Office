using Out_of_Office.Data.IRepositories;
using Out_of_Office.Data.Repositories;
using Out_of_Office.Helpers;
using Out_of_Office.Helpers.Converters;
using Out_of_Office.Models.Dto_Models;
using Out_of_Office.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Services
{
    public class ApprovalRequestService : IApprovalRequestService
    {
        private IApprovalRequestRepository _approvalRequestRepository;
        private ILeaveRequestRepository _leaveRequestRepository;
        private IEmployeeProjectAssignmentRepository _employeeProjectAssignmentRepository;
        private IEmployeeRepository _employeeRepository;
        private IProjectRepository _projectRepository;
        public ApprovalRequestService(ILeaveRequestRepository leaveRequestRepository, IApprovalRequestRepository approvalRequestRepository,
            IEmployeeProjectAssignmentRepository employeeProjectAssignmentRepository, IProjectRepository projectRepository, IEmployeeRepository employeeRepository)
        {
            _employeeProjectAssignmentRepository = employeeProjectAssignmentRepository;
            _projectRepository = projectRepository;
            _leaveRequestRepository = leaveRequestRepository;
            _approvalRequestRepository = approvalRequestRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task AddApprovalRequestAsync(ApprovalRequestDto approvalRequest)
        {

            var leaveRequest = await _leaveRequestRepository.GetAsync(approvalRequest.LeaveRequest);

            //throw an exeption if balance isn't enough
            BalanceHelper.CheckBalance(leaveRequest.StartDate, leaveRequest.EndDate);


            //ADD aproval request
            //add new approval
            await _approvalRequestRepository.AddAsync(Helpers.Converters.ApprovalRequestConverter.ToModel(approvalRequest));

            //update leave 
            leaveRequest.Status = (int)approvalRequest.Status;
            await _leaveRequestRepository.UpdateAsync(leaveRequest);

            //update employee's balance
            var employee = await _employeeRepository.GetAsync(leaveRequest.Employee);
            employee.OutOfOfficeBalance = employee.OutOfOfficeBalance - (int)leaveRequest.EndDate.Subtract(leaveRequest.StartDate).Days;
            //await _employeeRepository.UpdateAsync(employee);


            //TODO cancel leave requests that do not have enough balance (after adding AR some LRs might be outdated)



        }

        public async Task<ApprovalRequestListDto> GetApprovalRequestsAsync(ApprovalRequestFiltersDto? filtersDto = null)
        {
            //HR all
            //Proj manager all from employees from his projects

            ApprovalRequestListDto approvalRequestsListDto = new ApprovalRequestListDto();

            //add old ApprovalRequests
            var approvalRequestsList = await _approvalRequestRepository.GetAllAsync();
            foreach (var ar in approvalRequestsList)
            {
                approvalRequestsListDto.ApprovalRequests.Add(ApprovalRequestConverter.ToDto(ar));
            }

            //generate new ApprovalRequests
            var leaveRequestsList = await _leaveRequestRepository.GetAllAsync();
            foreach (var lr in leaveRequestsList)
            {
                if (!approvalRequestsList.Any(e => e.LeaveRequest == lr.ID))
                {
                    approvalRequestsListDto.ApprovalRequests.Add(LeaveToApprovalConverter.ToDto(lr));
                }
            }


            return approvalRequestsListDto;
        }

        public async Task<ApprovalRequestListDto> GetManagersApprovalRequestsAsync(Guid userId)
        {
            ApprovalRequestListDto approvalRequestsListDto = new ApprovalRequestListDto();

            var approvalRequestsList = await _approvalRequestRepository.GetAllAsync();
            foreach (var ar in approvalRequestsList)
            {
                approvalRequestsListDto.ApprovalRequests.Add(ApprovalRequestConverter.ToDto(ar));
            }

            //get list of managed projects
            var managedProjects = (await _projectRepository.GetAllAsync()).Where(p => p.ProjectManager == userId).ToList();

            //get list of managed employees
            var managedEmployees = (await _employeeProjectAssignmentRepository.GetAllAsync())
                .Where(e => managedProjects.Select(mp => mp.ID).Contains(e.ProjectID))
                .Select(e => e.EmployeeID)
                .ToList();

            //get leave requests from managedEmployees 
            var leaveRequestsList = await _leaveRequestRepository.GetAllAsync();
            var leaveRequestsByManagedEmployees = leaveRequestsList
                .Where(lr => managedEmployees.Contains(lr.Employee))
                .ToList();

            //get final ApprovalRequests by managedEmployees
            var filteredApprovalRequests = approvalRequestsListDto.ApprovalRequests
                .Where(ar => leaveRequestsByManagedEmployees.Any(lr => lr.ID == ar.LeaveRequest))
                .ToList();

            approvalRequestsListDto.ApprovalRequests = filteredApprovalRequests;
            var managerRequests = await GetUsersApprovalRequestsAsync(userId);

            foreach (var ar in managerRequests.ApprovalRequests)
            {
                approvalRequestsListDto.ApprovalRequests.Add(ar);
            }
            return approvalRequestsListDto;
        }

        public async Task<ApprovalRequestListDto> GetUsersApprovalRequestsAsync(Guid userId)
        {
            var dto = new ApprovalRequestListDto();

            var leaveRequestsList = await _leaveRequestRepository.GetAllAsync();
            var userLeaveRequests = leaveRequestsList.Where(lr => lr.Employee == userId).ToList();


            var approvalRequestsList = await _approvalRequestRepository.GetAllAsync();
            var userApprovalRequests = approvalRequestsList
                .Where(ar => userLeaveRequests.Any(lr => lr.ID == ar.LeaveRequest))
                .ToList();

            foreach (var ar in userApprovalRequests)
            {
                dto.ApprovalRequests.Add(ApprovalRequestConverter.ToDto(ar));
            }

            return dto;
        }
    }
}
