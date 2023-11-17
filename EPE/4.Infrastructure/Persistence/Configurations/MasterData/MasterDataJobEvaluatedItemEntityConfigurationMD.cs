﻿using EPE.Domain.MasterData.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Infrastructure.Persistence.Configurations.MasterData
{
    public class MasterDataJobEvaluatedItemEntityConfigurationMD : IEntityTypeConfiguration<JobEvaluatedItemMD>
    {
        public void Configure(EntityTypeBuilder<JobEvaluatedItemMD> builder)
        {
            builder.ToTable("JobEvaluatedItems");
        }
    }
}
