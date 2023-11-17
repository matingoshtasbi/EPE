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
    internal class EmployeePerformanceEvaluateEntityConfiguration : IEntityTypeConfiguration<EmployeePerformanceEvaluate>
    {

        public void Configure(EntityTypeBuilder<EmployeePerformanceEvaluate> builder)
        {
            builder.ToTable("EmployeePerformanceEvaluates");
            builder.HasMany(c => c.MeritAverages).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.MeritItemAverages).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.PerformanceEvaluateItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
