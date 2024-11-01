using Core.Abstractions;
using Core.Models;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class EmployeeRepository : IEmployee
    {
        private readonly KpoDbContext context;

        public EmployeeRepository(KpoDbContext context)
        {
            this.context = context;
        }
        public async Task<Guid> Create(Employee employee)
        {
            var employeeEntity = new EmployeeEntity
            {
                Id = employee.Id,
                Login = employee.Login,
                LastName = employee.LastName,
                Name = employee.Name,
                Password = employee.Password,
            };

            await context.Employees.AddAsync(employeeEntity);
            await context.SaveChangesAsync();
            return employeeEntity.Id;
        }

        public async Task Delete(Guid id)
        {
            var employee = await context.Employees.FindAsync(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();  
            }
        }

        public async Task<List<Employee>> GetAll()
        {
            var employeeEntities = await context.Employees.AsNoTracking().ToListAsync();

            var employees = employeeEntities
                .Select(e => Employee.Create(e.Id,e.Login,e.Password,e.Name,e.LastName,e.Position).Employee).ToList();

            return employees;
        }

        public async Task<Employee> GetById(Guid id)
        {
            var e = await context.Employees.FindAsync(id);

            return Employee.Create(e.Id,e.Login,e.Password,e.Name,e.LastName,e.Position).Employee;
        }

        public async Task Update(Employee employee)
        {
            var employeeEntity = await context.Employees.FindAsync(employee.Id);

            employeeEntity.Login = employee.Login;
            employeeEntity.Password = employee.Password;
            employeeEntity.Name = employee.Name;
            employeeEntity.LastName = employee.LastName;
            employeeEntity.Position = employee.Position;

            await context.SaveChangesAsync();
        }
    }
}
