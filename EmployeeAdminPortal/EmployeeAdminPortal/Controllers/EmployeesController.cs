using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.DTO;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext DbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetEmployees() {

            return Ok(DbContext.Employees.ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            var employee = await DbContext.Employees.FindAsync(id);
            if (employee is null)
            {
                return NotFound();
            }



            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployees(EmployeDto employeDto){

            var newEmployee = new Employee { Name=employeDto.Name,Email=employeDto.Email,Phone=employeDto.Phone,Salary=employeDto.Salary};
            DbContext.Employees.Add(newEmployee);
            DbContext.SaveChanges();
            return Ok(newEmployee);
        
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEmployee(EmployeDto employeDto,Guid id){

            var employee= await DbContext.Employees.FindAsync(id);

            if (employee is null)
            {
                return NotFound();
            }

            employee.Name = employeDto.Name;
            employee.Email = employeDto.Email;
            employee.Phone = employeDto.Phone;
            employee.Salary = employeDto.Salary;


            await DbContext.SaveChangesAsync();

            return Ok(employee);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var employee = await DbContext.Employees.FindAsync(id);

            if (employee is null)
            {
                return NotFound();
            }

            DbContext.Employees.Remove(employee);
            await DbContext.SaveChangesAsync();

            //204 success remove
            return NoContent();

        }
       
    }
}
