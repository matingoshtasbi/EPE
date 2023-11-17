using EPE.Domain.EmployeeManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.DTOs.EmployeeManagement
{
    public class EmployeeRequest
    {
        //
        // Basic
        //
        public Guid? Id { get; set; } = new ();
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public DateTime EmploymentDate { get; set; }
        public DateTime? ReleaseDate { get; set; }

        //
        // Personal
        //
        /// <summary>
        /// شماره شناسنامه فرد
        /// </summary>
        public string IdNo { get; set; }
        public string? FatherName { get; set; }
        public int GenderId { get; set; }
        public int MaritalStatusId { get; set; }
        public int MilitaryServiceStatusId { get; set; }
        public int NumberOfDependents { get; set; } = 0;
        public string Nationality { get; set; } = "ایرانی";
        public DateTime? Birthdate { get; set; }
        public string? Birthplace { get; set; }

        //
        // Job
        public int JobId { get; set; }


        //
        // Contacts
        public List<EmployeeContactRequest> Contacts { get; set; } = new ();

        //
        // Eduacations
        public List<EmployeeEducationRequest> Educations { get; set; } = new ();

        //
        // Physical
        public List<EmployeePhysicalInfoRequest> PhysicalInfo { get; set; } = new ();

        //
        // Resume
        public List<EmployeeResumeRequest> Resume { get; set; } = new();

        //
        // ExtraInfo
        public string Description { get; set; }
    }
}
