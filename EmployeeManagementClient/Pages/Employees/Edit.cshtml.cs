using EmployeeManagementClient.Models;
using EmployeeManagementClient.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagementClient.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly ApiClientService _service;

        public EditModel(ApiClientService service)
        {
            _service = service;
        }

        [BindProperty]
        public Employee  Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var rec = await _service.GetByIdAsync(id);
            if(rec == null)
            {
                return NotFound();
            }
            Employee = rec;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
                return Page();
            await _service.UpdateAsync(Employee);
            return RedirectToPage("Index");
        }
    }
}
