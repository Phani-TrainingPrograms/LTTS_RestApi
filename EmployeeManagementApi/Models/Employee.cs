namespace EmployeeManagementApi.Models
{
    //use the Ef core to represent the Employee table in the database
    public class Employee
    {
        public int EmployeeId { get; set; } //EF Core conventionally treats a property named Id or <ClassName>Id as the primary key
        public string EmployeeName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
