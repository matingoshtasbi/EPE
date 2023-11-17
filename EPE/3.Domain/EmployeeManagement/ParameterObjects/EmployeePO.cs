using EPE.Domain.EmployeeManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.EmployeeManagement.ParameterObjects
{
    public class EmployeePO
    {
        public Guid? Id { get; set; }
        public string? IdNo { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? FatherName { get; set; } = default!;
        public DateTime EmploymentDate { get; set; } = default!;
        public DateTime? ReleaseDate { get; set; } = default!;
        public DateTime? Birthdate { get; set; } = default!;
        public string? Birthplace { get; set; } = default!;
        public int GenderId { get; set; } = default!;
        public string? Nationality { get; set; } = default!;
        public int? NumberOfDependents { get; set; } = default!;
        public int MaritalStatusId { get; set; } = default!;
        public int MilitaryServiceStatusId { get; set; } = default!;
        public int JobId { get; set; } = default!;
        public string Description { get; set; }

    }
}
