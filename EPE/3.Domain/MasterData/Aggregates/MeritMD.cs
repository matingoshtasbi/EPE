using EPE.Application.Core.Domain;
using EPE.Domain.MasterData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.MasterData.Aggregates
{
    public class MeritMD : Entity<int>
    {
        #region constractors
        public MeritMD()
        {

        }

        public MeritMD(string title, IMasterDataService masterDataService)
        {
            MasterDataService = masterDataService;
            validate(title);
            Title = title;
        }
        #endregion

        #region properties
        public string Title { get; set; }
        private IMasterDataService MasterDataService = default!;
        #endregion

        #region private methods
        private void validate(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("عنوان شایستگی اجباریست");
            if (MasterDataService.IsMeritTitleExist(title, 0))
                throw new Exception("عنوان شایستگی تکراریست");
        }

        private void validate(int id, string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("عنوان شایستگی اجباریست");
            if (MasterDataService.IsMeritTitleExist(title, id))
                throw new Exception("عنوان شایستگی تکراریست");
        }
        #endregion

        #region public methods
        public void UpdateProperties(int id, string title, IMasterDataService masterDataService)
        {
            MasterDataService = masterDataService;
            validate(id, title);
            Title = title;
        }
        #endregion
    }
}
