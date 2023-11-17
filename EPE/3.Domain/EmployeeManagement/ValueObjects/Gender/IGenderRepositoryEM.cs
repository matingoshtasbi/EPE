using EPE.Application.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.EmployeeManagement.ValueObjects.Gender
{
    public interface IGenderRepositoryEM : IRepository<GenderEM , int>
    {
    }
}
