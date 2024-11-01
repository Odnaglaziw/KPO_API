using Core.Models;

namespace Core.Abstractions
{
    public interface IEmployeeService
    {
        Task<Guid> CreateEmployee(Employee employee);
        Task DeleteEmployee(Guid id);
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(Guid id);
        Task UpdateEmployee(Employee employee);
    }

}
