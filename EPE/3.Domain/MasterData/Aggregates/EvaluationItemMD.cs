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
    public class EvaluationItemMD : Entity<int>
    {
        #region constractors
        public EvaluationItemMD()
        {

        }

        public EvaluationItemMD(int meritItemId , string title , string description , IMasterDataService masterDataService)
        {
            MasterDataService = masterDataService;
            validate(meritItemId , title);
            MeritItemId = meritItemId;
            Title = title;
            Description = description;
        }

        #endregion

        #region properties
        [NotMapped]
        public int MeritId { get; set; }
        public int MeritItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IMasterDataService MasterDataService = default!;
        #endregion

        #region private methods
        private void validate(int meritItemId, string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("عنوان آیتم ارزیابی خالیست");

            if (MasterDataService.IsEvaluationItemTitleInMeritItemExist(title , 0 , meritItemId))
                throw new Exception("عنوان آیتم ارزیابی در این آیتم شایستگی تکراریست");

            if (!MasterDataService.IsMeritItemExist(meritItemId))
                throw new Exception("آیتم ارزیابی یافت نشد");
        }

        private void validate(int id , int meritItemId, string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("عنوان آیتم ارزیابی خالیست");

            if (MasterDataService.IsEvaluationItemTitleInMeritItemExist(title, id, meritItemId))
                throw new Exception("عنوان آیتم ارزیابی در این آیتم شایستگی تکراریست");

            if (!MasterDataService.IsMeritItemExist(meritItemId))
                throw new Exception("آیتم ارزیابی یافت نشد");
        }
        #endregion

        #region public methods
        public void UpdateProperties(int id, int meritItemId, string title, string description, IMasterDataService masterDataService)
        {
            MasterDataService = masterDataService;
            validate(id , meritItemId, title);
            MeritItemId = meritItemId;
            Title = title;
            Description = description;
        }
        #endregion

    }
}
