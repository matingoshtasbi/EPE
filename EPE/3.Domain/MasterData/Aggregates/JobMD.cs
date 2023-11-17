using EPE.Application.Core.Domain;
using EPE.Domain.MasterData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.MasterData.Aggregates
{
    public class JobMD : Entity<int>
    {
        #region constractors
        public JobMD()
        {

        }

        public JobMD(string title, IMasterDataService masterDataService)
        {
            MasterDataService = masterDataService;
            validate(title);
            Title = title;
        }
        #endregion

        #region properties

        public string Title { get; set; }
        private IMasterDataService MasterDataService = default!;
        public virtual List<JobEvaluatedItemMD> EvaluatedItems { get; set; } = new();

        #endregion


        #region private methods
        private void validate(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("عنوان شغل اجباریست");
            if (MasterDataService.IsJobTitleExist(title, 0))
                throw new Exception("عنوان شغل تکراریست");
        }

        private void validate(int id , string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("عنوان شغل اجباریست");
            if (MasterDataService.IsJobTitleExist(title, id))
                throw new Exception("عنوان شغل تکراریست");
        }
        #endregion

        #region public methods

        #region job
        public void UpdateProperties(int id , string title, IMasterDataService masterDataService)
        {
            MasterDataService = masterDataService;
            validate(id , title);
            Title = title;
        }
        #endregion

        #region evaluatedItem
        public JobEvaluatedItemMD AddEvaluatedItem(int evaluationItemId, int importanceFactor, int criterionScore)
        {
            if (!MasterDataService.IsEvaluationItemExist(evaluationItemId))
                throw new Exception("آیتم ارزیابی یافت نشد");
            var jobEvaluatedItem = MasterDataFactory.CreateEvaluatedItem(evaluationItemId , importanceFactor , criterionScore);
            EvaluatedItems.Add(jobEvaluatedItem);
            if (EvaluatedItems.GroupBy(p => new { p.EvaluationItemId })
               .Where(p => p.Count() > 1).Any())
                throw new Exception("آیتم موثر بر شغل تکراریست");
            return jobEvaluatedItem;
        }

        public void UpdateEvaluatedItem(long id, int evaluationItemId, int importanceFactor, int criterionScore)
        {
            if (!MasterDataService.IsEvaluationItemExist(evaluationItemId))
                throw new Exception("آیتم ارزیابی یافت نشد");
            var jobEvaluatedItem = findEvaluatedItem(id);
            jobEvaluatedItem.UpdateProperties(evaluationItemId , importanceFactor , criterionScore);
            if (EvaluatedItems.GroupBy(p => new { p.EvaluationItemId })
                .Where(p => p.Count() > 1).Any())
                throw new Exception("آیتم موثر بر شغل تکراریست");
        }

        public void RemoveEvaluatedItem(long id)
        {
            var jobEvaluatedItem = findEvaluatedItem(id);
            EvaluatedItems.Remove(jobEvaluatedItem);
        }
        #endregion

        #endregion

        #region private methods
        private JobEvaluatedItemMD findEvaluatedItem(long id)
        {
            var jobEvaluatedItem = EvaluatedItems.FirstOrDefault(c => c.Id == id);
            if (jobEvaluatedItem == null)
                throw new Exception("آیتم موثر بر شغل یافت نشد");

            return jobEvaluatedItem;
        }
        #endregion

    }
}
