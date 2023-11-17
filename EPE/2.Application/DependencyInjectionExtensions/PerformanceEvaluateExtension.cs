using EPE.Application.Abstractions.PerformanceEvaluate;
using EPE.Application.Services.PerformanceEvaluate;
using EPE.Domain.PerformanceEvaluate.Aggregates;
using EPE.Infrastructure.Persistence.Repositories.PerformanceEvaluate;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.DependencyInjectionExtensions
{
    public static class PerformanceEvaluateExtension
    {
        public static IServiceCollection AddPerformanceEvaluateModules(this IServiceCollection services)
        {
            services.AddScoped<IPerformanceEvaluateCommandService, PerformanceEvaluateCommandService>();
            services.AddScoped<IPerformanceEvaluateQueryService, PerformanceEvaluateQueryService>();
            services.AddScoped<IEmployeePerformanceEvaluateRepository, EmployeePerformanceEvaluateRepository>();

            return services;
        }
    }
}
