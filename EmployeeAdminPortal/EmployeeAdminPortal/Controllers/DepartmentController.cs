using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.DTO;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext DbContext;

        public DepartmentController(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartmentAll() {
            return Ok(await DbContext.Department.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentDto departmentDto){

            try
            {
                var department = new Department()
                {
                    Name = departmentDto.Name,
                    Description = departmentDto.Description,
                };

                DbContext.Department.Add(department);
                await DbContext.SaveChangesAsync();

                return Ok(department);
               
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }


        




       
    }
}
