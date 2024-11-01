using Core.Models;

namespace Core.Abstractions
{
    public interface IEmployee
    {
        Task<Employee> GetById(Guid id);
        Task<List<Employee>> GetAll();
        Task<Guid> Create(Employee employee);
        Task Update(Employee employee);
        Task Delete(Guid id);
    }
}
