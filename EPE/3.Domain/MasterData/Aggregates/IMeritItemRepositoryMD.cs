﻿using EPE.Application.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.MasterData.Aggregates
{
    public interface IMeritItemRepositoryMD : IRepository<MeritItemMD, int>
    {
        List<MeritItemMD> GetByMeritId(int id);
    }
}