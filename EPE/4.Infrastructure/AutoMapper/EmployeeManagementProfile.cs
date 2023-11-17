using AutoMapper;
using EPE.Application.DTOs.EmployeeManagement;
using EPE.Application.DTOs.EmployeeManagement.BaseInfo;
using EPE.Domain.EmployeeManagement.Aggregates;
using EPE.Domain.EmployeeManagement.ParameterObjects;
using EPE.Domain.EmployeeManagement.ValueObjects.Education;
using EPE.Domain.EmployeeManagement.ValueObjects.PhysicalInfo;
namespace EPE.Infrastructure.AutoMapper
{
    public class EmployeeManagementProfile : Profile
    {
        public EmployeeManagementProfile()
        {
            CreateMap<EmployeeRequest, EmployeePO>();
            CreateMap<EducationLevelEM, EducationLevelDto>();
            CreateMap<EducationMajorEM, EducationMajorDto>();
            CreateMap<PhysicalInfoEM, PhysicalInfoDto>();

        }
    }
}
