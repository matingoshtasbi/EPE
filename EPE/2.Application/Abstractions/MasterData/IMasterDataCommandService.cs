using EPE.Application.DTOs.MasterData;
using EPE.Domain.MasterData.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.Abstractions.MasterData
{
    public interface IMasterDataCommandService
    {
        #region education level
        Task<int> AddEducationLevel(EducationLevelRequest request);
        Task UpdateEducationLevel(EducationLevelRequest request);
        Task RemoveEducationLevel(int id);
        #endregion

        #region education major
        Task<int> AddEducationMajor(EducationMajorRequest request);
        Task UpdateEducationMajor(EducationMajorRequest request);
        Task RemoveEducationMajor(int id);
        #endregion

        #region physicalInfo
        Task<int> AddPhysicalInfo(PhysicalInfoRequest request);
        Task UpdatePhysicalInfo(PhysicalInfoRequest request);
        Task RemovePhysicalInfo(int id);
        #endregion

        #region maritalStatus
        Task<int> AddMaritalStatus(MaritalStatusRequest request);
        Task UpdateMaritalStatus(MaritalStatusRequest request);
        Task RemoveMaritalStatus(int id);

        #endregion

        #region gender
        Task<int> AddGender(GenderRequest request);
        Task UpdateGender(GenderRequest request);
        Task RemoveGender(int id);

        #endregion

        #region militaryServiceStatus
        Task<int> AddMilitaryServiceStatus(MilitaryServiceStatusRequest request);
        Task UpdateMilitaryServiceStatus(MilitaryServiceStatusRequest request);
        Task RemoveMilitaryServiceStatus(int id);
        #endregion

        #region job
        Task<int> AddJob(JobRequest request);
        Task UpdateJob(JobRequest request);
        Task RemoveJob(int id);

        #endregion

        #region merit
        Task<int> AddMerit(MeritRequest request);
        Task UpdateMerit(MeritRequest request);
        Task RemoveMerit(int id);

        #endregion

        #region meritItem
        Task<int> AddMeritItem(MeritItemRequest request);
        Task UpdateMeritItem(MeritItemRequest request);
        Task RemoveMeritItem(int id);

        #endregion

        #region evaluationItem
        Task<int> AddEvaluationItem(EvaluationItemRequest request);
        Task UpdateEvaluationItem(EvaluationItemRequest request);
        Task RemoveEvaluationItem(int id);

        #endregion
    }
}
