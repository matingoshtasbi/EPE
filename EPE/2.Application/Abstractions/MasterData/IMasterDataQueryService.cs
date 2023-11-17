using EPE.Domain.EmployeeManagement.ValueObjects.Gender;
using EPE.Domain.EmployeeManagement.ValueObjects.MaritalStatus;
using EPE.Domain.EmployeeManagement.ValueObjects.MilitaryServiceStatus;
using EPE.Domain.EmployeeManagement.ValueObjects.PhysicalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPE.Domain.MasterData.Aggregates;
using EPE.Domain.MasterData.ValueObjects;
using EPE.Application.Core.DTOs;

namespace EPE.Application.Abstractions.MasterData
{
    public interface IMasterDataQueryService
    {
        #region education level
        Task<List<EducationLevelMD>> FindEducationLevels();
        Task<EducationLevelMD> FindEducationLevel(int id);
        #endregion

        #region education major
        Task<List<EducationMajorMD>> FindEducationMajors();
        Task<EducationMajorMD> FindEducationMajor(int id);
        #endregion

        #region physicalInfo
        Task<List<PhysicalInfoMD>> FindPhysicalInfos();
        Task<PhysicalInfoMD> FindPhysicalInfo(int id);
        #endregion

        #region maritalStatus
        Task<List<MaritalStatusMD>> FindMaritalStatuses();
        Task<MaritalStatusMD> FindMaritalStatus(int id);
        #endregion

        #region gender
        Task<List<GenderMD>> FindGenders();
        Task<GenderMD> FindGender(int id);
        #endregion

        #region militaryServiceStatus
        Task<List<MilitaryServiceStatusMD>> FindMilitaryServiceStatuses();
        Task<MilitaryServiceStatusMD> FindMilitaryServiceStatus(int id);
        #endregion

        #region job
        Task<List<JobMD>> FindJobs();
        Task<JobMD> FindJob(int id);
        Task<PageResult<JobMD>> FindJobsIncludeEvaluatedItems();
        #endregion

        #region merit
        Task<List<MeritMD>> FindMerits();
        Task<MeritMD> FindMerit(int id);

        #endregion

        #region meritItem
        Task<List<MeritItemMD>> FindMeritItems();
        Task<MeritItemMD> FindMeritItem(int id);
        List<MeritItemMD> FindMeritItemsByMeritId(int id);

        #endregion

        #region evaluationItem
        Task<List<EvaluationItemMD>> FindEvaluationItems();
        Task<EvaluationItemMD> FindEvaluationItem(int id);
        List<EvaluationItemMD> FindEvaluationItemsByMeritItemId(int meritItemId);


        #endregion

        #region contact enum
        Task<List<ContactType>> FindContactTypes();
        #endregion


    }
}
