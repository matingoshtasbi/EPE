using EPE.Application.Core.Domain;
using EPE.Domain.MasterData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.MasterData.Aggregates
{
    public class MeritItemMD : Entity<int>
    {
        #region constractors
        public MeritItemMD()
        {

        }

        public MeritItemMD(int meritId, string title, IMasterDataService masterDataService)
        {
            MasterDataService = masterDataService;
            validate(meritId, title);
            MeritId = meritId;
            Title = title;
        }
        #endregion

        #region properties
        public int MeritId { get; set; }
        public string Title { get; set; }
        public IMasterDataService MasterDataService = default!;
        #endregion

        #region public methods
        public void UpdateProperties(int id, int meritId , string title, IMasterDataService masterDataService)
        {
            MasterDataService = masterDataService;
            validate(id, meritId, title);
            Title = title;
            MeritId = meritId;
        }
        #endregion

        #region private methods
        private void validate(int meritId, string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("عنوان آیتم شایستگی اجباریست");
            if (MasterDataService.IsMeritItemTitleInMeritExist(title, 0, meritId))
                throw new Exception("عنوان آیتم شایستگی در این نوع شایستگی تکراریست");
            if (!MasterDataService.IsMeritExist(meritId))
                throw new Exception("شایستگی یافت نشد");
        }

        private void validate(int id , int meritId, string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("عنوان آیتم شایستگی اجباریست");
            if (MasterDataService.IsMeritItemTitleInMeritExist(title, id, meritId))
                throw new Exception("عنوان آیتم شایستگی در این نوع شایستگی تکراریست");
            if (!MasterDataService.IsMeritExist(meritId))
                throw new Exception("شایستگی یافت نشد");
        }
        #endregion
    }
}
