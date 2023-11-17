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
    public class MasterDataEducationMajorEntityConfigurationMD : IEntityTypeConfiguration<EducationMajorMD>
    {
        public void Configure(EntityTypeBuilder<EducationMajorMD> builder)
        {
            builder.ToTable("EducationMajors");
        }
    }
}
