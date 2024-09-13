using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.DTO
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; }
       
    }
}
