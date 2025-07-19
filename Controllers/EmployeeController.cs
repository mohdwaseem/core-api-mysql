using CoreAPIWithMySQL.Models;
using CoreAPIWithMySQL.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPIWithMySQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IDapperEmployeeService _dapperService;

        public EmployeeController(IEmployeeService service, IDapperEmployeeService dapperEmployeeService)
        {
            _service = service;
            _dapperService = dapperEmployeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return Ok(await _dapperService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _service.GetByIdAsync(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            var created = await _service.AddAsync(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            var updated = await _service.UpdateAsync(id, employee);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}