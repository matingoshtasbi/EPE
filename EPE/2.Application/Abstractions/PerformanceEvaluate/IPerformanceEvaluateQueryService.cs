using EPE.Application.Core.DTOs;
using EPE.Domain.PerformanceEvaluate.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.Abstractions.PerformanceEvaluate
{
    public interface IPerformanceEvaluateQueryService
    {
        Task<PageResult<EmployeePerformanceEvaluate>> FindEPEs();
        Task<EmployeePerformanceEvaluate> FindEPE(long id);

    }
}
