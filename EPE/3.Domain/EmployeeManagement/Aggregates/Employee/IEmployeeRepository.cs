using EPE.Application.Core.Abstractions;

namespace EPE.Domain.EmployeeManagement.Aggregates
{
    public interface IEmployeeRepository : IRepository<Employee, Guid>
    {

    }
}
