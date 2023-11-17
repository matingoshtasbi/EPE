using EPE.Application.Core.DTOs;
using EPE.Application.DTOs.EmployeeManagement;
using EPE.Domain.EmployeeManagement.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.Abstractions.EmployeeManagement
{
    public interface IEmployeeQueryService
    {
        Task<PageResult<Employee>> FindEmployees();
        Task<Employee> FindEmployee(Guid id);
    }
}
