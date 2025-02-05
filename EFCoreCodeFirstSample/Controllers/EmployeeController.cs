using Microsoft.AspNetCore.Mvc;
using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Models.Repository;

namespace EFCoreCodeFirstSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDataRepository<Employee> _dataRepository;

        public EmployeeController(IDataRepository<Employee> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Employee> employees = _dataRepository.GetAll();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Employee employee = _dataRepository.Get(id);
            if (employee == null) return NotFound("Employee not found.");
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            if (employee == null) return BadRequest("Employee is null.");
            _dataRepository.Add(employee);
            return CreatedAtAction(nameof(Get), new { id = employee.EmployeeId }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Employee employee)
        {
            if (employee == null) return BadRequest("Employee is null.");
            Employee employeeToUpdate = _dataRepository.Get(id);
            if (employeeToUpdate == null) return NotFound("Employee not found.");
            _dataRepository.Update(employeeToUpdate, employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Employee employee = _dataRepository.Get(id);
            if (employee == null) return NotFound("Employee not found.");
            _dataRepository.Delete(employee);
            return NoContent();
        }
    }
}
