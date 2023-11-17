using EPE.Application.Core.Abstractions;
using EPE.Application.Core.Infrastructure;
using EPE.Domain.MasterData.Aggregates;
using EPE.Infrastructure.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Infrastructure.Persistence.Repositories.MasterData
{
    public class EvaluationItemRepositoryMD : Repository<EvaluationItemMD, int>, IEvaluationItemRepositoryMD
    {
        #region members
        private CommandDbContext _dbContext = default!;
        #endregion

        #region constractor
        public EvaluationItemRepositoryMD(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = unitOfWork.DbContext as CommandDbContext;
        }
        #endregion

        #region public methods
        public List<EvaluationItemMD> GetByMeritItemId(int id)
        {
            return _dbContext.MDEvaluationItems.Where(c => c.MeritItemId == id).ToList();
        }

        public List<EvaluationItemMD> GetByMeritItemIds(IEnumerable<int> ids)
        {
            return _dbContext.MDEvaluationItems.Where(c => ids.Contains(c.MeritItemId)).ToList();
        }
        #endregion
    }
}
