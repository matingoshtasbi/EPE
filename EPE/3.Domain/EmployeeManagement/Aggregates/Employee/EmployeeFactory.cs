using EPE.Domain.EmployeeManagement.Enums;
using EPE.Domain.EmployeeManagement.ParameterObjects;
using EPE.Domain.EmployeeManagement.Services;
using EPE.Domain.EmployeeManagement.ValueObjects;
using EPE.Domain.EmployeeManagement.ValueObjects.Education;
using EPE.Domain.EmployeeManagement.ValueObjects.PhysicalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.EmployeeManagement.Aggregates
{
    public static class EmployeeFactory
    {
        public static Employee Create(EmployeePO po, IEmployeeService employeeService) 
        {
            var employee = new Employee(po, employeeService);  
            //employee.GenerateNewIdentity();

            return employee;    
        }

        internal static EmployeeContact CreateContact(string title, ContactTypeEnum type, string value)
        {
            var employeeContact = new EmployeeContact(title, type, value);
            //employeeContact.GenerateNewIdentity();

            return employeeContact;

        }

        internal static EmployeeEducation CreateEducation(int levelId, int majorId , string minor,  double? average)
        {
            var employeeEducation = new EmployeeEducation(levelId, majorId , minor , average);
            return employeeEducation;
        }

        internal static EmployeePhysicalInfo CreatePhysicalInfo(int physicalInfoId, string value)
        {
            var employeePhysicalInfo = new EmployeePhysicalInfo(physicalInfoId, value);
            return employeePhysicalInfo;
        }

        internal static EmployeeResume CreateResume(string title, DateTime fromDate, DateTime toDate, string description)
        {
            var employeeResume = new EmployeeResume(title, fromDate, toDate, description);
            return employeeResume;
        }
    }
}
