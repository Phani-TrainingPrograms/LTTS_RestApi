using EmployeeManagementApi.Data;
using EmployeeManagementApi.DTOs;
using EmployeeManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApi.Services
{
    //Service layers are created to implement the business logic and encapsulate the data access logic. The service layer shall have all the CRUD operations implemented and the controllers shall call the service layer to perform the operations 
    //REST APIs follow Async programming. Task is used to represent the async operation. All operations shall return Task. 
    public interface IEmployeeService
    {
        Task<List<EmployeeResponseDto>> GetAllAsync();//Recommended to suffix async methods with Async. This method shall return a list of Employees from the database and map the Employee model to the EmpDTO and return the list.
                                                      
        Task<EmployeeResponseDto?> GetByIdAsync(int id); //This method shall return a single Employee based on the EmployeeId passed as parameter. It shall map the Employee model to the EmpDTO and return the object.

        Task<EmployeeResponseDto> CreateAsync(EmployeeRequestDto employeeRequestDto); //This method shall create a new Employee record in the database based on the EmpDTO passed as parameter. It shall map the EmpDTO to the Employee model and save it to the database. It shall return the created Employee object mapped to EmpDTO.

        Task<EmployeeResponseDto?> UpdateAsync(int id, EmployeeRequestDto employeeRequestDto); //This method shall update an existing Employee record in the database based on the EmployeeId passed as parameter. It shall map the EmpDTO to the Employee model and update it in the database. It shall return the updated Employee object mapped to EmpDTO.

        Task<bool> DeleteAsync(int id); //This method shall delete an existing Employee record in the database based on the EmployeeId passed as parameter. It shall return true if the record was deleted successfully, false otherwise.>

        Task<EmployeeResponseDto?> UpdateCityAsync(int id, string cityName); //This method shall update the City of an existing Employee record in the database based on the EmployeeId passed as parameter. It shall map the UpdateCityDTO to the Employee model and update it in the database. It shall return the updated Employee object mapped to EmpDTO.

    }

    /// <summary>
    /// Contains the Implementation of IEmployeeService. 
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDbContext _context;
        public EmployeeService(EmployeeDbContext context) //.NET CORE shall inject this object as we have set it in the Program.cs.
        {
            _context = context;
        }
        public async Task<EmployeeResponseDto> CreateAsync(EmployeeRequestDto employeeRequestDto)
        {
            //check if email already exists. 
            bool exists = await _context.Employees.AnyAsync<Employee>(e => e.Email == employeeRequestDto.Email);
            if(exists)
            {
                throw new InvalidOperationException("An Employee with this Email already Exists");
            }
            //create the Employee model object from the DTO.
            var emp = new Employee
            {
                EmployeeName = employeeRequestDto.EmployeeName,
                Email = employeeRequestDto.Email,
                City = employeeRequestDto.City,
                Department = employeeRequestDto.Department,
                CreatedDate = DateTime.UtcNow
            };
            _context.Employees.Add(emp);//Adds to the collection. 
            await _context.SaveChangesAsync();//Saves to the database
            return new EmployeeResponseDto
            {
                EmployeeId = emp.EmployeeId, //ID of the newly added record....
                EmployeeName = emp.EmployeeName,
                Email = emp.Email,
                City = emp.City,
                CreatedDate = emp.CreatedDate
            };

        }

        public async Task<bool> DeleteAsync(int id)
        {
            //find the records
            var rec = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            if(rec == null)
            {
                return false;
            }
            //Remove it
            _context.Employees.Remove(rec);
            //save it
            await _context.SaveChangesAsync();
            return true;
        }

        //await can be used only if the function declaration has async.  
        public async Task<List<EmployeeResponseDto>> GetAllAsync()
        {
            //Select every record from the Employees Table and convert it into EmployeeResponseDto and store it in a list and return the list.
            return await _context.Employees.Select(e => new EmployeeResponseDto
            {
                EmployeeId = e.EmployeeId,
                EmployeeName = e.EmployeeName,
                Email = e.Email,
                City = e.City,
                Department = e.Department,
                CreatedDate = e.CreatedDate
            }).ToListAsync();
        }

        public async Task<EmployeeResponseDto?> GetByIdAsync(int id)
        {
            return await _context.Employees.Where(e => e.EmployeeId == id)
                .Select(e => new EmployeeResponseDto
                {
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.EmployeeName,
                    Email = e.Email,
                    City = e.City,
                    Department = e.Department,
                    CreatedDate = e.CreatedDate
                })
                .FirstOrDefaultAsync();
        }

        public async Task<EmployeeResponseDto?> UpdateAsync(int id, EmployeeRequestDto employeeRequestDto)
        {
            //Extract the Employee with matching id...
            var rec = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            //if not found, return null.
            if(rec == null)
            {
                return null;
            }
            //check for Email uniqueness. If email already exists for another employee, throw exception.
            var emailExists = await _context.Employees.AnyAsync(e => e.Email == employeeRequestDto.Email && e.EmployeeId != id);
            if(emailExists)
            {
                throw new InvalidOperationException("Email already exists.");
            }
            //Update the Employee model with the values from the DTO.
            rec.EmployeeName = employeeRequestDto.EmployeeName;
            rec.Email = employeeRequestDto.Email;
            rec.City = employeeRequestDto.City;
            rec.Department = employeeRequestDto.Department;
            await _context.SaveChangesAsync();//Save the changes to the database.
            //return the updated Employee model mapped to DTO.
            return new EmployeeResponseDto
            {
                EmployeeId = rec.EmployeeId,
                EmployeeName = rec.EmployeeName,
                Email = rec.Email,
                City = rec.City,
                Department = rec.Department,
                CreatedDate = rec.CreatedDate
            };
        }

        public async Task<EmployeeResponseDto?> UpdateCityAsync(int id, string cityName)
        {
            //Get the matching Employee Record...
            var rec = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            //If not found, return null.
            if (rec == null)
            {
                return null;
            }
            //Update the City property and save changes to the database.
            rec.City = cityName;
            await _context.SaveChangesAsync();
            //Return the updated Employee model mapped to DTO.
            return new EmployeeResponseDto
            {
                EmployeeId = rec.EmployeeId,
                EmployeeName = rec.EmployeeName,
                Email = rec.Email,
                City = rec.City,
                Department = rec.Department,
                CreatedDate = rec.CreatedDate
            };
        }
    }
}
