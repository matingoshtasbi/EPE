using EPE.Domain.EmployeeManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.DTOs.EmployeeManagement
{
    public class EmployeeContactRequest
    {
        public int? Id { get; set; } = default!;
        public string Title { get; set; } = default!;
        public ContactTypeEnum Type { get; set; } = default!;
        public string Value { get; set; } = default!;
        public bool IsDeleted { get; set; } =false;
        public int TypeId { get; set; }
        public string ContactTypeTitle { get; set; }
        //public Guid? TempId { get; set; }
    }
}
