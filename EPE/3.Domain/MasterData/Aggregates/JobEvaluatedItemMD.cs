using EPE.Application.Core.Domain;
using EPE.Domain.MasterData.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.MasterData.Aggregates
{
    public class JobEvaluatedItemMD : Entity<long>
    {
        #region constractors
        public JobEvaluatedItemMD()
        {

        }

        public JobEvaluatedItemMD(int evaluationItemId , int importanceFactor , int criterionScore)
        {
            validate(importanceFactor , criterionScore);
            EvaluationItemId = evaluationItemId;
            ImportanceFactor = importanceFactor;
            CriterionScore = criterionScore;
        }

        #endregion

        #region properties
        //public int JobId { get; set; }
        public int EvaluationItemId { get; set; }
        public int ImportanceFactor { get; set; }
        public int CriterionScore { get; set; }
        [NotMapped]
        public double Scale { get; set; }

        #endregion

        #region private methods
        private void validate(int importanceFactor, int criterionScore)
        {
            if (importanceFactor <= 0)
                throw new Exception("ضریب اهمیت باید بزرگتر از صفر باشد");

            if(criterionScore < 0 || criterionScore > 100)
                throw new Exception("نمره ی ملاک باید بین 0 تا 100 باشد");
        }
        #endregion

        #region public methods
        public void UpdateProperties(int evaluationItemId, int importanceFactor, int criterionScore)
        {
            validate(importanceFactor , criterionScore);
            EvaluationItemId = evaluationItemId;
            ImportanceFactor = importanceFactor;
            CriterionScore = criterionScore;
        }
        #endregion
    }
}
