using EPE.Application.Core.DTOs;
using EPE.Application.Abstractions.EmployeeManagement;
using EPE.Application.DTOs.EmployeeManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPE.Domain.EmployeeManagement.Aggregates;
using EPE.Infrastructure.SqlServer.DbContexts;

namespace EPE.Application.Services.EmployeeManagement
{
    public class EmployeeQueryService : IEmployeeQueryService
    {
        #region members
        private readonly SqlServerCommandDbContext _dbContext;
        #endregion

        #region constractors
        public EmployeeQueryService(SqlServerCommandDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region public methods

        public async Task<PageResult<Employee>> FindEmployees()
        {
            var result = new PageResult<Employee>();

            try
            {
                var qry = _dbContext.Employees.AsNoTracking();
                result.TotalCount = await qry.CountAsync();
                result.Results = await qry.ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Employee> FindEmployee(Guid id)
        {
            var result = await _dbContext.Employees
                 .AsNoTracking()
                 .Include(nameof(Employee.Contacts))
                 .Include(nameof(Employee.Educations))
                 .Include(nameof(Employee.PhysicalInfo))
                 .Include(nameof(Employee.Resume))
                 .FirstOrDefaultAsync(c => c.Id == id) ?? null!;
            return result;
        }

        #endregion
    }
}
