using EPE.Application.Core.Domain;
using EPE.Domain.EmployeeManagement.ValueObjects.PhysicalInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.EmployeeManagement.Aggregates
{
    public class EmployeePhysicalInfo : Entity<int>
    {
        #region constractor
        public EmployeePhysicalInfo()
        {

        }
        public EmployeePhysicalInfo(int physicalInfoId, string value)
        {
            validate(value);
            PhysicalInfoId = physicalInfoId;
            Value = value;
        }
        #endregion

        #region properties
        public int PhysicalInfoId { get; set; }
        public string? Value { get; set; }
        #endregion

        #region public methods
        internal void UpdateProperties(int physicalInfoId, string value)
        {
            validate(value);
            PhysicalInfoId = physicalInfoId;
            Value = value;
        }
        #endregion

        #region private methods
        private void validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("مقدار اطلاعات فیزیکی اجباریست");
        }
        #endregion
    }
}
