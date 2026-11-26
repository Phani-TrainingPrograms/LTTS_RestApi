using EmployeeManagementClient.Models;
using EmployeeManagementClient.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagementClient.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly ApiClientService _api;

        public CreateModel(ApiClientService api)
        {
            _api = api;
        }

        [BindProperty]
        public Employee Employee { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            await _api.AddAsync(Employee);

            return RedirectToPage("Index");
        }
    }
}
