using EPE.Application.Core.Domain;
using EPE.Domain.MasterData.Services;

namespace EPE.Domain.MasterData.Aggregates
{
    public class GenderMD : Entity<int>
    {
        #region constractors
        public GenderMD()
        {

        }

        public GenderMD(string title, IMasterDataService masterDataService)
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
                throw new Exception("عنوان جنسیت اجباریست");
            if (MasterDataService.IsGenderTitleExist(title, 0))
                throw new Exception("عنوان جنسیت تکراریست");
        }

        private void validate(int id , string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("عنوان جنسیت اجباریست");
            if (MasterDataService.IsGenderTitleExist(title, id))
                throw new Exception("عنوان جنسیت تکراریست");
        }
        #endregion

        #region public methods
        public void UpdateProperties(int id , string title, IMasterDataService masterDataService)
        {
            MasterDataService = masterDataService;
            validate(id , title);
            Title = title;
        }
        #endregion
    }
}
