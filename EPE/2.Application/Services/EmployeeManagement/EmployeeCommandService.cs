using EPE.Application.Abstractions.EmployeeManagement;
using EPE.Application.DTOs.EmployeeManagement;
using EPE.Application.DTOs.EmployeeManagement.BaseInfo;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPE.Domain.EmployeeManagement.ParameterObjects;
using EPE.Domain.EmployeeManagement.Aggregates;
using EPE.Domain.EmployeeManagement.Enums;
using EPE.Domain.EmployeeManagement.Services;
using AutoMapper;
using EPE.Domain.EmployeeManagement.ValueObjects.Education;
using EPE.Domain.EmployeeManagement.ValueObjects.PhysicalInfo;

namespace EPE.Application.Services.EmployeeManagement
{
    public class EmployeeCommandService : IEmployeeCommandService
    {
        #region members
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEducationLevelRepositoryEM _educationLevelRepository;
        private readonly IEducationMajorRepositoryEM _educationMajorRepository;
        private readonly IPhysicalInfoRepositoryEM _physicalInfoRepository;
        private readonly IServiceProvider _provider;
        private readonly IEmployeeService _employeeService;
        #endregion

        #region constractors
        public EmployeeCommandService(IMapper mapper,
            IEmployeeRepository employeeRepository,
            IEducationLevelRepositoryEM educationLevelRepository,
            IEducationMajorRepositoryEM educationMajorRepository,
            IPhysicalInfoRepositoryEM physicalInfoRepository,
            IServiceProvider provider,
            IEmployeeService employeeService)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _educationLevelRepository = educationLevelRepository;
            _educationMajorRepository = educationMajorRepository;
            _physicalInfoRepository = physicalInfoRepository;
            _provider = provider;
            _employeeService = employeeService;
        }
        #endregion

        #region private methods

        #region contact
        private void addContacts(List<EmployeeContactRequest> contacts, Employee employee)
        {
            foreach (var item in contacts) 
            {
                var type = Enum.Parse<ContactTypeEnum>(Enum.GetName(typeof(ContactTypeEnum), item.TypeId));
                var contactTitle = (string.IsNullOrWhiteSpace(item.Title) ? Enum.GetName(typeof(ContactTypeEnum), item.TypeId) : item.Title);
                employee.AddContact(contactTitle, type, item.Value);
            }                
        }
        private void updateContacts(List<EmployeeContactRequest> contacts, Employee employee)
        {
            foreach (var item in contacts)
            {
                if (item.Id == 0 && !item.IsDeleted)
                {
                    var type = Enum.Parse<ContactTypeEnum>(Enum.GetName(typeof(ContactTypeEnum), item.TypeId));
                    var contactTitle = (string.IsNullOrWhiteSpace(item.Title) ? Enum.GetName(typeof(ContactTypeEnum), item.TypeId) : item.Title);
                    employee.AddContact(contactTitle, type, item.Value);
                    continue;
                }

                if (item.IsDeleted)
                {
                    if (employee.Contacts.Any(x => x.Id == item.Id))
                    {
                        employee.RemoveContact(item.Id.Value);
                    }
                }
                else
                {
                    var type = Enum.Parse<ContactTypeEnum>(Enum.GetName(typeof(ContactTypeEnum), item.TypeId));
                    employee.UpdateContact(item.Id.Value, item.Title, type, item.Value);
                }
            }            
        }
        #endregion

        #region education
        private void addEducations(List<EmployeeEducationRequest> educations, Employee employee)
        {
            foreach (var item in educations)
            {
                employee.AddEducation(item.LevelId, item.MajorId, item.Minor, item.Average);
            }
        }
        private void updateEducations(List<EmployeeEducationRequest> educations, Employee employee)
        {
            foreach (var item in educations)
            {
                if (item.Id == 0 && !item.IsDeleted)
                {
                    employee.AddEducation(item.LevelId, item.MajorId, item.Minor, item.Average);
                    continue;
                }

                if (item.IsDeleted)
                {
                    if (employee.Educations.Any(x => x.Id == item.Id))
                    {
                        employee.RemoveEducation(item.Id.Value);
                    }
                }
                else
                    employee.UpdateEducation(item.Id.Value, item.LevelId, item.MajorId, item.Minor, item.Average);
            }
        }
        #endregion

