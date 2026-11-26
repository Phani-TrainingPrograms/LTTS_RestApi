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

        public async Task<Employee?>GetByIdAsync(int id)
        {
            await SetTokenAsync();
            return null;
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
