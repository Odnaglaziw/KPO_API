using Core.Abstractions;
using Core.Models;

namespace Application.Services
{
    
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployee employeeRepository;

        public EmployeeService(IEmployee employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<Guid> CreateEmployee(Employee employee)
        {
            return await employeeRepository.Create(employee);
        }

        public async Task DeleteEmployee(Guid id)
        {
            await employeeRepository.Delete(id);
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await employeeRepository.GetAll();
        }

        public async Task<Employee> GetEmployeeById(Guid id)
        {
            return await employeeRepository.GetById(id);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            await employeeRepository.Update(employee);
        }
    }
}
