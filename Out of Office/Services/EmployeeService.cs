using Out_of_Office.Data.IRepositories;
using Out_of_Office.Models.Dto_Models;
using Out_of_Office.Models.Enums;
using Out_of_Office.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Out_of_Office.Helpers.Converters;
using Out_of_Office.DB_Models;
using Out_of_Office.Data.Repositories;
using Out_of_Office.Helpers;

namespace Out_of_Office.Services
{
    internal class EmployeeService : IEmployeeService, ISearchService<EmployeeListDto, EmployeeFiltersDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeProjectAssignmentRepository _employeeProjectAssignmentRepository;
        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeProjectAssignmentRepository employeeProjectAssignmentRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeProjectAssignmentRepository = employeeProjectAssignmentRepository;
        }
        public async Task AddEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = Helpers.Converters.EmployeeConverter.ToModel(employeeDto);
            await _employeeRepository.AddAsync(employee);
        }

        public Task AssignEmployeeAsync(Guid EmployeeID, Guid projectID)
        {
            throw new NotImplementedException();
        }

        public Task ChangeEmployeeStatusAsync(Guid id, StatusEnum status)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeDto> GetEmployeeAsync(Guid employeeID)
        {
            EmployeeModel? emp = await _employeeRepository.GetAsync(employeeID);
            if (emp == null)
            {
                throw new NullReferenceException("Employee null");
            }
            return Helpers.Converters.EmployeeConverter.ToDto(emp);
        }

        public async Task<EmployeeListDto> GetEmployeesAsync(EmployeeFiltersDto? filtersDto = null)
        {
            var employeeList = await _employeeRepository.GetAllAsync();
            EmployeeListDto employeeListDto = new EmployeeListDto();
            foreach (var emp in employeeList)
                if (emp.Position == (int)PositionEnum.Employee)
                    employeeListDto.Employees.Add(EmployeeConverter.ToDto(emp));
            return employeeListDto;
        }

        public async Task<EmployeeListDto> GetEmployeesOnProjectAsync(Guid projectID, EmployeeFiltersDto? filtersDto = null)
        {
            var employeeList = await _employeeRepository.GetAllAsync();
            EmployeeListDto employeeListDto = new EmployeeListDto();
            
            //get employees on the project
            var projectAssignments = await _employeeProjectAssignmentRepository.GetAllAsync();
            var employeesOnProject = projectAssignments.Where(e => e.ProjectID == projectID).Select(e => e.EmployeeID);

            //filter employee List to only get employees on the project
            employeeList = employeeList.Where(e => employeesOnProject.Any(p => p == e.ID));


            foreach (var emp in employeeList)
                if (emp.Position == (int)PositionEnum.Employee)
                    employeeListDto.Employees.Add(EmployeeConverter.ToDto(emp));
            return employeeListDto;
        }

        public async Task<EmployeeListDto> GetUsersAsync(EmployeeFiltersDto? filtersDto = null)
        {
             var employeeList = await _employeeRepository.GetAllAsync();
            EmployeeListDto employeeListDto = new EmployeeListDto();
            foreach(var emp in employeeList) 
                employeeListDto.Employees.Add(EmployeeConverter.ToDto(emp));
            return employeeListDto;
        }
        
        public IQueryable<EmployeeListDto> Search(IQueryable<EmployeeListDto> collection, EmployeeFiltersDto filter, string searchString)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateEmployeeAsync(EmployeeDto employeeDto)
        {
            var model = await _employeeRepository.GetAsync(employeeDto.ID);
            model.Position = (int)PositionEnum.Employee;
            model.FullName = employeeDto.FullName;
            model.OutOfOfficeBalance = employeeDto.OutOfOfficeBalance;
            model.PeoplePartner = employeeDto.PeoplePartner;
            model.Photo = employeeDto.Photo;
            model.Status = (int)employeeDto.Status;
            model.Subdivision = (int)employeeDto.Subdivision;
            await _employeeRepository.UpdateAsync(model);
        }
    }
}
