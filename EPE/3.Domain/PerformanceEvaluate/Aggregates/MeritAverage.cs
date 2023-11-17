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
    public class MeritAverage : Entity<long>
    {
        public MeritAverage()
        {

        }

        public MeritAverage(IGrouping<string, PerformanceEvaluateItemRequest> meritsGroup)
        {
            MeritTitle = meritsGroup.First().MeritTitle;
            ImportanceFactor = meritsGroup.Select(c => c.ImportanceFactor).Sum();
            CriterionScore = meritsGroup.Select(c => { return c.CriterionScore * c.ImportanceFactor; }).Sum() / ImportanceFactor;
            Score = meritsGroup.Select(c => { return c.Score * c.ImportanceFactor; }).Sum() / ImportanceFactor;
        }

        public string MeritTitle { get; set; }

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
