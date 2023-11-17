using AutoMapper;
using EPE.Application.DTOs.PerformanceEvaluate;
using EPE.Domain.PerformanceEvaluate.ParameterObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Infrastructure.AutoMapper
{
    internal class PerformanceEvaluateProfile : Profile
    {
        public PerformanceEvaluateProfile()
        {
            CreateMap<PerformanceEvaluateItemRequest, PerformanceEvaluateItemPO>();
        }
    }
}
