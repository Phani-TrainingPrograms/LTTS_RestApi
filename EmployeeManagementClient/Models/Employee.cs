using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementClient.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string EmployeeName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Department { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
    }
}
