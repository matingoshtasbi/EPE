using EPE.Domain.PerformanceEvaluate.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Infrastructure.Persistence.Configurations.PerformanceEvaluate
{
    internal class PerformanceEvaluateItemEntityConfiguration : IEntityTypeConfiguration<PerformanceEvaluateItem>
    {
        public void Configure(EntityTypeBuilder<PerformanceEvaluateItem> builder)
        {
            builder.ToTable("PerformanceEvaluateItems");
        }
    }
}
