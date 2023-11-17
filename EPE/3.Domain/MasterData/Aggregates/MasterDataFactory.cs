using EPE.Domain.MasterData.ParameterObjects;
using EPE.Domain.MasterData.Services;

namespace EPE.Domain.MasterData.Aggregates
{
    public class MasterDataFactory
    {
        public static EducationLevelMD CreateLevel(string title, int order , IMasterDataService masterDataService)
        {
            var level = new EducationLevelMD(title, order , masterDataService);
            return level;
        }

        public static EducationMajorMD CreateMajor(string title,IMasterDataService masterDataService)
        {
            var major = new EducationMajorMD(title , masterDataService);
            return major;
        }

        public static PhysicalInfoMD CreatePhysicalInfo(string title, IMasterDataService masterDataService)
        {
            var physical = new PhysicalInfoMD(title , masterDataService);
            return physical;
        }


        public static MaritalStatusMD CreateMaritalStatus(string title, IMasterDataService masterDataService)
        {
            var maritalStatus = new MaritalStatusMD(title, masterDataService);
            return maritalStatus;
        }

        public static GenderMD CreateGender(string title, IMasterDataService masterDataService)
        {
            var gender = new GenderMD(title, masterDataService);
            return gender;
        }

        public static MilitaryServiceStatusMD CreateMilitaryServiceStatus(string title, IMasterDataService masterDataService)
        {
            var militaryServiceStatus = new MilitaryServiceStatusMD(title, masterDataService);
            return militaryServiceStatus;
        }

        internal static JobMD CreateJob(string title, IMasterDataService masterDataService)
        {
            var job = new JobMD(title, masterDataService);
            return job;
        }

        internal static MeritMD CreateMerit(string title, IMasterDataService masterDataService)
        {
            var merit = new MeritMD(title, masterDataService);
            return merit;
        }

        internal static MeritItemMD CreateMeritItem(int meritId , string title, IMasterDataService masterDataService)
        {
            var meritItem = new MeritItemMD(meritId , title, masterDataService);
            return meritItem;
        }

        internal static JobEvaluatedItemMD CreateEvaluatedItem(int evaluationItemId, int importanceFactor, int criterionScore)
        {
            var jobEvaluatedItem = new JobEvaluatedItemMD(evaluationItemId , importanceFactor , criterionScore);
            return jobEvaluatedItem;
        }

        internal static EvaluationItemMD CreateEvaluationItem(int meritItemId, string title, string description, IMasterDataService masterDataService)
        {
            var evaluationItem = new EvaluationItemMD(meritItemId, title, description, masterDataService);
            return evaluationItem;
        }
    }
}
