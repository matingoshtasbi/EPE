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
    public class EducationMajorRepositoryMD: Repository<EducationMajorMD, int>, IEducationMajorRepositoryMD
    {
        #region members
        private CommandDbContext _dbContext = default!;
        #endregion

        #region constractor
        public EducationMajorRepositoryMD(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = unitOfWork.DbContext as CommandDbContext;
        }
        #endregion
    }
}
