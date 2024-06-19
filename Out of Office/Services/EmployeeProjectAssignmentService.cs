using Out_of_Office.Data.IRepositories;
using Out_of_Office.Models.DB_Models;
using Out_of_Office.Models.Dto_Models;
using Out_of_Office.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Services
{
    public class EmployeeProjectAssignmentService : IEmployeeProjectAssignmentService
    {
        IEmployeeProjectAssignmentRepository _employeeProjectAssignmentRepository;

        public EmployeeProjectAssignmentService(IEmployeeProjectAssignmentRepository employeeProjectAssignmentRepository)
        {
            _employeeProjectAssignmentRepository = employeeProjectAssignmentRepository;
        }
        public Task<EmployeeProjectAssignmentListDto> GetProjectAssignmentsAsync(Guid projectID)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProjectAssignments(EmployeeListDto assignedEmployees, EmployeeListDto unassignedEmployees, Guid projectID)
        {
            // Adding assignments
            foreach (var employee in assignedEmployees.Employees)
            {
                try
                {
                    var existingAssignment = await _employeeProjectAssignmentRepository.GetByIdAsync(projectID,employee.ID);
                    if (existingAssignment == null)
                        await _employeeProjectAssignmentRepository.AddAsync(
                        new EmployeeProjectAssignmentModel()
                        {
                            EmployeeID = employee.ID,
                            ProjectID = projectID,
                        }
                    );
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it as necessary
                    Console.WriteLine($"Failed to add assignment for employee {employee.ID}: {ex.Message}");
                }
            }
            //// Removing assignments
            foreach (var employee in unassignedEmployees.Employees)
            {
                try
                {
                    // var entity = await _employeeProjectAssignmentRepository
                    //    .GetByIdAsync(employee.ID, projectID);
                    var entities = await _employeeProjectAssignmentRepository.GetAllAsync();
                    var entity = entities.FirstOrDefault(e => (e.ProjectID == projectID && e.EmployeeID == employee.ID));
                    if (entity != null)
                    {
                        _employeeProjectAssignmentRepository.RemoveAsync(entity);
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it as necessary
                    Console.WriteLine($"Failed to remove assignment for employee {employee.ID}: {ex.Message}");
                }
            }

            //// Save all removed assignments
            //await _employeeProjectAssignmentRepository.SaveChangesAsync();
        }
    }
}

