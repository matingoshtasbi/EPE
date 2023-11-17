using EPE.Application.Core.Domain;
using EPE.Domain.MasterData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.MasterData.Aggregates
{
    public class MilitaryServiceStatusMD : Entity<int>
    {
        #region constractors
        public MilitaryServiceStatusMD()
        {

        }
        public MilitaryServiceStatusMD(string title, IMasterDataService masterDataService)
        {
            this.MasterDataService = masterDataService;
            validate(title);
            Title = title;
        }
        #endregion

        #region properties
        private IMasterDataService MasterDataService = default!;
        public string Title { get; set; }
        #endregion

        #region public methods
        public void UpdateProperties(int id, string title, IMasterDataService masterDataService)
        {
            this.MasterDataService = masterDataService;
            validate(id, title);
            Title = title;
        }
        #endregion

        #region private methods
        private void validate(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("عنوان وضعیت خدمت اجباریست");
            if (MasterDataService.IsMilitaryServiceStatusTitleExist(title, 0))
                throw new Exception("عنوان وضعیت خدمت اجباریست");
        }
        private void validate(int id, string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("عنوان وضعیت خدمت اجباریست");
            if (MasterDataService.IsMilitaryServiceStatusTitleExist(title, id))
                throw new Exception("عنوان وضعیت خدمت اجباریست");
        }
        #endregion
    }
}
