using EPE.Domain.EmployeeManagement.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Infrastructure.Persistence.Configurations.EmployeeManagement
{
    public class EmployeeResumeEntityConfiguration
    {
        public void Configure(EntityTypeBuilder<EmployeeResume> builder)
        {
            builder.ToTable("EmployeeResumes");
        }
    }
}
