﻿using EPE.Domain.EmployeeManagement.Aggregates;
using EPE.Domain.EmployeeManagement.ValueObjects.MaritalStatus;
using EPE.Domain.EmployeeManagement.ValueObjects.PhysicalInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Infrastructure.Persistence.Configurations.EmployeeManagement
{
    internal class MaritalStatusEntityConfigurationEM : IEntityTypeConfiguration<MaritalStatusEM>
    {

        public void Configure(EntityTypeBuilder<MaritalStatusEM> builder)
        {
            builder.ToTable(null, el => el.ExcludeFromMigrations());
            builder.ToSqlQuery("select * from MaritalStatuses");
        }
    }
}