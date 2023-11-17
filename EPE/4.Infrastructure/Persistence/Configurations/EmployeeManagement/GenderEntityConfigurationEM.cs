using EPE.Domain.EmployeeManagement.ValueObjects.Gender;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Infrastructure.Persistence.Configurations.EmployeeManagement
{
    internal class GenderEntityConfigurationEM : IEntityTypeConfiguration<GenderEM>
    {
        public void Configure(EntityTypeBuilder<GenderEM> builder)
        {
            builder.ToTable(null, el => el.ExcludeFromMigrations());
            builder.ToSqlQuery("select * from Genders");
        }
    }
}
