using EmployeeManagementClient.Models;
using EmployeeManagementClient.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagementClient.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly ApiClientService _api;

        public IndexModel(ApiClientService api)
        {
            _api = api;
        }

        public List<Employee> EmployeesList { get; set; }

        public async Task OnGetAsync()
        {
            var result = await _api.GetAll();
            Console.WriteLine(result.ToString());

            if(result != null)
                EmployeesList = result;
        }
    }
}
