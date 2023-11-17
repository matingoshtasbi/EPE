using EPE.Application.Core.Abstractions;
using EPE.Application.Core.Infrastructure;
using EPE.Domain.EmployeeManagement.ValueObjects.Education;
using EPE.Infrastructure.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Infrastructure.Persistence.Repositories.EmployeeManagement
{
    public class EducationMajorRepositoryEM : Repository<EducationMajorEM, int>, IEducationMajorRepositoryEM
    {
        #region members
        private CommandDbContext _dbContext = default!;
        #endregion

        #region constractor
        public EducationMajorRepositoryEM(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = unitOfWork.DbContext as CommandDbContext;
        }
        #endregion
    }
}
