using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.PerformanceEvaluate.ParameterObjects
{
    public class PerformanceEvaluateItemPO
    {
        public long Id { get; set; }
        public string MeritTitle { get; set; }
        public string MeritItemTitle { get; set; }
        public string EvaluationItemTitle { get; set; }
        public string EvaluationItemDescription { get; set; }
        public int ImportanceFactor { get; set; }
        public int CriterionScore { get; set; }
        public double TotalScale { get; set; }
        public double MeritScale { get; set; }
        public double MeritItemScale { get; set; }
        public int Score { get; set; }
    }
}
