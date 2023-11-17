using EPE.Application.Abstractions.EmployeeManagement;
using EPE.Application.Services.EmployeeManagement;
using EPE.Domain.EmployeeManagement.Aggregates;
using EPE.Domain.EmployeeManagement.Services;
using EPE.Domain.EmployeeManagement.ValueObjects.Education;
using EPE.Domain.EmployeeManagement.ValueObjects.Gender;
using EPE.Domain.EmployeeManagement.ValueObjects.MaritalStatus;
using EPE.Domain.EmployeeManagement.ValueObjects.MilitaryServiceStatus;
using EPE.Domain.EmployeeManagement.ValueObjects.PhysicalInfo;
using EPE.Domain.MasterData.Aggregates;
using EPE.Infrastructure.Persistence.Repositories.EmployeeManagement;
using EPE.Infrastructure.Persistence.Repositories.MasterData;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.DependencyInjectionExtensions
{
    public static class EmployeeManagementExtension
    {
        public static IServiceCollection AddEmployeeManagementModules(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeCommandService, EmployeeCommandService>();
            services.AddScoped<IEmployeeQueryService, EmployeeQueryService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEducationLevelRepositoryEM, EducationLevelRepositoryEM>();
            services.AddScoped<IEducationMajorRepositoryEM, EducationMajorRepositoryEM>();
            services.AddScoped<IPhysicalInfoRepositoryEM, PhysicalInfoRepositoryEM>();
            services.AddScoped<IMaritalStatusRepositoryEM, MaritalStatusRepositoryEM>();
            services.AddScoped<IGenderRepositoryEM, GenderRepositoryEM>();
            services.AddScoped<IMilitaryServiceStatusRepositoryEM, MilitaryServiceStatusRepositoryEM>();
            services.AddScoped<IEmployeeService, EmployeeService>();



            return services;
        }
    }
}
