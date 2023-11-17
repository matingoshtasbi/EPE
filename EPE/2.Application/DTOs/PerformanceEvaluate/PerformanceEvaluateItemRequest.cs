using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.DTOs.PerformanceEvaluate
{
    public class PerformanceEvaluateItemRequest
    {
        public string MeritTitle { get; set; }
        public string MeritItemTitle { get; set; }
        public string EvaluationItemTitle { get; set; }
        public string EvaluationItemDescription { get; set; }
        public int ImportanceFactor { get; set; }
        public int CriterionScore { get; set; }

        // Scales
        public double TotalScale { get; set; }
        public double MeritScale { get; set; }
        public double MeritItemScale { get; set; }

        public int Score { get; set; }
    }
}
