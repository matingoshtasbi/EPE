using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.DTOs.MasterData
{
    public class MeritItemRequest
    {
        public int Id { get; set; }
        public int MeritId { get; set; }
        public string Title { get; set; }
        public string MeritTitle { get; set; }

    }
}
