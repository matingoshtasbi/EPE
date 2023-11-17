using EPE.Application.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.EmployeeManagement.ValueObjects.Education
{
    public class EducationLevelEM : Entity<int> 
    {
        #region properties
        public string Title { get; set; } = default!;
        public int Order { get; set; }

        //public virtual List<EducationMajorEM> EducationMajors { get; set; }
        #endregion
    }
}
