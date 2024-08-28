using EmployeeManagmentAPI.Data;
using EmployeeManagmentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeesController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetEmployee(int id)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            var subordinates = await _context.Employees
                .Where(e => e.ManagerId == id)
                .ToListAsync();

            var manager = await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employee.ManagerId);

            return Ok(new
            {
                Employee = employee,
                Subordinates = subordinates,
                Manager = manager
            });
        }


        [HttpGet("{FirstName}/search")]
        public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployees(string FirstName)
        {
            var employees = await _context.Employees
                .Where(e => e.FirstName.Contains(FirstName))
                .ToListAsync();

            return Ok(employees);
        }

        [HttpGet("{id}/subordinates")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetSubordinates(int id)
        {
            var subordinates = await _context.Employees
                .Where(e => e.ManagerId == id)
                .ToListAsync();

            return Ok(subordinates);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest(new { message = "Employee ID mismatch" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (employee.ManagerId.HasValue && employee.ManagerId == id)
            {
                return BadRequest(new { message = "An employee cannot be their own manager." });
            }
            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound(new { message = "Employee not found" });
                }
                else
                {
                    throw;
                }
            }

            var updatedEmployee = await _context.Employees.FindAsync(id);
            return Ok(updatedEmployee); 
        }


        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
