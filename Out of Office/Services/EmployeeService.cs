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

namespace Out_of_Office.Services
{
    internal class EmployeeService : IEmployeeService, ISearchService<EmployeeListDto, EmployeeFiltersDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public Task AddEmployeeAsync(EmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }

        public Task AssignEmployeeAsync(Guid EmployeeID, Guid ProjectID)
        {
            throw new NotImplementedException();
        }

        public Task ChangeEmployeeStatusAsync(Guid id, StatusEnum status)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeListDto> GetUsersAsync(EmployeeFiltersDto? filtersDto = null)
        {
             var employeeList = await _employeeRepository.GetAllAsync();
            EmployeeListDto employeeListDto = new EmployeeListDto();
            foreach(var emp in  employeeList) 
                employeeListDto.Employees.Add(EmployeeConverter.ToDto(emp));
            return employeeListDto;
        }

        public IQueryable<EmployeeListDto> Search(IQueryable<EmployeeListDto> collection, EmployeeFiltersDto filter, string searchString)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployeeAsync(EmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }
    }
}
