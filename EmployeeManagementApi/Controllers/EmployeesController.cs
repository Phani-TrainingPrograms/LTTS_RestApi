using EmployeeManagementApi.DTOs;
using EmployeeManagementApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagementApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]//The URL Pattern for accessing the controller. 
    [ApiController] //This attribute indicates that the Controller responds to HTTP API Requests. 
    public class EmployeesController : ControllerBase
    {
        //Controllers shall use the Service layer to perform the operations. 
        private readonly IEmployeeService _service;//injected using the DI 

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpPost]//This specifies that the API End point handles POST Requests. 
        [Authorize(Roles = "Admin")]//This attribute specifies that only users with the Admin role can access this API endpoint. If a user without the Admin role tries to access this endpoint, they will receive a 403 Forbidden response.
        [ProducesResponseType(typeof(EmployeeResponseDto), 201)]//This documents the expected response type which will be used by OPenAPI/Swagger to generate the API documentation.
        [ProducesResponseType(400)]//Bad Request....
        [ProducesResponseType(409)]//Conflict....
        public async Task<IActionResult> Create(EmployeeRequestDto request)
        {
            var rec = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = rec.EmployeeId }, rec);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmployeeResponseDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var rec = await _service.GetByIdAsync(id);
            if (rec == null)
            {
                return NotFound();
            }
            return Ok(rec);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<EmployeeResponseDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var records = await _service.GetAllAsync();
            return Ok(records);//Ok function takes the arg of the data that needs to be sent back to the client. It returns a 200 OK status code along with the data.
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(EmployeeResponseDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, EmployeeRequestDto request)
        {
            var rec = await _service.UpdateAsync(id, request);
            if(rec == null)
            {
                return NotFound();//404 Error 
            }
            return Ok(rec);//200 OK status code along with the updated record.
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]//This attribute specifies that only users with the Admin role can access this API endpoint. If a user without the Admin role tries to access this endpoint, they will receive a 403 Forbidden response.
        [ProducesResponseType(204)]//No Content
        [ProducesResponseType(404)]//Not Found.
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if(!result)
            {
                return NotFound();
            }
            return NoContent();//204 No Content status code. 
        }

        //Patch verb is used when U want to update only a few properties of the record.
        [HttpPatch("{id}/city")]
        [ProducesResponseType(typeof(EmployeeResponseDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateCity(int id, UpdateCityRequestDto request)
        {
            var rec = await _service.UpdateCityAsync(id, request.City);
            if(rec == null)
            {
                return NotFound();
            }
            return Ok(rec);
        }

        //Todo: Update the department of an Employee....
    }
}
