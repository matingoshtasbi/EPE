using EPE.Application.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.EmployeeManagement.ValueObjects.MaritalStatus
{
    public interface IMaritalStatusRepositoryEM : IRepository<MaritalStatusEM , int>
    {
    }
}
