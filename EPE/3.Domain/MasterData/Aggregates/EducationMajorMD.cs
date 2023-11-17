using EPE.Application.Core.Domain;
using EPE.Domain.MasterData.Services;

namespace EPE.Domain.MasterData.Aggregates
{
    public class EducationMajorMD : Entity<int>
    {
        #region constractor
        public EducationMajorMD()
        {

        }
        public EducationMajorMD(string title, IMasterDataService masterDataService)
        {
            MasterDataService = masterDataService;
            validate(title);
            Title = title;
        }

        #endregion

        #region properties
        public IMasterDataService MasterDataService = default!;
        public string Title { get; set; }

        #endregion

        #region public methods
        public void UpdateProperties(int id , string title, IMasterDataService masterDataService)
        {
            MasterDataService = masterDataService;
            validate(id , title);
            Title = title;
        }
        #endregion

        #region private methods
        private void validate(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("عنوان رشته ی تحصیلی اجباریست");
            if (MasterDataService.IsEducationMajorTitleExist(title, 0))
                throw new Exception("عنوان رشته ی تحصیلی اجباریست");

        }

        private void validate(int id , string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("عنوان رشته ی تحصیلی اجباریست");
            if (MasterDataService.IsEducationMajorTitleExist(title, id))
                throw new Exception("عنوان رشته ی تحصیلی اجباریست");

        }
        #endregion
    }
}
