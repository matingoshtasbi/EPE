using EPE.Application.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.EmployeeManagement.ValueObjects.Education
{
    public class EducationMajorEM : Entity<int>
    {
        #region properties
        public string Title { get; set; }
        //public int EducationLevelId { get; set; }
        //public virtual EducationLevelEM EducationLevel { get; set; }
        #endregion
    }
}
