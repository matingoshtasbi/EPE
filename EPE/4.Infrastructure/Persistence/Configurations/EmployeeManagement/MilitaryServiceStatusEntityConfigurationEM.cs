using EPE.Domain.EmployeeManagement.ValueObjects.MilitaryServiceStatus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Infrastructure.Persistence.Configurations.EmployeeManagement
{
    internal class MilitaryServiceStatusEntityConfigurationEM : IEntityTypeConfiguration<MilitaryServiceStatusEM>
    {

        public void Configure(EntityTypeBuilder<MilitaryServiceStatusEM> builder)
        {
            builder.ToTable(null, el => el.ExcludeFromMigrations());
            builder.ToSqlQuery("select * from MilitaryServiceStatuses");
        }
    }
}
