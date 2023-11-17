using EPE.Application.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.MasterData.Aggregates
{
    public interface IEvaluationItemRepositoryMD : IRepository<EvaluationItemMD, int>
    {
        List<EvaluationItemMD> GetByMeritItemId(int id);
        List<EvaluationItemMD> GetByMeritItemIds(IEnumerable<int> ids);
    }
}
