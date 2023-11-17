using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.DTOs.EmployeeManagement
{
    public class EmployeeEducationRequest
    {
        public int? Id { get; set; }
        public int LevelId { get; set; }
        public string LevelTitle { get; set; }
        public int MajorId { get; set; }
        public string MajorTitle { get; set; }
        public string Minor { get; set; }
        public double? Average { get; set; }
        public string AverageStr { get; set; }

        public bool IsDeleted { get; set; }

    }
}
