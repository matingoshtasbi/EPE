using EPE.Application.Core.Domain;
using EPE.Domain.PerformanceEvaluate.ParameterObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.PerformanceEvaluate.Aggregates
{
    public class PerformanceEvaluateItem : Entity<long>
    {
        public PerformanceEvaluateItem()
        {

        }

        public PerformanceEvaluateItem(PerformanceEvaluateItemPO po)
        {
            MeritTitle = po.MeritTitle;
            MeritItemTitle = po.MeritItemTitle;
            EvaluationItemTitle = po.EvaluationItemTitle;
            EvaluationItemDescription = po.EvaluationItemDescription;
            ImportanceFactor = po.ImportanceFactor;
            CriterionScore = po.CriterionScore;
            TotalScale = po.TotalScale;
            MeritScale = po.MeritScale;
            MeritItemScale = po.MeritItemScale;
            Score = po.Score;
        }

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
