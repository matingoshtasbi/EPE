using EPE.Application.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.EmployeeManagement.ValueObjects.PhysicalInfo
{
    public class PhysicalInfoEM : Entity<int>
    {
        #region properties
        public string Title { get; set; }
        #endregion
    }
}
