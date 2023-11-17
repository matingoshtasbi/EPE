using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.MasterData.ParameterObjects
{
    public class UpdateCalendarPO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CalendarType { get; set; }
        public int Year { get; set; }
    }
}
