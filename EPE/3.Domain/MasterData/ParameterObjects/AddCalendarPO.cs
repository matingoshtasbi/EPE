using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.MasterData.ParameterObjects
{
    public class AddCalendarPO
    {
        public string Name { get; set; }
        public int CalendarType { get; set; }
        public int Year { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
    }
}
