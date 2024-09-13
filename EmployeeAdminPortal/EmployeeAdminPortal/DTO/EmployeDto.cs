using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.DTO
{
    public class EmployeDto
    {
        public Guid Id { get; set; }

        public Guid DepartmentId { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public string? Phone { get; set; }

        public decimal Salary { get; set; }

        
    }
}
