using EPE.Domain.MasterData.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Infrastructure.Persistence.Configurations.MasterData
{
    public class MasterDataJobEntityConfigurationMD : IEntityTypeConfiguration<JobMD>
    {
        public void Configure(EntityTypeBuilder<JobMD> builder)
        {
            builder.ToTable("Jobs");
            builder.HasMany(c => c.EvaluatedItems).WithOne().OnDelete(DeleteBehavior.Cascade);

        }
    }
}
