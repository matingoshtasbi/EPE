using EPE.Domain.MasterData.Aggregates;
using EPE.Domain.EmployeeManagement.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.MasterData.Services
{
    public class MasterDataService : IMasterDataService
    {

        #region members
        private IEmployeeRepository _employeeRepository;
        private IEducationLevelRepositoryMD _educationLevelRepository;
        private IEducationMajorRepositoryMD _educationMajorRepository;
        private IPhysicalInfoRepositoryMD _physicalInfoRepository;
        private IMaritalStatusRepositoryMD _maritalStatusRepository;
        private IGenderRepositoryMD _genderRepository;
        private IMilitaryServiceStatusRepositoryMD _militaryServiceStatusRepository;
        private IJobRepositoryMD _jobRepository;
        private IMeritRepositoryMD _meritRepository;
        private IMeritItemRepositoryMD _meritItemRepository;
        private IEvaluationItemRepositoryMD _evaluationItemRepository;
        private IJobEvaluatedItemRepositoryMD _jobEvaluatedItemRepository;
        #endregion

        #region constrator
        public MasterDataService(IEmployeeRepository employeeRepository,
                                IEducationLevelRepositoryMD educationLevelRepository,
                                IEducationMajorRepositoryMD educationMajorRepository,
                                IPhysicalInfoRepositoryMD physicalInfoRepository,
                                IMaritalStatusRepositoryMD maritalStatusRepository,
                                IGenderRepositoryMD genderRepository,
                                IMilitaryServiceStatusRepositoryMD militaryServiceStatusRepository,
                                IJobRepositoryMD jobRepositoryMD,
                                IMeritRepositoryMD meritRepository,
                                IMeritItemRepositoryMD meritItemRepository,
                                IEvaluationItemRepositoryMD evaluationItemRepository,
                                IJobEvaluatedItemRepositoryMD jobEvaluatedItemRepository)
        {
            _employeeRepository = employeeRepository;
            _educationLevelRepository = educationLevelRepository;
            _educationMajorRepository = educationMajorRepository;
            _physicalInfoRepository = physicalInfoRepository;
            _maritalStatusRepository = maritalStatusRepository;
            _genderRepository = genderRepository;
            _militaryServiceStatusRepository = militaryServiceStatusRepository;
            _jobRepository = jobRepositoryMD;
            _meritRepository = meritRepository;
            _meritItemRepository = meritItemRepository;
            _evaluationItemRepository = evaluationItemRepository;
            _jobEvaluatedItemRepository = jobEvaluatedItemRepository;
        }
        #endregion

        #region private methods
        private bool canRemoveEducationLevel(int educationLevelId)
        {
            return !_employeeRepository.Get(c => c.Educations.Any(c => c.LevelId == educationLevelId)).Any();
        }
        private bool canRemoveEducationMajor(int educationMajorId)
        {
            return !_employeeRepository.Get(c => c.Educations.Any(c => c.LevelId == educationMajorId)).Any();
        }
        private bool canRemovePhysicalInfo(int physicalInfoId)
        {
            return !_employeeRepository.Get(c => c.PhysicalInfo.Any(c => c.PhysicalInfoId == physicalInfoId)).Any();
        }
        private bool canRemoveMaritalStatus(int maritalStatusId)
        {
            return !_employeeRepository.Get(c => c.MaritalStatusId == maritalStatusId).Any();
        }
        private bool canRemoveGender(int genderId)
        {
            return !_employeeRepository.Get(c => c.GenderId == genderId).Any();
        }
        private bool canRemoveMerit(int meritId)
        {
            var meritItemIds = _meritItemRepository.Get(c => c.MeritId == meritId).Select(m => m.Id);
            var evaluationItemIds = _evaluationItemRepository.Get(c => meritItemIds.Contains(c.MeritItemId)).Select(e => e.Id);
            var thisMeritHaveAnyJobEvaluateItem = _jobEvaluatedItemRepository.Get(c => evaluationItemIds.Contains(c.EvaluationItemId)).Any();
            return !thisMeritHaveAnyJobEvaluateItem;
        }
        private bool canRemoveMeritItem(int meritItemId)
        {
            var evaluationItemIds = _evaluationItemRepository.Get(c => c.MeritItemId == meritItemId).Select(e => e.Id);
            var thisMeritItemHaveAnyJobEvaluateItem = _jobEvaluatedItemRepository.Get(c => evaluationItemIds.Contains(c.EvaluationItemId)).Any();
            return !thisMeritItemHaveAnyJobEvaluateItem;
        }
        private bool canRemoveEvaluationItem(int evaluationItemId)
        {
            var thisEvaluationItemHaveAnyJobEvaluateItem = _jobEvaluatedItemRepository.Get(c => c.EvaluationItemId == evaluationItemId).Any();
            return !thisEvaluationItemHaveAnyJobEvaluateItem;
        }
        private bool canRemoveJob(int jobId)
        {
            return !_employeeRepository.Get(c => c.JobId == jobId).Any();
        }
        private bool canRemoveMilitaryServiceStatus(int militaryServiceStatusId)
        {
            return !_employeeRepository.Get(c => c.MilitaryServiceStatusId == militaryServiceStatusId).Any();
        }
        #endregion

        #region public methods

        #region education level
        public void RemoveEducationLevel(int educationLevelId)
        {
            if (canRemoveEducationLevel(educationLevelId))
            {
                _educationLevelRepository.Remove(educationLevelId);
            }
            else
            {
                throw new Exception("مقطع تحصیلی در کارمندانان استفاده شده است و امکان حذف ندارد");
            }
        }
        public bool IsEducationLevelTitleExist(string title, int expectId)
        {
            return _educationLevelRepository.Get(c => c.Title == title && c.Id != expectId).Any();
        }
        public bool IsEducationLevelValueExist(int value, int expectId)
        {
            return _educationLevelRepository.Get(c => c.Order == value && c.Id != expectId).Any();
        }
        public bool IsEducationLevelExist(int levelId)
        {
           return _educationLevelRepository.Get(levelId) == null;   
        }
        #endregion

        #region education major
        public void RemoveEducationMajor(int educationMajorId)
        {
            if (canRemoveEducationMajor(educationMajorId))
            {
                _educationMajorRepository.Remove(educationMajorId);
            }
            else
            {
                throw new Exception("رشته تحصیلی در کارمندان استفاده شده است و امکان حذف ندارد");
            }
        }
        public bool IsEducationMajorTitleExist(string title, int expectId)
        {
            return _educationMajorRepository.Get(c => c.Title == title && c.Id != expectId).Any();
        }
        #endregion

        #region physicalInfo
        public void RemovePhysicalInfo(int physicalInfoId)
        {
            if (canRemovePhysicalInfo(physicalInfoId))
            {
                _physicalInfoRepository.Remove(physicalInfoId);
            }
            else
            {
                throw new Exception("آیتم فیزیکی در کارمندان استفاده شده است و امکان حذف ندارد");
            }
        }
        public bool IsPhysicalInfoTitleExist(string title, int expectId)
        {
            return _physicalInfoRepository.Get(c => c.Title == title && c.Id != expectId).Any();
        }
        #endregion


        #region maritalStatus
        public void RemoveMaritalStatus(int maritalStatusId)
        {
            if (canRemoveMaritalStatus(maritalStatusId))
            {
                _maritalStatusRepository.Remove(maritalStatusId);
            }
            else
            {
                throw new Exception("وضعیت تاهل در کارمندان استفاده شده است و امکان حذف ندارد");
            }
        }

        public bool IsMaritalStatusTitleExist(string title, int expectId)
        {
            return _maritalStatusRepository.Get(c => c.Title == title && c.Id != expectId).Any();
        }

        #endregion

        #region gender
        public void RemoveGender(int genderId)
        {
            if (canRemoveGender(genderId))
            {
                _genderRepository.Remove(genderId);
            }
            else
            {
                throw new Exception("جنسیت در کارمندان استفاده شده است و امکان حذف ندارد");
            }
        }

        public bool IsGenderTitleExist(string title, int expectId)
        {
            return _genderRepository.Get(c => c.Title == title && c.Id != expectId).Any();
        }

        #endregion

        #region job
        public void RemoveJob(int jobId)
        {
            if (canRemoveJob(jobId))
            {
                _jobRepository.Remove(jobId);
            }
            else
            {
                throw new Exception("شغل در بخش کارمندان استفاده شده است  و امکان حذف ندارد");
            }
        }

        public bool IsJobExist(int jobId)
        {
            return _jobRepository.Get(c => c.Id == jobId).Any();
        }

        public bool IsJobTitleExist(string title, int expectId)
        {
            return _jobRepository.Get(c => c.Title == title && c.Id != expectId).Any();
        }
        #endregion

        #region militaryServiceStatus
        public void RemoveMilitaryServiceStatus(int militaryServiceStatusId)
        {
            if (canRemoveMilitaryServiceStatus(militaryServiceStatusId))
            {
                _militaryServiceStatusRepository.Remove(militaryServiceStatusId);
            }
            else
            {
                throw new Exception("وضعیت خدمت در بخش کارمندان استفاده شده است  و امکان حذف ندارد");
            }
        }

        public bool IsMilitaryServiceStatusTitleExist(string title, int expectId)
        {
            return _militaryServiceStatusRepository.Get(c => c.Title == title && c.Id != expectId).Any();
        }


        #endregion

        #region merit
        public void RemoveMerit(int meritId)
        {
            if (canRemoveMerit(meritId))
            {
                _meritRepository.Remove(meritId);
            }
            else
            {
                throw new Exception("بر اساس این نوع شایستگی ، آیتم ارزیابی موثر بر شغل ثبت شده و امکان حذف ندارد");
            }
        }

        public bool IsMeritTitleExist(string title, int expectId)
        {
            return _meritRepository.Get(c => c.Title == title && c.Id != expectId).Any();
        }

        public bool IsMeritExist(int meritId)
        {
            return _meritRepository.Get(c => c.Id == meritId).Any();
        }
        #endregion

        #region meritItem
        public bool IsMeritItemTitleInMeritExist(string title, int expectId, int meritId)
        {
            return _meritItemRepository.Get(c => c.Title == title && c.MeritId == meritId && c.Id != expectId).Any();
        }

        public bool IsMeritItemExist(int meritItemId)
        {
            return _meritItemRepository.Get(c => c.Id == meritItemId).Any();
        }

        public void RemoveMeritItem(int meritItemId)
        {
            if (canRemoveMeritItem(meritItemId))
            {
                _meritItemRepository.Remove(meritItemId);
            }
            else
            {
                throw new Exception("بر اساس این آیتم شایستگی ، آیتم ارزیابی موثر بر شغل ثبت شده و امکان حذف ندارد");
            }
        }
        #endregion

        #region EvaluationItem
        public bool IsEvaluationItemTitleInMeritItemExist(string title, int expectId, int meritItemId)
        {
            return _evaluationItemRepository.Get(c => c.Title == title && c.MeritItemId == meritItemId && c.Id != expectId).Any();
        }

        public bool IsEvaluationItemExist(int evaluationItemId)
        {
            return _evaluationItemRepository.Get(c => c.Id == evaluationItemId).Any();
        }

        public void RemoveEvaluationItem(int evaluationItemId)
        {
            if (canRemoveEvaluationItem(evaluationItemId))
            {
                _evaluationItemRepository.Remove(evaluationItemId);
            }
            else
            {
                throw new Exception("بر اساس این آیتم ارزیابی ، آیتم ارزیابی موثر بر شغل ثبت شده و امکان حذف ندارد");
            }
        }
        #endregion

        #endregion
    }
}
