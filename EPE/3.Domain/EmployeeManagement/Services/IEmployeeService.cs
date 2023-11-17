using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.EmployeeManagement.Services
{
    public interface IEmployeeService
    {
        bool IsEmployeeIdNoExist(string idNo , Guid exceptId);
        bool IsEmployeeCodeExist(string code , Guid exceptId);
        bool IsEducationLevelValid(int levelId);
        bool IsEducationMajorValid(int majorId);
        bool IsPhysicalInfoValid(int physicalInfoId);
        bool IsMaritalStatusInvalid(int maritalStatusId);
        bool IsGenderInvalid(int maritalStatusId);
        bool IsMilitaryServiceStatusInvalid(int militaryServiceStatusId);
        void RemoveEmployee(Guid employeeId);
    }
}
