using EPE.Application.Core.Domain;
using EPE.Application.DTOs.PerformanceEvaluate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.PerformanceEvaluate.Aggregates
{
    public class MeritItemAverage : Entity<long>
    {
        public MeritItemAverage()
        {

        }
        public MeritItemAverage(IGrouping<string, PerformanceEvaluateItemRequest> meritItemsGroup)
        {
            MeritTitle = meritItemsGroup.First().MeritTitle;
            MeritItemTitle = meritItemsGroup.First().MeritItemTitle;
            ImportanceFactor = meritItemsGroup.Select(c => c.ImportanceFactor).Sum();
            CriterionScore = meritItemsGroup.Select(c => { return c.CriterionScore * c.ImportanceFactor; }).Sum() / ImportanceFactor;
            Score = meritItemsGroup.Select(c => { return c.Score * c.ImportanceFactor; }).Sum() / ImportanceFactor;
        }

        public string MeritTitle { get; set; }
        public string MeritItemTitle { get; set; }

        [NotMapped]
        public int ImportanceFactor { get; set; }

        private double criterionScore;
        public double CriterionScore
        {
            get
            {
                return Math.Round(criterionScore, 2);
            }
            set
            {
                criterionScore = value;
            }
        }

        public double MeritScale { get; set; }
        public double TotalScale { get; set; }

        private double score;
        public double Score
        {
            get
            {
                return Math.Round(score, 2);
            }
            set
            {
                score = value;
            }
        }
    }
}
