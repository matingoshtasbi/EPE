using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.EmployeeManagement.Enums
{
    public enum MilitaryServiceStatusEnum
    {
        [Description("نامشخص")]
        Unknown = 0,
        [Description("انجام نشده")]
        NotDone = 1,
        [Description("انجام شده")]
        Done = 2,
        [Description("معاف پزشکی")]
        MedicalExempt = 3,
        [Description("معاف غیر پزشکی")]
        OtherExempt = 4
    }
}
