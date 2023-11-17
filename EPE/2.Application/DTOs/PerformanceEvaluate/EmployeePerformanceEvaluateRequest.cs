using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.DTOs.PerformanceEvaluate
{
    public class EmployeePerformanceEvaluateRequest
    {
        public string EmployeePersonalCode { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }

        public List<PerformanceEvaluateItemRequest> PerformanceEvaluateItems { get; set; } = new();

    }
}
