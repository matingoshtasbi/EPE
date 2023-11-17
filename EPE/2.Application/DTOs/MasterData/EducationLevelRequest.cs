using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.DTOs.MasterData
{
    public class EducationLevelRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        //public int CompanyId { get; set; }
    }
}
