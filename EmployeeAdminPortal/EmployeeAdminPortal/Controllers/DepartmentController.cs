using EmployeeAdminPortal.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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


            return Ok();         
        }



       
    }
}
