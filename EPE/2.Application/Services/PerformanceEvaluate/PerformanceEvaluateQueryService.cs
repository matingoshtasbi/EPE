using EPE.Application.Abstractions.PerformanceEvaluate;
using EPE.Application.Core.DTOs;
using EPE.Domain.PerformanceEvaluate.Aggregates;
using EPE.Infrastructure.SqlServer.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.Services.PerformanceEvaluate
{
    public class PerformanceEvaluateQueryService : IPerformanceEvaluateQueryService
    {
        #region members
        private readonly SqlServerCommandDbContext _dbContext;
        #endregion

        #region constarcator
        public PerformanceEvaluateQueryService(SqlServerCommandDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region public methods
        public async Task<PageResult<EmployeePerformanceEvaluate>> FindEPEs()
        {
            var result = new PageResult<EmployeePerformanceEvaluate>();

            try
            {
                var qry = _dbContext.EmployeePerformanceEvaluates.AsNoTracking();
                result.TotalCount = await qry.CountAsync();
                result.Results = await qry.ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<EmployeePerformanceEvaluate> FindEPE(long id)
        {
            var result = await _dbContext.EmployeePerformanceEvaluates
                 .AsNoTracking()
                 .Include(nameof(EmployeePerformanceEvaluate.MeritAverages))
                 .Include(nameof(EmployeePerformanceEvaluate.MeritItemAverages))
                 .Include(nameof(EmployeePerformanceEvaluate.PerformanceEvaluateItems))
                 .FirstOrDefaultAsync(c => c.Id == id) ?? null!;
            return result;
        }
        #endregion
    }
}
