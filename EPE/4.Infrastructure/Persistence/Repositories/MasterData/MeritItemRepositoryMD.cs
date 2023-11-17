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
    public class MeritItemRepositoryMD : Repository<MeritItemMD, int>, IMeritItemRepositoryMD
    {
        #region members
        private CommandDbContext _dbContext = default!;
        #endregion

        #region constractor
        public MeritItemRepositoryMD(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = unitOfWork.DbContext as CommandDbContext;
        }
        #endregion

        #region public methods
        public List<MeritItemMD> GetByMeritId(int id)
        {
            return _dbContext.MDMeritItems.Where(x => x.MeritId == id).ToList();
        }
        #endregion
    }
}
