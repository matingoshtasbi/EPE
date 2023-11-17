using EPE.Application.Core.Abstractions;
using EPE.Application.Core.Infrastructure;
using EPE.Domain.EmployeeManagement.Aggregates;
using EPE.Infrastructure.Persistence.DbContexts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Infrastructure.Persistence.Repositories.EmployeeManagement
{
    public class EmployeeRepository : Repository<Employee, Guid>, IEmployeeRepository
    {
        #region members
        private CommandDbContext _dbContext = default!;
        #endregion

        #region constractors
        public EmployeeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = unitOfWork.DbContext as CommandDbContext;
        }
        #endregion
    }
}
