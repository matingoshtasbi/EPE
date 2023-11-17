using EPE.Application.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.PerformanceEvaluate.Aggregates
{
    public interface IEmployeePerformanceEvaluateRepository : IRepository<EmployeePerformanceEvaluate, long>
    {
    }
}
