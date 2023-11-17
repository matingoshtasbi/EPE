using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.DTOs.EmployeeManagement
{
    public class EmployeeResumeRequest
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Description { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
