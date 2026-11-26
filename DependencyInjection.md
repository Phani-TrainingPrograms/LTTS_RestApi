# **Dependency Injection in C# – AddTransient vs AddScoped vs AddSingleton**

Dependency Injection (DI) allows three service lifetimes:

1. `AddTransient()`
2. `AddScoped()`
3. `AddSingleton()`

These three methods determine **how long an object created by the Dependency Injection container remains alive and when a new instance is created.**

## **1. Understanding the three DI lifetimes**

## **Dependency Injection – Object Lifetime**

**1. AddTransient**

New instance

A new object is created every time the service is requested.

Instance 1

Instance 2

Instance 3

Instance 4

**2. AddScoped**

One per scope

One instance is created within a scope and reused throughout that scope.

Scope 1

Instance 1

Scope 2

Instance 2

Scope 3

Instance 3

**3. AddSingleton**

One instance

Only one instance is created and shared throughout the lifetime of the DI container.

**Single shared instance**

Used by all consumers

## **2. AddTransient – Transient lifetime**

### **What is AddTransient?**

When you register a service using `AddTransient()`, the DI container creates a new instance every time the service is requested.

**Example:**

```
services.AddTransient<IEmployeeService,
                      EmployeeService>();
```

Consider the following service:

```
public interface IEmployeeService
{
    Guid GetInstanceId();
}

public class EmployeeService : IEmployeeService
{
    private readonly Guid _id = Guid.NewGuid();

    public Guid GetInstanceId()
    {
        return _id;
    }
}
```

Now resolve the service multiple times:

```
var service1 =
    provider.GetRequiredService<IEmployeeService>();

var service2 =
    provider.GetRequiredService<IEmployeeService>();

Console.WriteLine(service1.GetInstanceId());
Console.WriteLine(service2.GetInstanceId());
```

**Expected output:**

```
A1B2-C3D4-...
E5F6-G7H8-...
```

Both objects have different IDs because the container creates a new instance for every resolution.

### **When should you use AddTransient?**

- Lightweight services.
- Stateless business logic.
- Data transformation services.
- Validation services.
- Utility services.

For example, an Employee Data Validator that validates employee input without maintaining state is a good candidate.

## **3. AddScoped – Scoped lifetime**

### **What is AddScoped?**

When you register a service using `AddScoped()`, the DI container creates one instance per scope.

All requests for that service within the same scope receive the same instance.

```
services.AddScoped<IEmployeeService,
                   EmployeeService>();
```

Consider:

```
using var scope1 = provider.CreateScope();

var service1 =
    scope1.ServiceProvider
          .GetRequiredService<IEmployeeService>();

var service2 =
    scope1.ServiceProvider
          .GetRequiredService<IEmployeeService>();

Console.WriteLine(service1.GetInstanceId());
Console.WriteLine(service2.GetInstanceId());
```

Both IDs will be identical.

Now create another scope:

```
using var scope2 = provider.CreateScope();

var service3 =
    scope2.ServiceProvider
          .GetRequiredService<IEmployeeService>();

Console.WriteLine(service3.GetInstanceId());
```

The third ID will be different.

**Expected behavior:**

| Service resolution  | Instance ID |
| ------------------- | ----------- |
| Scope 1 – Service 1 | ABC123      |
| Scope 1 – Service 2 | ABC123      |
| Scope 2 – Service 3 | XYZ789      |

### **When should you use AddScoped?**

- Entity Framework Core `DbContext`.
- Repository services.
- Business services operating within a transaction.
- Services that maintain state during one operation or request.

**Important:** In ASP.NET Core Web APIs, scoped services are typically created once per HTTP request. In a console application, there is no automatic HTTP request scope. You must create scopes explicitly using `CreateScope()`.

## **4. AddSingleton – Singleton lifetime**

### **What is AddSingleton?**

When you register a service using `AddSingleton()`, only one instance is created and shared across all consumers for the lifetime of the DI container.

```
services.AddSingleton<IEmployeeService,
                      EmployeeService>();
```

Example:

```
var service1 =
    provider.GetRequiredService<IEmployeeService>();

var service2 =
    provider.GetRequiredService<IEmployeeService>();

var service3 =
    provider.GetRequiredService<IEmployeeService>();

Console.WriteLine(service1.GetInstanceId());
Console.WriteLine(service2.GetInstanceId());
Console.WriteLine(service3.GetInstanceId());
```

**Expected behavior:**

| Service resolution | Instance ID |
| ------------------ | ----------- |
| Service 1          | ABC123      |
| Service 2          | ABC123      |
| Service 3          | ABC123      |

All three resolutions return the same instance.

### **When should you use AddSingleton?**

- Application configuration services.
- Stateless shared utility services.
- Thread-safe caching services.
- Shared application-wide resources.

