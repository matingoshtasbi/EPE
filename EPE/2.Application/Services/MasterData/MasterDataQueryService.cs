using EPE.Application.Core.DTOs;
using EPE.Application.Abstractions.MasterData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPE.Infrastructure.SqlServer.DbContexts;
using EPE.Domain.EmployeeManagement.ValueObjects.Education;
using Microsoft.EntityFrameworkCore;
using EPE.Domain.MasterData.Aggregates;
using EPE.Domain.EmployeeManagement.Enums;
using EPE.Domain.MasterData.ValueObjects;
using EPE.Infrastructure.Utilities;
using System.ComponentModel.DataAnnotations;

namespace EPE.Application.Services.MasterData
{
    public class MasterDataQueryService : IMasterDataQueryService
    {
        #region members
        private readonly SqlServerCommandDbContext _dbContext;
        #endregion

        #region constarcator
        public MasterDataQueryService(SqlServerCommandDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region public methods

        #region education level
        public async Task<List<EducationLevelMD>> FindEducationLevels()
        {
            return await _dbContext.MDEducationLevels.AsNoTracking()
                .ToListAsync();
        }
        public async Task<EducationLevelMD> FindEducationLevel(int id)
        {
            return await _dbContext.MDEducationLevels
                .FirstOrDefaultAsync(c => c.Id == id) ?? null!;
        }
        #endregion

        #region education major
        public async Task<List<EducationMajorMD>> FindEducationMajors()
        {
            return await _dbContext.MDEducationMajors.AsNoTracking()
                .ToListAsync();
        }
        public async Task<EducationMajorMD> FindEducationMajor(int id)
        {
            return await _dbContext.MDEducationMajors
                      .FirstOrDefaultAsync(c => c.Id == id) ?? null!;
        }
        #endregion

        #region physicalInfo
        public async Task<List<PhysicalInfoMD>> FindPhysicalInfos()
        {
            return await _dbContext.MDPhysicalInfos.AsNoTracking()
                .ToListAsync();
        }
        public async Task<PhysicalInfoMD> FindPhysicalInfo(int id)
        {
            return await _dbContext.MDPhysicalInfos
                      .FirstOrDefaultAsync(c => c.Id == id) ?? null!;
        }
        #endregion


        #region maritalStatus
        public async Task<List<MaritalStatusMD>> FindMaritalStatuses()
        {
            return await _dbContext.MDMaritalStatuses.AsNoTracking()
                            .ToListAsync();
        }

        public async Task<MaritalStatusMD> FindMaritalStatus(int id)
        {
            return await _dbContext.MDMaritalStatuses
                       .FirstOrDefaultAsync(c => c.Id == id) ?? null!;
        }

        #endregion

        #region gender
        public async Task<List<GenderMD>> FindGenders()
        {
            return await _dbContext.MDGenders.AsNoTracking()
                            .ToListAsync();
        }

        public async Task<GenderMD> FindGender(int id)
        {
            return await _dbContext.MDGenders
                       .FirstOrDefaultAsync(c => c.Id == id) ?? null!;
        }

        #endregion

        #region militaryServiceStatus
        public async Task<List<MilitaryServiceStatusMD>> FindMilitaryServiceStatuses()
        {
            return await _dbContext.MDMilitaryServiceStatuses.AsNoTracking()
                            .ToListAsync();
        }

        public async Task<MilitaryServiceStatusMD> FindMilitaryServiceStatus(int id)
        {
            return await _dbContext.MDMilitaryServiceStatuses
                       .FirstOrDefaultAsync(c => c.Id == id) ?? null!;
        }
        #endregion

        #region job
        public async Task<List<JobMD>> FindJobs()
        {
            return await _dbContext.MDJobs.AsNoTracking()
                            .ToListAsync();
        }

        public async Task<JobMD> FindJob(int id)
        {
            var result = await _dbContext.MDJobs
                 .AsNoTracking()
                 .Include(nameof(JobMD.EvaluatedItems))
                 .FirstOrDefaultAsync(c => c.Id == id) ?? null!;
            return result;
        }

        public async Task<PageResult<JobMD>> FindJobsIncludeEvaluatedItems()
        {
            var result = new PageResult<JobMD>();

            try
            {
                var qry = _dbContext.MDJobs.AsNoTracking();
                result.TotalCount = await qry.CountAsync();
                result.Results = await qry.ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region merit
        public async Task<List<MeritMD>> FindMerits()
        {
            return await _dbContext.MDMerits.AsNoTracking()
                            .ToListAsync();
        }

        public async Task<MeritMD> FindMerit(int id)
        {
            return await _dbContext.MDMerits
                       .FirstOrDefaultAsync(c => c.Id == id) ?? null!;
        }
        #endregion

        #region meritItem
        public async Task<List<MeritItemMD>> FindMeritItems()
        {
            return await _dbContext.MDMeritItems.AsNoTracking()
                            .ToListAsync();
        }

        public async Task<MeritItemMD> FindMeritItem(int id)
        {
            return await _dbContext.MDMeritItems
                       .FirstOrDefaultAsync(c => c.Id == id) ?? null!;
        }

        public List<MeritItemMD> FindMeritItemsByMeritId(int id)
        {
            return _dbContext.MDMeritItems.AsNoTracking()
                .Where(x => x.MeritId == id).ToList();
        }
        #endregion

        #region evaluationItem
        public async Task<List<EvaluationItemMD>> FindEvaluationItems()
        {
            var evaluationItems = await _dbContext.MDEvaluationItems.AsNoTracking()
                            .ToListAsync();

            var meritItems = await FindMeritItems();
            foreach (var item in evaluationItems)
            {
                item.MeritId = meritItems.FirstOrDefault(c => c.Id == item.MeritItemId)!.MeritId;
            }

            return evaluationItems;
        }

        public async Task<EvaluationItemMD> FindEvaluationItem(int id)
        {
            return await _dbContext.MDEvaluationItems
                       .FirstOrDefaultAsync(c => c.Id == id) ?? null!;
        }

        public List<EvaluationItemMD> FindEvaluationItemsByMeritItemId(int meritItemId)
        {
            return _dbContext.MDEvaluationItems.AsNoTracking()
                     .Where(x => x.MeritItemId == meritItemId).ToList();
        }
        #endregion

        #region Contact Enum
        public async Task<List<ContactType>> FindContactTypes()
        {
            List<ContactType> result = new List<ContactType>();

            result.Add(new ContactType()
            {
                Id = (int)ContactTypeEnum.Mobile,
                Title = ContactTypeEnum.Mobile.GetAttribute<DisplayAttribute>().Name!
            });
            result.Add(new ContactType()
            {
                Id = (int)ContactTypeEnum.Telephone,
                Title = ContactTypeEnum.Telephone.GetAttribute<DisplayAttribute>().Name!
            });
            result.Add(new ContactType()
            {
                Id = (int)ContactTypeEnum.Address,
                Title = ContactTypeEnum.Address.GetAttribute<DisplayAttribute>().Name!
            });
            result.Add(new ContactType()
            {
                Id = (int)ContactTypeEnum.Email,
                Title = ContactTypeEnum.Email.GetAttribute<DisplayAttribute>().Name!
            });
            result.Add(new ContactType()
            {
                Id = (int)ContactTypeEnum.Emergency,
                Title = ContactTypeEnum.Emergency.GetAttribute<DisplayAttribute>().Name!
            });

            return result;
        }

        #endregion

        #endregion
    }
}