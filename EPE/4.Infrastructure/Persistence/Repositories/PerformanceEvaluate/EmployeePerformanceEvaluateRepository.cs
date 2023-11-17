using EPE.Application.Core.Abstractions;
using EPE.Application.Core.Infrastructure;
using EPE.Domain.PerformanceEvaluate.Aggregates;
using EPE.Infrastructure.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Infrastructure.Persistence.Repositories.PerformanceEvaluate
{
    public class EmployeePerformanceEvaluateRepository : Repository<EmployeePerformanceEvaluate, long>
        , IEmployeePerformanceEvaluateRepository
    {
        #region members
        private CommandDbContext _dbContext = default!;
        #endregion

        #region constractors
        public EmployeePerformanceEvaluateRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = unitOfWork.DbContext as CommandDbContext;
        }
        #endregion
    }
}
