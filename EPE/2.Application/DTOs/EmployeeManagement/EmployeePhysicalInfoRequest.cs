using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.DTOs.EmployeeManagement
{
    public class EmployeePhysicalInfoRequest
    {
        public int? Id { get; set; }
        public int PhysicalInfoId { get; set; }
        public string PhysicalInfoTitle { get; set; }
        public string? Value { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
