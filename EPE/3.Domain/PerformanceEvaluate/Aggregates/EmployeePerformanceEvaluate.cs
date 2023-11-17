using EPE.Application.Core.Domain;
using EPE.Application.DTOs.PerformanceEvaluate;
using EPE.Domain.PerformanceEvaluate.ParameterObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.PerformanceEvaluate.Aggregates
{
    public class EmployeePerformanceEvaluate : Entity<long>
    {
        #region constractors
        public EmployeePerformanceEvaluate()
        {

        }

        public EmployeePerformanceEvaluate(string employeePersonalCode, string employeeFirstName, string employeeLastName, DateTime now)
        {
            EmployeePersonalCode = employeePersonalCode;
            EmployeeFirstName = employeeFirstName;
            EmployeeLastName = employeeLastName;
            RegisterDate = now;
        }
        #endregion

        #region properties
        public string EmployeePersonalCode { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }

        public DateTime RegisterDate { get; set; }


        private double totalWeightedCriterionScore;
        public double TotalWeightedCriterionScore
        {
            get
            {
                return Math.Round(totalWeightedCriterionScore, 2);
            }
            set
            {
                totalWeightedCriterionScore = value;
            }
        }

        private double totalWeightCriterionScore;
        public double TotalWeightedScore
        {
            get
            {
                return Math.Round(totalWeightCriterionScore, 2);
            }
            set
            {
                totalWeightCriterionScore = value;
            }
        }

        private double meritFactor;
        public double MeritFactor
        {
            get
            {
                return Math.Round(meritFactor, 2);
            }
            set
            {
                meritFactor = value;
            }
        }

        public virtual List<PerformanceEvaluateItem> PerformanceEvaluateItems { get; set; } = new();
        public virtual List<MeritAverage> MeritAverages { get; set; } = new();
        public virtual List<MeritItemAverage> MeritItemAverages { get; set; } = new();
        #endregion

        #region public methods
        public void AddPerformanceEvaluateItem(PerformanceEvaluateItemPO po)
        {
            var pE = PerformanceEvaluateFactory.CreatePerformanceEvaluateItem(po);
            PerformanceEvaluateItems.Add(pE);
        }

        public void CalculateAndAddMeritAverage(IGrouping<string, PerformanceEvaluateItemRequest> meritsGroup)
        {
            var meritAvg = PerformanceEvaluateFactory.CreateMeritAverage(meritsGroup);
            MeritAverages.Add(meritAvg);
        }

        public void CalculateAndAddMeritItemAverage(IGrouping<string, PerformanceEvaluateItemRequest> meritItemsGroup)
        {
            var meritItemAvg = PerformanceEvaluateFactory.CreateMeritItemAverage(meritItemsGroup);
            MeritItemAverages.Add(meritItemAvg);
        }

        public void CalculateMeritFactor()
        {
            var totalImportanceFactor = PerformanceEvaluateItems.Select(c => c.ImportanceFactor).Sum();
            TotalWeightedCriterionScore = PerformanceEvaluateItems.Select(c => c.CriterionScore * c.ImportanceFactor).Sum();
            TotalWeightedScore = PerformanceEvaluateItems.Select(c => c.Score * c.ImportanceFactor).Sum();

            MeritFactor = TotalWeightedScore / TotalWeightedCriterionScore;
        }
        #endregion
    }
}
