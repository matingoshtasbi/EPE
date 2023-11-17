using EPE.Application.Core.Abstractions;
using EPE.Application.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.MasterData.Aggregates
{
    public interface IMilitaryServiceStatusRepositoryMD : IRepository<MilitaryServiceStatusMD , int>
    {
    }
}
