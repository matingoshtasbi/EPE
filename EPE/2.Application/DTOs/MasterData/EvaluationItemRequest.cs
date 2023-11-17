using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.DTOs.MasterData
{
    public class EvaluationItemRequest
    {
        public int Id { get; set; }
        public int MeritItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string MeritTitle { get; set; }
        public string MeritItemTitle { get; set; }

    }
}
