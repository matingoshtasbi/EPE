namespace EPE.Domain.MasterData.Services
{
    public interface IMasterDataService
    {
        void RemoveEducationLevel(int educationLevelId);
        void RemoveEducationMajor(int educationMajorId);
        void RemovePhysicalInfo(int physicalInfoId);
        void RemoveMaritalStatus(int id);
        void RemoveGender(int id);
        void RemoveMilitaryServiceStatus(int id);
        bool IsEducationLevelExist(int levelId);
        bool IsEducationLevelTitleExist(string title, int expectId);
        bool IsEducationLevelValueExist(int value, int expectId);
        bool IsEducationMajorTitleExist(string title, int expectId);
        bool IsPhysicalInfoTitleExist(string title, int expectId);
        bool IsMaritalStatusTitleExist(string title, int expectId);
        bool IsGenderTitleExist(string title, int expectId);
        bool IsMilitaryServiceStatusTitleExist(string title, int expectId);
        bool IsJobTitleExist(string title, int id);
        void RemoveJob(int id);
        bool IsMeritTitleExist(string title, int expectId);
        void RemoveMerit(int meritId);
        bool IsMeritExist(int meritId);
        bool IsMeritItemTitleInMeritExist(string title , int id, int meritId);
        bool IsEvaluationItemTitleInMeritItemExist(string title, int v, int meritItemId);
        bool IsJobExist(int jobId);
        bool IsMeritItemExist(int meritItemId);
        bool IsEvaluationItemExist(int evaluationItemId);
        void RemoveMeritItem(int id);
        void RemoveEvaluationItem(int id);
    }
}