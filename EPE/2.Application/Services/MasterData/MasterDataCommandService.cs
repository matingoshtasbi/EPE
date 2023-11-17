using AutoMapper;
using EPE.Application.Abstractions.MasterData;
using EPE.Application.DTOs.MasterData;
using EPE.Domain.MasterData.Aggregates;
using EPE.Domain.MasterData.ParameterObjects;
using EPE.Domain.MasterData.Services;
using EPE.Infrastructure.Persistence.Repositories.MasterData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.Services.MasterData
{
    public class MasterDataCommandService : IMasterDataCommandService
    {
        #region members
        private readonly IMapper _mapper;
        private readonly IEducationLevelRepositoryMD _educationLevelRepository;
        private readonly IEducationMajorRepositoryMD _educationMajorRepository;
        private readonly IPhysicalInfoRepositoryMD _physicalInfoRepository;
        private readonly IMaritalStatusRepositoryMD _maritalStatusRepository;
        private readonly IMasterDataService _masterDataService;
        private readonly IGenderRepositoryMD _genderRepository;
        private readonly IMilitaryServiceStatusRepositoryMD _militaryServiceStatusRepository;
        private readonly IJobRepositoryMD _jobRepository;
        private readonly IMeritRepositoryMD _meritRepository;
        private readonly IMeritItemRepositoryMD _meritItemRepository;
        private readonly IEvaluationItemRepositoryMD _evaluationItemRepository;
        private readonly IServiceProvider _provider;
        #endregion

        #region constractors
        public MasterDataCommandService(IMapper mapper,
            IEducationLevelRepositoryMD educationLevelRepository,
            IEducationMajorRepositoryMD educationMajorRepository,
            IPhysicalInfoRepositoryMD physicalInfoRepository,
            IMaritalStatusRepositoryMD maritalStatusRepository,
            IMasterDataService masterDataService,
            IGenderRepositoryMD genderRepository,
            IMilitaryServiceStatusRepositoryMD militaryServiceStatusRepository,
            IJobRepositoryMD jobRepository,
            IMeritRepositoryMD meritRepository,
            IMeritItemRepositoryMD meritItemRepository,
            IEvaluationItemRepositoryMD evaluationItemRepository,
            IServiceProvider provider)
        {
            _mapper = mapper;
            _educationLevelRepository = educationLevelRepository;
            _educationMajorRepository = educationMajorRepository;
            _physicalInfoRepository = physicalInfoRepository;
            _maritalStatusRepository = maritalStatusRepository;
            _masterDataService = masterDataService;
            _genderRepository = genderRepository;
            _militaryServiceStatusRepository = militaryServiceStatusRepository;
            _jobRepository = jobRepository;
            _meritRepository = meritRepository;
            _meritItemRepository = meritItemRepository;
            _evaluationItemRepository = evaluationItemRepository;
            _provider = provider;
        }
        #endregion

        #region private methods
        private void addEvaluatedItems(List<JobEvaluatedItemRequest> evaluatedItems, JobMD job)
        {
            foreach (var item in evaluatedItems)
            {
                job.AddEvaluatedItem(item.EvaluationItemId , item.ImportanceFactor , item.CriterionScore);
            }
        }

        private void updateEvaluatedItems(List<JobEvaluatedItemRequest> evaluatedItems, JobMD job)
        {
            foreach (var item in evaluatedItems)
            {
                if (item.Id == 0 && !item.IsDeleted)
                {
                    job.AddEvaluatedItem(item.EvaluationItemId, item.ImportanceFactor, item.CriterionScore);
                    continue;
                }

                if (item.IsDeleted)
                {
                    if (job.EvaluatedItems.Any(x => x.Id == item.Id))
                    {
                        job.RemoveEvaluatedItem(item.Id);
                    }
                }
                else
                    job.UpdateEvaluatedItem(item.Id, item.EvaluationItemId, item.ImportanceFactor, item.CriterionScore);

            }
        }
        #endregion

        #region public methods

        #region education level
        public async Task<int> AddEducationLevel(EducationLevelRequest request)
        {
            var level = MasterDataFactory.CreateLevel(request.Title, request.Order, _masterDataService);
            _educationLevelRepository.Add(level);
            await _educationLevelRepository.UnitOfWork.SaveChangesAsync();
            return level.Id;
        }
        public async Task UpdateEducationLevel(EducationLevelRequest request)
        {
            if (request.Id == null)
                throw new Exception("شناسه مقطع تحصیلی اجباریست");

            var level = _educationLevelRepository.Get(request.Id);
            if (level == null)
                throw new Exception("مقطع تحصیلی یافت نشد");
            level.UpdateProperties(request.Id, request.Title, request.Order, _masterDataService);
            await _educationLevelRepository.UnitOfWork.SaveChangesAsync();
        }
        public async Task RemoveEducationLevel(int id)
        {
            if (_educationLevelRepository.Get(id) == null)
                throw new Exception("مقطع تحصیلی یافت نشد");
            _masterDataService.RemoveEducationLevel(id);
            await _educationLevelRepository.UnitOfWork.SaveChangesAsync();
        }
        #endregion

        #region education major
        public async Task<int> AddEducationMajor(EducationMajorRequest request)
        {

            var major = MasterDataFactory.CreateMajor(request.Title, _masterDataService);
            _educationMajorRepository.Add(major);
            await _educationMajorRepository.UnitOfWork.SaveChangesAsync();
            return major.Id;
        }
        public async Task UpdateEducationMajor(EducationMajorRequest request)
        {
            if (request.Id == null)
                throw new Exception("شناسه رشته تحصیلی اجباریست");

            var major = _educationMajorRepository.Get(request.Id);
            if (major == null)
                throw new Exception("رشته تحصیلی یافت نشد");
            major.UpdateProperties(request.Id, request.Title, _masterDataService);
            await _educationMajorRepository.UnitOfWork.SaveChangesAsync();
        }
        public async Task RemoveEducationMajor(int id)
        {
            if (_educationMajorRepository.Get(id) == null)
                throw new Exception("رشته تحصیلی یافت نشد");
            _masterDataService.RemoveEducationMajor(id);
            await _educationMajorRepository.UnitOfWork.SaveChangesAsync();
        }
        #endregion

        #region pyhsicalInfo
        public async Task<int> AddPhysicalInfo(PhysicalInfoRequest request)
        {
            var physical = MasterDataFactory.CreatePhysicalInfo(request.Title, _masterDataService);
            _physicalInfoRepository.Add(physical);
            await _physicalInfoRepository.UnitOfWork.SaveChangesAsync();
            return physical.Id;
        }
        public async Task UpdatePhysicalInfo(PhysicalInfoRequest request)
        {
            if (request.Id == null)
                throw new Exception("شناسه اطلاعات فیزیکی اجباریست");

            var physical = _physicalInfoRepository.Get(request.Id);
            if (physical == null)
                throw new Exception("اطلاعات فیزیکی یافت نشد");
            physical.UpdateProperties(request.Id, request.Title, _masterDataService);
            await _physicalInfoRepository.UnitOfWork.SaveChangesAsync();
        }
        public async Task RemovePhysicalInfo(int id)
        {
            if (_physicalInfoRepository.Get(id) == null)
                throw new Exception("اطلاعات فیزیکی یافت نشد");
            _masterDataService.RemovePhysicalInfo(id);
            await _physicalInfoRepository.UnitOfWork.SaveChangesAsync();
        }
        #endregion

        #region maritalStatus
        public async Task<int> AddMaritalStatus(MaritalStatusRequest request)
        {
            var marital = MasterDataFactory.CreateMaritalStatus(request.Title, _masterDataService);
            _maritalStatusRepository.Add(marital);
            await _maritalStatusRepository.UnitOfWork.SaveChangesAsync();
            return marital.Id;
        }

        public async Task UpdateMaritalStatus(MaritalStatusRequest request)
        {
            if (request.Id == null)
                throw new Exception("شناسه وضعیت تاهل اجباریست");
            var marital = _maritalStatusRepository.Get(request.Id);
            if (marital == null)
                throw new Exception("وضعیت تاهل یافت نشد");
            marital.UpdateProperties(request.Id, request.Title, _masterDataService);
            await _maritalStatusRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task RemoveMaritalStatus(int id)
        {
            if (_maritalStatusRepository.Get(id) == null)
                throw new Exception("وضعیت تاهل یافت نشد");
            _masterDataService.RemoveMaritalStatus(id);
            await _maritalStatusRepository.UnitOfWork.SaveChangesAsync();
        }

        #endregion

        #region gender
        public async Task<int> AddGender(GenderRequest request)
        {
            var gender = MasterDataFactory.CreateGender(request.Title, _masterDataService);
            _genderRepository.Add(gender);
            await _genderRepository.UnitOfWork.SaveChangesAsync();
            return gender.Id;
        }

        public async Task UpdateGender(GenderRequest request)
        {
            if (request.Id == null)
                throw new Exception("شناسه جنسیت اجباریست");
            var gender = _genderRepository.Get(request.Id);
            if (gender == null)
                throw new Exception("جنسیت یافت نشد");
            gender.UpdateProperties(request.Id, request.Title, _masterDataService);
            await _genderRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task RemoveGender(int id)
        {
            if (_genderRepository.Get(id) == null)
                throw new Exception("جنسیت یافت نشد");
            _masterDataService.RemoveGender(id);
            await _genderRepository.UnitOfWork.SaveChangesAsync();
        }

        #endregion

        #region job
        public async Task<int> AddJob(JobRequest request)
        {
            var job = MasterDataFactory.CreateJob(request.Title, _masterDataService);

            if (request.EvaluatedItems is not null)
                addEvaluatedItems(request.EvaluatedItems, job);

            _jobRepository.Add(job);
            await _jobRepository.UnitOfWork.SaveChangesAsync();
            return job.Id;
        }

        public async Task UpdateJob(JobRequest request)
        {
            if (request.Id == null)
                throw new Exception("شناسه شغل اجباریست");
            var job = _jobRepository.Get(request.Id);
            if (job == null)
                throw new Exception("شغل یافت نشد");
            job.UpdateProperties(request.Id, request.Title, _masterDataService);

            if (request.EvaluatedItems is not null)
                updateEvaluatedItems(request.EvaluatedItems, job);

            await _jobRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task RemoveJob(int id)
        {
            if (_jobRepository.Get(id) == null)
                throw new Exception("شغل یافت نشد");
            _masterDataService.RemoveJob(id);
            await _jobRepository.UnitOfWork.SaveChangesAsync();
        }

        #endregion

        #region merit
        public async Task<int> AddMerit(MeritRequest request)
        {
            var merit = MasterDataFactory.CreateMerit(request.Title, _masterDataService);
            _meritRepository.Add(merit);
            await _meritRepository.UnitOfWork.SaveChangesAsync();
            return merit.Id;
        }

        public async Task UpdateMerit(MeritRequest request)
        {
            if (request.Id == null)
                throw new Exception("شناسه شایستگی اجباریست");
            var merit = _meritRepository.Get(request.Id);
            if (merit == null)
                throw new Exception("شایستگی یافت نشد");
            merit.UpdateProperties(request.Id, request.Title, _masterDataService);
            await _meritRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task RemoveMerit(int id)
        {
            if (_meritRepository.Get(id) == null)
                throw new Exception("شایستگی یافت نشد");
            _masterDataService.RemoveMerit(id);

            // RemoveChilds
            var meritItems = _meritItemRepository.GetByMeritId(id);
            var evaluationItems = _evaluationItemRepository.GetByMeritItemIds(meritItems.Select(c => c.Id));
            if (meritItems.Any())
                _meritItemRepository.RemoveRange(meritItems);
            if (evaluationItems.Any())
                _evaluationItemRepository.RemoveRange(evaluationItems);

            await _meritRepository.UnitOfWork.SaveChangesAsync();
        }

        #endregion

        #region meritItem
        public async Task<int> AddMeritItem(MeritItemRequest request)
        {
            var meritItem = MasterDataFactory.CreateMeritItem(request.MeritId, request.Title, _masterDataService);
            _meritItemRepository.Add(meritItem);
            await _meritItemRepository.UnitOfWork.SaveChangesAsync();
            return meritItem.Id;
        }

        public async Task UpdateMeritItem(MeritItemRequest request)
        {
            if (request.Id == null)
                throw new Exception("شناسه آیتم شایستگی اجباریست");
            var meritItem = _meritItemRepository.Get(request.Id);
            if (meritItem == null)
                throw new Exception("آیتم شایستگی یافت نشد");
            meritItem.UpdateProperties(request.Id, request.MeritId, request.Title, _masterDataService);
            await _meritItemRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task RemoveMeritItem(int id)
        {
            if (_meritItemRepository.Get(id) == null)
                throw new Exception("آیتم شایستگی یافت نشد");
            _masterDataService.RemoveMeritItem(id);

            // RemoveChilds
            var evaluationItems = _evaluationItemRepository.GetByMeritItemId(id);
            if (evaluationItems.Any())
                _evaluationItemRepository.RemoveRange(evaluationItems);

            await _meritItemRepository.UnitOfWork.SaveChangesAsync();
        }

        #endregion

        #region evaluationItem
        public async Task<int> AddEvaluationItem(EvaluationItemRequest request)
        {
            var evaluationItem = MasterDataFactory.CreateEvaluationItem(request.MeritItemId, request.Title, request.Description, _masterDataService);
            _evaluationItemRepository.Add(evaluationItem);
            await _evaluationItemRepository.UnitOfWork.SaveChangesAsync();
            return evaluationItem.Id;
        }

        public async Task UpdateEvaluationItem(EvaluationItemRequest request)
        {
            if (request.Id == null)
                throw new Exception("شناسه آیتم ارزیابی اجباریست");
            var evaluationItem = _evaluationItemRepository.Get(request.Id);
            if (evaluationItem == null)
                throw new Exception("آیتم ارزیابی یافت نشد");
            evaluationItem.UpdateProperties(request.Id, request.MeritItemId, request.Title, request.Description, _masterDataService);
            await _evaluationItemRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task RemoveEvaluationItem(int id)
        {
            if (_evaluationItemRepository.Get(id) == null)
                throw new Exception("آیتم ارزیابی یافت نشد");
            _masterDataService.RemoveEvaluationItem(id);
            await _evaluationItemRepository.UnitOfWork.SaveChangesAsync();
        }

        #endregion

        #region militaryServiceStatus
        public async Task<int> AddMilitaryServiceStatus(MilitaryServiceStatusRequest request)
        {
            var militaryServiceStatus = MasterDataFactory.CreateMilitaryServiceStatus(request.Title, _masterDataService);
            _militaryServiceStatusRepository.Add(militaryServiceStatus);
            await _militaryServiceStatusRepository.UnitOfWork.SaveChangesAsync();
            return militaryServiceStatus.Id;
        }

        public async Task UpdateMilitaryServiceStatus(MilitaryServiceStatusRequest request)
        {
            if (request.Id == null)
                throw new Exception("شناسه وضعیت خدمت اجباریست");
            var military = _militaryServiceStatusRepository.Get(request.Id);
            if (military == null)
                throw new Exception("وضعیت خدمت یافت نشد");
            military.UpdateProperties(request.Id, request.Title, _masterDataService);
            await _militaryServiceStatusRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task RemoveMilitaryServiceStatus(int id)
        {
            if (_militaryServiceStatusRepository.Get(id) == null)
                throw new Exception("وضعیت خدمت یافت نشد");
            _masterDataService.RemoveMilitaryServiceStatus(id);
            await _militaryServiceStatusRepository.UnitOfWork.SaveChangesAsync();
        }
        #endregion

        #endregion


    }
}
