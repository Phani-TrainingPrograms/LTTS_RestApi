using EmployeeManagementClient.Services;

namespace EmployeeManagementClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            var baseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? throw new InvalidOperationException("API Base Url is not available");
            
            builder.Services.AddHttpClient<ApiClientService>(c =>
            {
                c.BaseAddress = new Uri(baseUrl);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if(!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}
