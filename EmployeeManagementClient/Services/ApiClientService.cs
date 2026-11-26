using EmployeeManagementClient.Models;
using Microsoft.AspNetCore.Authentication;
using System.Text.Json.Serialization;

namespace EmployeeManagementClient.Services
{
    public class ApiClientService
    {
        private readonly HttpClient _httpClient;
        private string? _jwtToken;

        public ApiClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Employee>> GetAll()
        {
            await SetTokenAsync();

            return await _httpClient.GetFromJsonAsync<List<Employee>>("api/employees");
        }

        public async Task AddAsync(Employee emp)
        {
            await SetTokenAsync();
            var res = await _httpClient.PostAsJsonAsync("api/employees", emp);
            res.EnsureSuccessStatusCode();
        }

        public async Task<Employee?>GetByIdAsync(int id)
        {
            await SetTokenAsync();
            return await _httpClient.GetFromJsonAsync<Employee>(
                $"api/employees/{id}");
        }
        private async Task SetTokenAsync()
        {
            //check if the token is already set and not expired
            if(!string.IsNullOrEmpty(_jwtToken))
            {
                return;
            }
            var apiUrl = "api/auth/login";
            var loginRequest = new
            {
                Username = "phani",
                Password = "demo-password"
            };

            var response = await _httpClient.PostAsJsonAsync(
                apiUrl,
                loginRequest);

            // Throw exception if login fails
            response.EnsureSuccessStatusCode();
            

            string token = response.Content.ReadAsStringAsync().Result;
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        }

        public async Task UpdateAsync(Employee employee)
        {
            await SetTokenAsync();

            var response = await _httpClient.PutAsJsonAsync(
                $"api/employees/{employee.EmployeeId}", employee);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            await SetTokenAsync();

            var response = await _httpClient.DeleteAsync(
                $"api/employees/{id}");

            response.EnsureSuccessStatusCode();
        }

    }

    public class TokenResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; } = string.Empty;
        [JsonPropertyName("expiresIn")]
        public string ExpiresIn { get; set; } = string.Empty;
        [JsonPropertyName("tokenType")] 
        public long TokenType { get; set; }
        
    }
}
