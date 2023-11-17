using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.MasterData.ParameterObjects
{
    public class UpdateCalendarItemPO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CalendarItemType { get; set; }
        public string Description { get; set; }
    }
}
