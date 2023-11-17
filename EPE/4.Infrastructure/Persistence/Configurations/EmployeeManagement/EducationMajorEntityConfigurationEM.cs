﻿using EPE.Domain.EmployeeManagement.Aggregates;
using EPE.Domain.EmployeeManagement.ValueObjects.Education;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Infrastructure.Persistence.Configurations.EmployeeManagement
{
    internal class EducationMajorEntityConfigurationEM : IEntityTypeConfiguration<EducationMajorEM>
    {

        public void Configure(EntityTypeBuilder<EducationMajorEM> builder)
        {
            builder.ToTable(null, el => el.ExcludeFromMigrations());
            builder.ToSqlQuery("select * from EducationMajors");
        }
    }
}