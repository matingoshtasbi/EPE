using EPE.Application.DTOs.PerformanceEvaluate;
using EPE.Domain.PerformanceEvaluate.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.Abstractions.PerformanceEvaluate
{
    public interface IPerformanceEvaluateCommandService
    {
        Task<EmployeePerformanceEvaluate> Calculate(EmployeePerformanceEvaluateRequest result);
        Task RemoveEPE(long lastSelectedId);
    }
}
