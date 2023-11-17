using EPE.Domain.EmployeeManagement.Aggregates;
using EPE.Domain.EmployeeManagement.ValueObjects.Education;
using EPE.Domain.EmployeeManagement.ValueObjects.Gender;
using EPE.Domain.EmployeeManagement.ValueObjects.MaritalStatus;
using EPE.Domain.EmployeeManagement.ValueObjects.MilitaryServiceStatus;
using EPE.Domain.EmployeeManagement.ValueObjects.PhysicalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        #region members
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEducationLevelRepositoryEM _educationLevelRepository;
        private readonly IEducationMajorRepositoryEM _educationMajorRepository;
        private readonly IPhysicalInfoRepositoryEM _physicalInfoRepository;
        private readonly IMaritalStatusRepositoryEM _maritalStatusRepository;
        private readonly IGenderRepositoryEM _genderRepository;
        private readonly IMilitaryServiceStatusRepositoryEM _militaryServiceStatusRepository;
        #endregion

        #region constractors
        public EmployeeService(
            IEmployeeRepository employeeRepository,
            IEducationLevelRepositoryEM educationLevelRepository,
            IEducationMajorRepositoryEM educationMajorRepository,
            IPhysicalInfoRepositoryEM physicalInfoRepository,
            IMaritalStatusRepositoryEM maritalStatusRepository,
            IGenderRepositoryEM genderRepository,
            IMilitaryServiceStatusRepositoryEM militaryServiceStatusRepository)
        {
            _employeeRepository = employeeRepository;
            _educationLevelRepository = educationLevelRepository;
            _educationMajorRepository = educationMajorRepository;
            _physicalInfoRepository = physicalInfoRepository;
            _maritalStatusRepository = maritalStatusRepository;
            _genderRepository = genderRepository;
            _militaryServiceStatusRepository = militaryServiceStatusRepository;
        }
        #endregion

        #region public methods
        public bool IsEmployeeIdNoExist(string id, Guid exceptId)
        {
            return _employeeRepository.Get(c => c.IdNo == id && c.Id != exceptId).Any();
        }
        public bool IsEmployeeCodeExist(string code, Guid exceptId)
        {
            return _employeeRepository.Get(c => c.Code == code && c.Id != exceptId).Any();
        }
        public bool IsEducationLevelValid(int levelId)
        {
            return _educationLevelRepository.Get(el => el.Id == levelId).Any();
        }
        public bool IsEducationMajorValid(int majorId)
        {
            return _educationMajorRepository.Get(em => em.Id == majorId).Any();
        }
        public bool IsPhysicalInfoValid(int physicalInfoId)
        {
            return _physicalInfoRepository.Get(em => em.Id == physicalInfoId).Any();
        }
        public bool IsMaritalStatusInvalid(int maritalStatusId)
        {
            return _maritalStatusRepository.Get(c => c.Id == maritalStatusId).Any();
        }
        public bool IsGenderInvalid(int genderId)
        {
            return _genderRepository.Get(c => c.Id == genderId).Any();
        }
        public bool IsMilitaryServiceStatusInvalid(int militaryServiceStatusId)
        {
            return _militaryServiceStatusRepository.Get(c => c.Id == militaryServiceStatusId).Any();
        }
        public void RemoveEmployee(Guid employeeId)
        {
            var employee = _employeeRepository.Get(employeeId);

            if (employee == null)
                throw new Exception("کارمند یافت نشد");

            _employeeRepository.Remove(employeeId);
        }


        #endregion
    }
}