        #region physicalInfo
        private void addPhysicalInfo(List<EmployeePhysicalInfoRequest> physicalInfo, Employee employee)
        {
            foreach (var item in physicalInfo)
            {
                employee.AddPhysicalInfo(item.PhysicalInfoId, item.Value);
            }
        }
        private void updatePhysicalInfo(List<EmployeePhysicalInfoRequest> physicalInfo, Employee employee)
        {
            foreach (var item in physicalInfo)
            {
                if (item.Id == 0 && !item.IsDeleted)
                {
                    employee.AddPhysicalInfo(item.PhysicalInfoId, item.Value);
                    continue;
                }

                if (item.IsDeleted)
                {
                    if (employee.PhysicalInfo.Any(x => x.Id == item.Id))
                    {
                        employee.RemovePhysicalInfo(item.Id.Value);
                    }
                }
                else
                    employee.UpdatePhysicalInfo(item.Id.Value, item.PhysicalInfoId, item.Value);

            }
        }
        #endregion

        #region resume
        private void addResume(List<EmployeeResumeRequest> resume, Employee employee)
        {
            foreach (var item in resume)
            {
                employee.AddResume(item.Title, item.FromDate , item.ToDate , item.Description);
            }
        }

        private void updateResume(List<EmployeeResumeRequest> resume, Employee employee)
        {
            foreach (var item in resume)
            {
                if (item.Id == 0 && !item.IsDeleted)
                {
                    employee.AddResume(item.Title , item.FromDate , item.ToDate , item.Description);
                    continue;
                }

                if (item.IsDeleted)
                {
                    if (employee.PhysicalInfo.Any(x => x.Id == item.Id))
                    {
                        employee.RemoveResume(item.Id.Value);
                    }
                }
                else
                    employee.UpdateResume(item.Id.Value, item.Title , item.FromDate , item.ToDate , item.Description);

            }
        }
        #endregion

        #endregion

        #region public methods

        #region employees
        public async Task<Guid> AddEmployee(EmployeeRequest request)
        {

            var employeePO = _mapper.Map<EmployeePO>(request);
            var employee = EmployeeFactory.Create(employeePO , _employeeService);

            if (request.Contacts is not null)
                addContacts(request.Contacts, employee);
            if (request.Educations is not null)
                addEducations(request.Educations, employee);
            if (request.PhysicalInfo is not null)
                addPhysicalInfo(request.PhysicalInfo, employee);
            if (request.Resume is not null)
                addResume(request.Resume, employee);

            _employeeRepository.Add(employee);
            await _employeeRepository.UnitOfWork.SaveChangesAsync();
            return employee.Id;
        }

        public async Task UpdateEmployee(EmployeeRequest request)
        {
            if (!request.Id.HasValue)
                throw new Exception("کارمند یافت نشد");

            var employeePO = _mapper.Map<EmployeePO>(request);

            var employee = _employeeRepository.Get(request.Id.Value);

            employee.EmployeeService = _employeeService;
            employee.UpdateProperties(employeePO);

            if (request.Contacts is not null)
                updateContacts(request.Contacts, employee);
            if (request.Educations is not null)
                updateEducations(request.Educations, employee);
            if (request.PhysicalInfo is not null)
                updatePhysicalInfo(request.PhysicalInfo, employee);
            if (request.Resume is not null)
                updateResume(request.Resume, employee);

            await _employeeRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task RemoveEmployee(Guid employeeId)
        {
            _employeeService.RemoveEmployee(employeeId);

            await _employeeRepository.UnitOfWork.SaveChangesAsync();
        }
        #endregion

        #region baseInfo
        public async Task<EmployeeBaseInfo> GetBaseInfo()
        {
            var baseInfo = new EmployeeBaseInfo();
            baseInfo.EducationLevels = _mapper.Map<List<EducationLevelDto>>(_educationLevelRepository.GetAll().ToList());
            baseInfo.EducationMajors = _mapper.Map<List<EducationMajorDto>>(_educationMajorRepository.GetAll().ToList());
            baseInfo.PhysicalInfos = _mapper.Map<List<PhysicalInfoDto>>(_physicalInfoRepository.GetAll().ToList());

            return baseInfo;
        }
        #endregion

        #endregion
    }
}
