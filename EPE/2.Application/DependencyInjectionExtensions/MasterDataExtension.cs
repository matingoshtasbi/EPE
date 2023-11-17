using EPE.Application.Abstractions.MasterData;
using EPE.Application.Services.MasterData;
using EPE.Domain.MasterData.Aggregates;
using EPE.Domain.MasterData.Services;
using EPE.Infrastructure.Persistence.Repositories.MasterData;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.DependencyInjectionExtensions
{
    public static class MasterDataExtension
    {
        public static IServiceCollection AddMasterDataModules(this IServiceCollection services)
        {
            services.AddScoped<IMasterDataCommandService, MasterDataCommandService>();
            services.AddScoped<IMasterDataQueryService, MasterDataQueryService>();
            services.AddScoped<IEducationLevelRepositoryMD, EducationLevelRepositoryMD>();
            services.AddScoped<IEducationMajorRepositoryMD, EducationMajorRepositoryMD>();
            services.AddScoped<IPhysicalInfoRepositoryMD, PhysicalInfoRepositoryMD>();
            services.AddScoped<IJobRepositoryMD, JobRepositoryMD>();
            services.AddScoped<IMeritRepositoryMD, MeritRepositoryMD>();
            services.AddScoped<IMeritItemRepositoryMD, MeritItemRepositoryMD>();
            services.AddScoped<IEvaluationItemRepositoryMD, EvaluationItemRepositoryMD>();
            services.AddScoped<IJobEvaluatedItemRepositoryMD, JobEvaluatedItemRepositoryMD>();
            services.AddScoped<IMaritalStatusRepositoryMD, MaritalStatusRepositoryMD>();
            services.AddScoped<IGenderRepositoryMD, GenderRepositoryMD>();
            services.AddScoped<IMilitaryServiceStatusRepositoryMD, MilitaryServiceStatusRepositoryMD>();
            services.AddScoped<IMasterDataService, MasterDataService>();

            return services;
        }
    }
}
