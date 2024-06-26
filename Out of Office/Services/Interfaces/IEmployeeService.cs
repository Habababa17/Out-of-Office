﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Out_of_Office.Models.Dto_Models;
using Out_of_Office.Models.DB_Models;
using Out_of_Office.Models.Enums;

namespace Out_of_Office.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<EmployeeListDto> GetUsersAsync(EmployeeFiltersDto? filtersDto = null);
        public Task<EmployeeListDto> GetEmployeesAsync(EmployeeFiltersDto? filtersDto = null);
        public Task<EmployeeListDto> GetEmployeesOnProjectAsync(Guid projectID, EmployeeFiltersDto? filtersDto = null);
        public Task AddEmployeeAsync(EmployeeDto employeeDto);
        public Task<EmployeeListDto> GetUsersFromProjectsAsync(Guid managerId);
        public Task UpdateEmployeeAsync(EmployeeDto employeeDto);
        public Task ChangeEmployeeStatusAsync(Guid id, StatusEnum status);
        public Task AssignEmployeeAsync(Guid EmployeeID, Guid ProjectID);
        public Task<EmployeeDto> GetEmployeeAsync(Guid EmployeeID);
    }
}
