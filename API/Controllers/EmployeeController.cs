using API.Contracts;
using Core.Abstractions;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeResponse>>> GetEmployees()
        {
            var employees = await employeeService.GetAllEmployees();
            var response = employees.Select(e => new EmployeeResponse(e.Id, e.Login,e.Password, e.Name, e.LastName, e.Position));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateEmployee([FromBody] EmployeeRequest request)
        {
            var employeeId = Guid.NewGuid(); 
            var (employee, error) = Employee.Create(employeeId, request.Login, request.Password, request.Name, request.LastName, request.Position);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            await employeeService.CreateEmployee(employee);
            return Ok(employeeId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateEmployee(Guid id, [FromBody] EmployeeRequest request)
        {
            var employee = Employee.Create(id, request.Login, request.Password, request.Name, request.LastName, request.Position).Employee;
            await employeeService.UpdateEmployee(employee);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteEmployee(Guid id)
        {
            await employeeService.DeleteEmployee(id);
            return Ok();
        }
    }
}
