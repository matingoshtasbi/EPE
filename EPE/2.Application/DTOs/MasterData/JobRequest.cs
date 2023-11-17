using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.DTOs.MasterData
{
    public class JobRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<JobEvaluatedItemRequest> EvaluatedItems { get; set; } = new();
    }
}
