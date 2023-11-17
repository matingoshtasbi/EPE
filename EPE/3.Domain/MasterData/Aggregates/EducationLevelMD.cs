using EPE.Application.Core.Domain;
using EPE.Domain.MasterData.Services;

namespace EPE.Domain.MasterData.Aggregates
{
    public class EducationLevelMD : Entity<int>
    {
        #region constractor
        public EducationLevelMD()
        {

        }

        public EducationLevelMD(string title, int value, IMasterDataService masterDataService)
        {
            MasterDataService = masterDataService;
            validate(title, value);
            Title = title;
            Order = value;
        }

        #endregion

        #region properties
        public IMasterDataService MasterDataService = default!;
        public string Title { get; set; } = default!;
        public int Order { get; set; }

        #endregion

        #region public methods
        public void UpdateProperties(int id , string title, int value, IMasterDataService masterDataService)
        {
            MasterDataService = masterDataService;
            validate(id , title, value);
            Title = title;
            Order = value;
        }
        #endregion

        #region private methods
        private void validate(string title, int order)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("عنوان مقطع تحصیلی اجباریست");
            if (MasterDataService.IsEducationLevelTitleExist(title, 0))
                throw new Exception("عنوان مقطع تحصیلی تکراریست");

        }

        private void validate(int id, string title, int order)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("عنوان مقطع تحصیلی اجباریست");
            if (MasterDataService.IsEducationLevelTitleExist(title, id))
                throw new Exception("عنوان مقطع تحصیلی تکراریست");

        }
        #endregion
    }
}