**Important:** Singleton services should be thread-safe because multiple consumers may access the same instance concurrently.

Never directly inject a scoped service into a singleton constructor. This can cause lifetime problems.

## **5. Comparison of all three lifetimes**

| Feature           | Transient                 | Scoped                    | Singleton           |
| ----------------- | ------------------------- | ------------------------- | ------------------- |
| Registration      | AddTransient              | AddScoped                 | AddSingleton        |
| Instance creation | Every resolution          | Once per scope            | Once per container  |
| Instance sharing  | No                        | Within scope              | Across scopes       |
| Memory usage      | Depends on resolutions    | Per scope                 | One shared instance |
| Thread safety     | Depends on implementation | Depends on implementation | Very important      |
| Typical example   | Validator                 | DbContext                 | Cache               |

### **Visual comparison**

Imagine three API requests arriving at the server.

<img width="602" height="400" alt="image" src="https://github.com/user-attachments/assets/ecf7cd06-5b10-4c6d-a7aa-f9212f668edf" />


## **6. Implement all three in our Employee Console Application**

Let's now apply these concepts to the REST API client we developed earlier.

We will use the following architecture:

```
EmployeeConsoleClient
│
├── Program.cs
│
├── Models
│   ├── EmployeeRequest.cs
│   └── EmployeeResponse.cs
│
├── Services
│   ├── IEmployeeApiClient.cs
│   ├── EmployeeApiClient.cs
│   ├── IEmployeeService.cs
│   ├── EmployeeService.cs
│   └── EmployeeValidator.cs
│
└── Configuration
    └── AppInfo.cs
```

### **Step 1: Register the services**

Install the required hosting and HTTP client dependencies if they are not already available:

```
dotnet add package Microsoft.Extensions.Hosting
dotnet add package Microsoft.Extensions.Http
```

In `Program.cs`:

```
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// TRANSIENT
builder.Services.AddTransient<
    IEmployeeValidator, EmployeeValidator>();

// SCOPED
builder.Services.AddScoped<
    IEmployeeService, EmployeeService>();

// SINGLETON
builder.Services.AddSingleton<AppInfo>();

// HTTP CLIENT
builder.Services.AddHttpClient<
    IEmployeeApiClient, EmployeeApiClient>(client =>
{
    client.BaseAddress =
        new Uri("http://localhost:5000/");
});

using IHost host = builder.Build();

await host.RunAsync();
```

Notice that `AddHttpClient()` registers a typed HTTP client, which is managed by `IHttpClientFactory`. We don't need to manually register or dispose a new `HttpClient` for each operation.

### **Step 2: Implement the API Client**

```
public interface IEmployeeApiClient
{
    Task<List<EmployeeResponse>?> GetAllAsync();
}

public class EmployeeApiClient : IEmployeeApiClient
{
    private readonly HttpClient _httpClient;

    public EmployeeApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<EmployeeResponse>?> GetAllAsync()
    {
        return await _httpClient
            .GetFromJsonAsync<List<EmployeeResponse>>(
                "api/employees");
    }
}
```

This class is responsible for communicating with the REST API.

### **Step 3: Implement the Scoped Employee Service**

```
public interface IEmployeeService
{
    Task<List<EmployeeResponse>?> GetAllAsync();
}

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeApiClient _apiClient;
    private readonly IEmployeeValidator _validator;

    public EmployeeService(
        IEmployeeApiClient apiClient,
        IEmployeeValidator validator)
    {
        _apiClient = apiClient;
        _validator = validator;
    }

    public async Task<List<EmployeeResponse>?> GetAllAsync()
    {
        return await _apiClient.GetAllAsync();
    }
}
```

### **Step 4: Implement the Transient Validator**

```
public interface IEmployeeValidator
{
    bool IsValid(string employeeName);
}

public class EmployeeValidator : IEmployeeValidator
{
    public bool IsValid(string employeeName)
    {
        return !string.IsNullOrWhiteSpace(employeeName);
    }
}
```

### **Step 5: Implement the Singleton Service**

```
public class AppInfo
{
    public Guid ApplicationInstanceId { get; } =
        Guid.NewGuid();
}
```

This object will have the same instance ID whenever it is resolved from the same DI container.

### **Step 6: Resolve the Scoped Service**

In a console application, create a scope for each logical operation.

```
using var scope = host.Services.CreateScope();

var employeeService =
    scope.ServiceProvider
         .GetRequiredService<IEmployeeService>();

var employees =
    await employeeService.GetAllAsync();

foreach (var emp in employees ?? [])
{
    Console.WriteLine(
        $"{emp.EmployeeId} - {emp.EmployeeName}");
}
```

You can create another scope for the next menu operation.

