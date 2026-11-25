# REST API Programming – Complete Technical Training Guide

## Course Overview

REST API programming is one of the most important skills in modern software development. Almost every modern application, including mobile applications, web applications, enterprise systems, cloud platforms, and microservices, communicates with other systems through APIs.

This training guide introduces API concepts from the fundamentals and gradually progresses towards professional API design, implementation, security, documentation, and testing.

### Learning Objectives

By the end of this course, learners should be able to:

1. Understand how client-server communication evolved from traditional server architectures to modern API-based communication.
2. Explain REST, GraphQL, and other modern API communication approaches.
3. Understand API terminology, architecture, roles, responsibilities, and contracts.
4. Design REST APIs using appropriate HTTP methods, status codes, resource naming conventions, and response structures.
5. Understand API-first and code-first development approaches.
6. Design APIs for existing legacy systems.
7. Implement API security using authentication, authorization, OAuth 2.0, and JWT.
8. Understand OpenAPI 2.0 (Swagger 2.0) and OpenAPI 3.0 specifications.
9. Apply the Richardson Maturity Model to evaluate REST API maturity.
10. Work with JSON and JWT tokens in real-world applications.
11. Test APIs and validate their contracts.
12. Understand modern API architecture and the future direction of API development.

### Suggested Training Duration

| Module | Topic | Suggested Duration |
|---|---|---:|
| 1 | Introduction to REST API Programming | 2 hours |
| 2 | Designing APIs – Concepts and Contracts | 3 hours |
| 3 | API Design, Security and Standards | 3 hours |
| 4 | OpenAPI and Richardson Maturity Model | 2 hours |
| 5 | API Mechanics – JSON and JWT | 3 hours |
| 6 | Hands-on API Design and Implementation | 3 hours |
| **Total** | | **16 hours** |

---

# MODULE 1: INTRODUCTION TO REST API PROGRAMMING

## 1.1 What Is an API?

API stands for **Application Programming Interface**.

An API is a mechanism that allows two software applications to communicate with each other through a predefined set of rules and operations.

Think of an API as a waiter in a restaurant.

Imagine you visit a restaurant in Bengaluru.

1. You sit at a table and look at the menu.
2. You tell the waiter what you want.
3. The waiter communicates your request to the kitchen.
4. The kitchen prepares the food.
5. The waiter brings the prepared food back to you.

You do not enter the kitchen or need to understand how the food is prepared.

An API works similarly.

| Restaurant Concept | API Equivalent |
|---|---|
| Customer | Client application |
| Menu | API documentation |
| Waiter | API endpoint/interface |
| Kitchen | Backend application |
| Ingredients and preparation | Business logic and database operations |
| Prepared food | API response |

The client does not need to know how the server internally processes a request. It only needs to understand the API contract.

### Technical Definition

An API defines:

- What operations can be performed.
- What input data must be provided.
- How requests should be formatted.
- What response the client can expect.
- How errors should be communicated.
- What authentication and authorization are required.

### Example: Employee Management Application

Consider an organization that maintains employee records.

A web application wants to retrieve employee information from a backend system.

The frontend sends:

```http
GET /api/employees/101 HTTP/1.1
Host: api.company.in
Accept: application/json
```

The server processes the request and responds:

```http
HTTP/1.1 200 OK
Content-Type: application/json
```

```json
{
  "employeeId": 101,
  "employeeName": "Rahul Sharma",
  "city": "Bengaluru",
  "department": "IT"
}
```

The frontend receives the response and displays Rahul's information.

The frontend does not need to know whether the backend uses SQL Server, MongoDB, or DynamoDB.

### Real-World Example

An employee management application might use the following APIs:

| Requirement | API |
|---|---|
| Retrieve employees | GET /api/employees |
| Retrieve one employee | GET /api/employees/101 |
| Add an employee | POST /api/employees |
| Update employee details | PUT /api/employees/101 |
| Delete an employee | DELETE /api/employees/101 |

<img width="1774" height="887" alt="image" src="https://github.com/user-attachments/assets/90e653f2-fe31-4b03-9ace-f97b9aed56cf" />


---

## 1.2 Brief History of Server Communication

To understand REST APIs, it is important to understand how applications communicated before modern API architectures became popular.

Software architecture has evolved considerably over the years.

### 1.2.1 Traditional Mainframe Architecture

During the early days of enterprise computing, organizations primarily used centralized mainframe computers.

All important business processing happened on a central computer.

Users accessed the system through terminals.

The terminals were generally responsible for accepting input and displaying output, while the mainframe performed most of the processing.

**Analogy:**

Imagine a large bank with a central headquarters. Every branch sends its transactions to the headquarters, and the headquarters processes everything.

This is similar to a centralized mainframe architecture.

**Characteristics:**

- Centralized processing.
- Limited client-side functionality.
- Expensive hardware.
- Strong dependence on the central server.
- Communication through terminal-based protocols.

**Real-World Example:**

Traditional banking systems used centralized mainframes to process account transactions, withdrawals, deposits, and other financial operations.

### 1.2.2 Client-Server Architecture

With the growth of personal computers and networking, applications started adopting client-server architecture.

The responsibilities were divided between two major components:

1. Client: Provides the user interface and initiates requests.
2. Server: Processes requests, performs business operations, and interacts with databases.

A client could communicate with a server over a network.

```mermaid
flowchart TD
    A["Client Application"] -->|"Request"| B["Application Server"]
    B -->|"Database Query"| C[("Database")]
    C -->|"Data"| B
    B -->|"Response"| A
```

**Advantages:**

- Better separation of responsibilities.
- Multiple clients could access the same server.
- Business logic could be centralized.
- Data management became easier.

**Limitations:**

- Clients could become tightly coupled to server implementation.
- Different platforms sometimes required different communication mechanisms.
- Scaling the application could become difficult.

**Real-World Example:**

A desktop application installed in different branches of an organization connects to a central SQL Server database through an application server.

### 1.2.3 Distributed Architecture

As applications became larger, organizations started distributing application responsibilities across multiple servers.

Instead of maintaining one large application server, different services could perform different business functions.

For example:

- Employee Service manages employee records.
- Payroll Service processes salaries.
- Attendance Service tracks employee attendance.
- Notification Service sends emails and messages.

These services communicate with one another through network protocols.

```mermaid
flowchart TD
    A["Client Application"] --> B["Application Server"]
    B --> C["Employee Service"]
    B --> D["Payroll Service"]
    B --> E["Attendance Service"]
    C --> F[("Employee DB")]
    D --> G[("Payroll DB")]
    E --> H[("Attendance DB")]
```

This architecture introduced new challenges around communication, service availability, data consistency, and network failures.

### 1.2.4 Web-Based Communication

The growth of the internet introduced HTTP as a widely adopted protocol for communication between web browsers and web servers.

Initially, websites primarily delivered HTML pages.

The browser requested a page, and the server returned HTML content.

Later, applications began exchanging structured data independently of HTML pages.

XML and JSON became important formats for exchanging data between applications.

This evolution created the foundation for modern web APIs.

### Real-World Example: Evolution of an Online Banking Application

| Architecture | Banking Application |
|---|---|
| Mainframe | All banking operations handled centrally |
| Client-Server | Branch applications communicate with a central server |
| Distributed | Separate systems handle accounts, payments, and loans |
| Web-Based | Customers access banking through browsers |
| API-Based | Mobile, web, and partner applications consume common APIs |

<img width="1536" height="1024" alt="image" src="https://github.com/user-attachments/assets/271df9e2-40da-4371-a92c-5eecebb421c6" />


---

## 1.3 Past Roadmap – Evolution of Application Communication

Different technologies have been introduced to enable communication between applications.

Understanding these technologies helps explain why REST became popular.

### 1.3.1 Remote Procedure Call (RPC)

RPC stands for Remote Procedure Call.

It allows one application to execute a function or procedure located in another application or machine.

From the developer's perspective, calling a remote function can look similar to calling a local function.

**Analogy:**

Imagine calling a colleague in Chennai and asking them to execute a task on your behalf. You provide the required information, and they perform the operation and communicate the result.

RPC follows a similar approach.

Example:

```text
GetEmployee(101)
```

The client invokes a remote operation called `GetEmployee`.

The server processes it and returns the employee details.

**Advantages:**

- Easy-to-understand function-based communication.
- Suitable for structured service operations.
- Can provide strongly defined interfaces.

**Limitations:**

- Client and server may become tightly coupled.
- Remote failures are different from local function failures.
- Different RPC frameworks may require different communication protocols.

### 1.3.2 SOAP – Simple Object Access Protocol

SOAP is a messaging protocol used for exchanging structured information between applications.

It traditionally uses XML as its message format and defines a formal structure for requests and responses.

SOAP services often use WSDL (Web Services Description Language) to describe available operations and message contracts.

Example SOAP request:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<soap:Envelope
    xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">

    <soap:Body>
        <GetEmployee>
            <EmployeeId>101</EmployeeId>
        </GetEmployee>
    </soap:Body>

</soap:Envelope>
```

A SOAP response might look like:

```xml
<soap:Envelope
    xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">

    <soap:Body>
        <GetEmployeeResponse>
            <EmployeeId>101</EmployeeId>
            <EmployeeName>Rahul Sharma</EmployeeName>
            <City>Bengaluru</City>
        </GetEmployeeResponse>
    </soap:Body>

</soap:Envelope>
```

**Important SOAP characteristics:**

- SOAP defines a formal messaging structure.
- XML is the standard message representation.
- WSDL can describe service operations and contracts.
- SOAP supports standards for enterprise messaging and security.
- SOAP messages can be transported over HTTP and other protocols.

### 1.3.3 XML-RPC

XML-RPC allows applications to execute remote procedures using XML-formatted messages.

It is simpler than SOAP but follows the same general RPC concept.

A client sends an XML request describing the method and its parameters. The server executes the requested method and returns an XML response.

### 1.3.4 REST

REST stands for Representational State Transfer.

It is an architectural style introduced by Roy Fielding in his 2000 doctoral dissertation.

REST uses resources, representations, and a uniform interface to enable communication between distributed systems.

REST is commonly implemented over HTTP.

Example:

```http
GET /api/employees/101
```

The request identifies an employee resource and asks the server to retrieve its representation.

### Comparison of Communication Approaches

| Technology | Communication Model | Typical Format | Common Use |
|---|---|---|---|
| RPC | Remote procedure invocation | Binary or framework-specific | Internal service calls |
| SOAP | Structured messaging | XML | Enterprise integrations |
| XML-RPC | Remote procedure invocation | XML | Legacy integrations |
| REST | Resource-oriented | JSON, XML, others | Web and mobile APIs |
| GraphQL | Query-oriented | JSON | Flexible client data retrieval |

### Real-World Example

Suppose a bank has an older SOAP-based loan management system but a new mobile application.

The organization can expose a REST API in front of the existing SOAP service. The mobile application communicates using JSON, while the backend adapter translates requests into SOAP messages.

This allows the organization to modernize its client applications without immediately replacing the existing system.

---

## 1.4 Modern API Options

Modern application development provides multiple ways to expose and consume application functionality.

The most common approaches include REST, GraphQL, and gRPC.

### 1.4.1 REST

REST is an architectural style rather than a communication protocol.

REST APIs generally use HTTP methods to operate on resources.

A resource represents an identifiable business entity or concept.

Examples:

- Employee
- Customer
- Order
- Product
- Payment

Each resource is identified through a URI.

Example:

```http
GET /api/employees/101
```

The API retrieves employee 101.

```http
POST /api/employees
```

The API creates a new employee.

**Important REST constraints:**

1. Client-Server: The user interface and backend responsibilities are separated.
2. Statelessness: Each request contains the information necessary for the server to process it. The server does not depend on conversational session state stored between requests.
3. Cacheability: Responses should indicate whether they can be cached.
4. Uniform Interface: Resources are accessed using consistent identification and representation rules.
5. Layered System: Clients need not know whether they are communicating directly with the application server or through gateways and intermediaries.
6. Code on Demand (Optional): A server may provide executable code to a client, although this constraint is rarely used in typical REST APIs.

A system satisfying these constraints is considered RESTful.

**Important distinction:** An HTTP endpoint that returns JSON is not automatically a fully REST-compliant API.

### 1.4.2 GraphQL

GraphQL is a query language for APIs and a runtime for executing those queries against data.

It was developed at Facebook and publicly released in 2015.

Unlike traditional REST APIs, where the server generally determines the response structure, GraphQL allows the client to request specific fields.

Consider an employee object containing:

- Employee ID
- Employee name
- Department
- City
- Email
- Phone number
- Address

A REST endpoint might return all these fields even when the client only needs the employee name and department.

A GraphQL query can request only the required fields.

Example:

```graphql
query {
  employee(id: 101) {
    employeeName
    department
  }
}
```

Example response:

```json
{
  "data": {
    "employee": {
      "employeeName": "Rahul Sharma",
      "department": "IT"
    }
  }
}
```

**Advantages:**

- Clients can request only the data they need.
- Complex related data can be retrieved in one query.
- It provides a strongly defined schema.
- It reduces certain forms of over-fetching and under-fetching.

**Challenges:**

- Query complexity needs to be controlled.
- Caching may require additional planning.
- Authorization must be enforced at appropriate field and resource levels.
- Monitoring and performance optimization can become more complex.

### 1.4.3 gRPC

gRPC is a high-performance Remote Procedure Call framework.

It was originally developed by Google and uses Protocol Buffers as its primary interface definition and serialization mechanism.

It commonly uses HTTP/2 for transport.

Example service definition:

```protobuf
syntax = "proto3";

service EmployeeService {
    rpc GetEmployee (EmployeeRequest)
        returns (EmployeeResponse);
}

message EmployeeRequest {
    int32 employeeId = 1;
}

message EmployeeResponse {
    int32 employeeId = 1;
    string employeeName = 2;
    string city = 3;
}
```

A client invokes `GetEmployee` as a remote method.

**Advantages:**

- Efficient binary serialization.
- Strongly defined service contracts.
- Supports streaming communication.
- Suitable for service-to-service communication.

### REST vs GraphQL vs gRPC

| Feature | REST | GraphQL | gRPC |
|---|---|---|---|
| Architecture | Resource-oriented | Query-oriented | Procedure-oriented |
| Common transport | HTTP | Commonly HTTP | HTTP/2 |
| Data format | JSON, XML, etc. | Usually JSON responses | Protocol Buffers |
| Contract | OpenAPI commonly used | GraphQL schema | Protocol Buffers |
| Caching | Standard HTTP caching support | Requires additional planning | Typically application-level |
| Browser support | Excellent | Excellent with suitable clients | Browser use often requires gRPC-Web |
| Best suited for | Public and general-purpose APIs | Flexible data queries | Internal high-performance services |

### 1.4.4 Direction Forward – Modern API Architecture

API development is moving beyond simple request-response communication.

Modern applications increasingly use:

- API gateways to manage routing, authentication, throttling, and observability.
- Microservices to separate business capabilities.
- Event-driven architecture for asynchronous communication.
- WebSockets for real-time, bidirectional communication.
- gRPC for efficient service-to-service calls.
- AsyncAPI to describe event-driven and asynchronous interfaces.
- AI-enabled APIs to expose machine learning and generative AI capabilities.

Example architecture:

```mermaid
flowchart TD
    A["Web Application"] --> G["API Gateway"]
    B["Mobile Application"] --> G
    C["Partner Application"] --> G

    G --> E["Employee Service"]
    G --> O["Order Service"]
    G --> P["Payment Service"]

    O --> Q["Message Broker"]
    Q --> N["Notification Service"]
    Q --> A2["Analytics Service"]
```

### Real-World Example

An e-commerce company in Bengaluru might use:

- REST for mobile and web applications.
- GraphQL for a product discovery interface.
- gRPC for internal communication between microservices.
- Events for order confirmation and notification processing.
- WebSockets for live delivery tracking.

The technologies complement one another rather than competing in every situation.

---

## 1.5 API Terminology

Understanding API terminology is essential before designing or implementing APIs.

| Term | Explanation |
|---|---|
| API | Interface that enables software applications to communicate |
| Client | Application that initiates an API request |
| Server | Application that processes requests and returns responses |
| Endpoint | Address through which an API operation is accessed |
| URI | Uniform Resource Identifier used to identify a resource |
| URL | Uniform Resource Locator that identifies the location of a resource |
| HTTP | Protocol commonly used for web API communication |
| Request | Message sent by a client to a server |
| Response | Message returned by a server |
| Header | Metadata associated with an HTTP request or response |
| Body | Main content carried in a request or response |
| Payload | Data transferred as part of a message |
| Resource | Business entity exposed through an API |
| Representation | Format in which resource information is communicated |
| Contract | Agreement describing API behavior and structure |
| Authentication | Process of verifying identity |
| Authorization | Process of checking permissions |
| Versioning | Managing API changes over time |
| Middleware | Component that processes requests and responses within an application pipeline |
| API Gateway | Entry point that manages API traffic |
| Rate Limiting | Restricting the number of requests over a period |

### Example: Understanding an API Request

```http
GET /api/employees/101 HTTP/1.1
Host: api.company.in
Accept: application/json
Authorization: Bearer eyJhbGciOi...
```

Breakdown:

- `GET`: HTTP method.
- `/api/employees/101`: Resource endpoint.
- `HTTP/1.1`: HTTP protocol version.
- `Host`: Server information.
- `Accept`: Expected response representation.
- `Authorization`: Authentication credentials.

### Real-World Example

When a mobile banking application requests an account balance, it acts as the client. The banking backend acts as the server, the account balance is the resource representation, and the endpoint identifies the requested account information.

---

## 1.6 Advantages and Disadvantages of APIs

APIs provide several benefits, but they also introduce engineering responsibilities.

### Advantages

**1. Reusability**

An API allows multiple applications to reuse the same business functionality. For example, a customer information API can be consumed by a web portal, mobile application, and internal administrative application.

**2. Separation of Concerns**

The frontend and backend can be developed independently as long as both follow the API contract. Changes in the backend database do not necessarily require frontend modifications.

**3. Integration**

APIs allow organizations to integrate different platforms and technologies. A .NET application can communicate with a Java application or a Python-based analytics service without sharing the same implementation language.

**4. Scalability**

APIs make it possible to distribute application functionality across independently scalable services. For example, an organization can scale its payment service independently of its employee management service.

**5. Platform Independence**

Applications written in different programming languages can communicate through common protocols and data formats. This is especially useful in heterogeneous enterprise environments.

**6. Automation**

APIs enable automated business processes, including payment processing, report generation, notifications, and data synchronization.

### Disadvantages and Challenges

**1. Security Risks**

APIs expose application functionality through network interfaces. Poor authentication, authorization, input validation, or access control can expose sensitive business data.

**2. Network Dependency**

API communication depends on network availability. Slow connections, timeouts, and service failures can affect application behavior.

**3. Version Management**

Changes to API contracts can affect existing consumers. Organizations must carefully manage breaking changes and compatibility.

**4. Performance Overhead**

Multiple API calls may introduce additional network latency. Poorly designed endpoints can increase server load and database operations.

**5. Monitoring Complexity**

When multiple services communicate, identifying the source of a failure can become difficult. Distributed tracing, centralized logging, and monitoring are important.

### Real-World Example

An online shopping application may depend on product, customer, inventory, payment, and delivery APIs. If the payment service becomes unavailable, the customer may not be able to complete an order even when the remaining services are operational.

This demonstrates why API reliability, security, and monitoring are important.

---

# MODULE 2: DESIGNING APIs – CONCEPTS AND CONTRACTS

## 2.1 What Is API Design?

API design is the process of defining how external applications will interact with a software system.

It determines the API's:

- Resources and endpoints.
- Operations and HTTP methods.
- Request and response structures.
- Error handling.
- Authentication and authorization requirements.
- Versioning strategy.
- Documentation and testing requirements.

API design should happen before implementation whenever possible.

**Analogy:**

Consider constructing a house.

Before construction begins, an architect prepares a blueprint showing rooms, dimensions, doors, windows, electrical connections, and plumbing.

Similarly, API design creates a blueprint describing how applications will communicate.

Writing code without a clear API design is similar to constructing a house without an architectural plan.

### Real-World Example

Before implementing an employee management API, a development team should decide:

- How employees will be identified.
- Which fields are mandatory.
- How employee creation will work.
- How duplicate employee records will be handled.
- What response should be returned when an employee is not found.

These decisions become part of the API design.

---

## 2.2 Anatomy of API Roles

An API ecosystem contains multiple participants.

Understanding their responsibilities helps establish a clean architecture.

### 2.2.1 API Consumer

An API consumer is an application or system that uses an API.

Examples include:

- Web applications.
- Mobile applications.
- Desktop applications.
- Third-party applications.
- Other backend services.

A consumer sends requests according to the API contract.

### 2.2.2 API Provider

An API provider is the system that exposes an API.

It defines the available endpoints, validates incoming requests, executes business logic, and returns responses.

### 2.2.3 API Developer

An API developer designs and implements the API.

The developer is responsible for resource modeling, request validation, business logic integration, error handling, and implementation of the API contract.

### 2.2.4 API Owner

The API owner is responsible for the API's lifecycle and business purpose.

This role may include deciding which capabilities should be exposed, managing version changes, defining access policies, and ensuring the API meets business requirements.

### 2.2.5 API Gateway

An API gateway acts as a centralized entry point for API traffic.

It can handle:

- Request routing.
- Authentication integration.
- Rate limiting.
- Logging.
- Traffic management.
- Request and response transformation.

It should not automatically become a repository for all business logic.

### 2.2.6 API Administrator

An API administrator manages API infrastructure, deployment, policies, monitoring, and operational configurations.

In large organizations, API administration may involve API management platforms.

### API Communication Architecture

```mermaid
flowchart TD
    A["API Consumer"] -->|"HTTP Request"| B["API Gateway"]
    B --> C["API Provider"]
    C --> D["Business Logic"]
    D --> E[("Database")]
    E --> D
    D --> C
    C --> B
    B -->|"HTTP Response"| A

    F["API Owner"] -.-> C
    G["API Administrator"] -.-> B
```

### Role Comparison

| Role | Responsibility |
|---|---|
| Consumer | Uses the API |
| Provider | Exposes the API |
| Developer | Designs and implements the API |
| Owner | Defines business purpose and lifecycle |
| Gateway | Manages API traffic |
| Administrator | Manages operational configuration |

### Real-World Example

A Bengaluru-based e-commerce organization exposes a product API.

Its Android application consumes the API, the .NET backend provides it, the API gateway manages requests, and the product team owns its business requirements.

---

## 2.3 Anatomy of an API Request and Response

Every HTTP API interaction involves a request and a response.

### 2.3.1 Anatomy of an HTTP Request

An HTTP request typically contains:

1. Request method.
2. Request target or path.
3. HTTP version.
4. Headers.
5. Optional body.

Example:

```http
POST /api/employees HTTP/1.1
Host: api.company.in
Content-Type: application/json
Accept: application/json
Authorization: Bearer <access-token>

{
  "employeeName": "Ananya Rao",
  "city": "Mysuru",
  "department": "Engineering"
}
```

Explanation:

| Component | Purpose |
|---|---|
| POST | Indicates the requested operation |
| /api/employees | Identifies the resource collection |
| Content-Type | Indicates the request body format |
| Accept | Indicates acceptable response formats |
| Authorization | Carries credentials |
| Request body | Contains employee information |

### 2.3.2 Anatomy of an HTTP Response

An HTTP response generally contains:

1. HTTP version.
2. Status code.
3. Status description.
4. Response headers.
5. Optional response body.

Example:

```http
HTTP/1.1 201 Created
Content-Type: application/json
Location: /api/employees/102

{
  "employeeId": 102,
  "employeeName": "Ananya Rao",
  "city": "Mysuru",
  "department": "Engineering"
}
```

The status code indicates that a new resource was successfully created.

The `Location` header identifies the newly created resource.

### 2.3.3 Request-Response Lifecycle

```mermaid
sequenceDiagram
    participant C as Client
    participant A as API Server
    participant M as Middleware
    participant B as Business Logic
    participant D as Database

    C->>A: HTTP Request
    A->>M: Process Request
    M->>M: Authentication and Validation
    M->>B: Forward Valid Request
    B->>D: Execute Database Operation
    D-->>B: Return Data
    B-->>A: Build Response
    A-->>C: HTTP Response
```

### Real-World Example

When Ananya Rao submits an employee registration form, the browser sends a POST request. The API validates her details, checks for duplicate records, inserts the employee into the database, and returns HTTP 201 Created.

---

## 2.4 API Errors and Error Handling

Errors are an unavoidable part of software systems.

A well-designed API should communicate errors consistently and meaningfully.

An API should not simply return an unexplained failure message.

### 2.4.1 Categories of API Errors

**1. Client Errors**

These occur when the request contains invalid information or the client does not have permission to perform an operation.

Examples:

- Invalid employee ID.
- Missing mandatory fields.
- Invalid authentication token.
- Accessing an unauthorized resource.

**2. Server Errors**

These occur when the server cannot successfully process an otherwise valid request.

Examples:

- Database unavailable.
- Internal application exception.
- External payment service failure.
- Unexpected processing error.

**3. Network Errors**

These occur when communication between the client and server fails.

Examples:

- Connection timeout.
- DNS resolution failure.
- Network disconnection.
- TLS handshake failure.

### 2.4.2 Standard HTTP Error Status Codes

| Status | Meaning | Example |
|---|---|---|
| 400 | Bad Request | Invalid request data |
| 401 | Unauthorized | Missing or invalid credentials |
| 403 | Forbidden | Authenticated user lacks permission |
| 404 | Not Found | Employee does not exist |
| 405 | Method Not Allowed | POST is not supported on an endpoint |
| 409 | Conflict | Duplicate employee number |
| 415 | Unsupported Media Type | Unsupported request format |
| 422 | Unprocessable Content | Semantically invalid request |
| 429 | Too Many Requests | Rate limit exceeded |
| 500 | Internal Server Error | Unexpected application exception |
| 502 | Bad Gateway | Invalid response from an upstream server |
| 503 | Service Unavailable | Service temporarily unavailable |
| 504 | Gateway Timeout | Upstream service timeout |

### 2.4.3 Standardized Error Response

A consistent error structure makes client-side error handling easier.

Consider an invalid employee registration request.

```json
{
  "type": "https://api.company.in/errors/validation",
  "title": "Validation Failed",
  "status": 400,
  "detail": "One or more fields contain invalid values.",
  "errors": {
    "employeeName": [
      "Employee name is required."
    ],
    "email": [
      "A valid email address is required."
    ]
  },
  "traceId": "00-abc123-example"
}
```

This structure follows the general principles of Problem Details for HTTP APIs, standardized in RFC 9457.

### 2.4.4 Best Practices for Error Handling

- Return appropriate HTTP status codes instead of returning HTTP 200 for every outcome. This allows consumers, gateways, and monitoring systems to identify failures correctly.
- Avoid exposing database connection strings, stack traces, passwords, internal server paths, or sensitive implementation details. Such information can help attackers understand the internal architecture.
- Provide meaningful error descriptions that help consumers correct their requests. The message should explain what went wrong without exposing sensitive internal information.
- Include a correlation or trace identifier. This helps support teams locate the corresponding server-side log entries.
- Use a consistent error response structure. Consumers can implement reusable error-handling logic rather than writing separate logic for every endpoint.

### Real-World Example

Suppose Rahul Sharma tries to register an employee with an email address that already exists.

The API should return:

```http
HTTP/1.1 409 Conflict
Content-Type: application/problem+json
```

```json
{
  "title": "Employee Already Exists",
  "status": 409,
  "detail": "An employee with this email address already exists."
}
```

The client can display a meaningful message instead of showing a generic server error.

---

## 2.5 API Contracts

An API contract defines the agreement between an API provider and its consumers.

It describes how an API should behave, including the expected request structure, response structure, operations, and error conditions.

**Analogy:**

A contract between a customer and a bank defines what services the bank provides and what conditions apply.

An API contract serves a similar purpose between two software systems.

### 2.5.1 What Does an API Contract Define?

A contract generally defines:

- Available endpoints and HTTP methods.
- Request parameters.
- Request headers.
- Request body schemas.
- Response schemas.
- HTTP status codes.
- Authentication requirements.
- Validation rules.
- Error structures.

### Example API Contract

Consider an endpoint for creating employees.

**Endpoint:**

```http
POST /api/employees
```

**Request:**

```json
{
  "employeeName": "Kavya Reddy",
  "email": "kavya@example.in",
  "city": "Hyderabad",
  "department": "Finance"
}
```

**Successful response:**

```http
201 Created
```

```json
{
  "employeeId": 103,
  "employeeName": "Kavya Reddy",
  "email": "kavya@example.in",
  "city": "Hyderabad",
  "department": "Finance"
}
```

**Possible errors:**

| Status | Condition |
|---|---|
| 400 | Invalid employee data |
| 401 | Authentication missing |
| 403 | Insufficient permissions |
| 409 | Duplicate employee |
| 500 | Unexpected server failure |

### 2.5.2 Why Are Contracts Important?

Contracts enable frontend and backend teams to work independently.

For example, the frontend team can build the employee registration screen using the agreed request and response structure even before the backend implementation is complete.

Similarly, the backend team can implement the API without needing to know the frontend's internal framework.

### 2.5.3 Contract-First Development

In contract-first development, the API contract is created and reviewed before implementation.

The contract becomes the reference for developers, testers, and consumers.

### Real-World Example

A company has separate teams working on an Angular frontend and a .NET backend.

Both teams agree on the employee API contract first. The frontend team uses mock responses, while the backend team implements the actual database integration.

This reduces dependency between teams.

---

## 2.6 Detail Exposure and Information Hiding

API design should expose only the information required by consumers.

An API should not reveal unnecessary internal database structures or implementation details.

This principle is closely related to encapsulation and abstraction in software engineering.

### Example: Database Entity vs API Response

Suppose the database contains an employee table:

| Column | Example |
|---|---|
| EmployeeId | 101 |
| EmployeeName | Rahul Sharma |
| Email | rahul@example.in |
| PasswordHash | Internal hash |
| Salary | 85000 |
| InternalAuditFlag | 1 |
| CreatedBy | Admin123 |

A public employee API should not automatically expose every column.

A response might contain:

```json
{
  "employeeId": 101,
  "employeeName": "Rahul Sharma",
  "email": "rahul@example.in",
  "department": "IT"
}
```

The password hash and internal audit information should never be exposed.

Salary information should only be provided to consumers with the appropriate authorization.

### Why Is Detail Exposure Important?

**Security:** Unnecessary fields may expose sensitive business information.

**Maintainability:** Internal database changes should not automatically break API consumers.

**Abstraction:** Consumers should work with business-level concepts rather than internal database implementation.

**Flexibility:** The backend can change its internal architecture without requiring every consumer to change.

### DTO – Data Transfer Object

A DTO is an object designed to carry data between application layers or across application boundaries.

Instead of directly exposing database entities, an API can use dedicated DTOs.

Example in C#:

```csharp
public class EmployeeResponseDto
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; }

    public string Email { get; set; }

    public string City { get; set; }
}
```

The application maps database entities to response DTOs.

### Real-World Example

An employee database may contain salary, bank account information, and personal identification details. The public employee directory API should return only information required to display the employee's professional profile.

---

## 2.7 API Standards

Standards help different applications communicate consistently.

Without standards, each team might implement its own conventions for URLs, data formats, authentication, and error handling.

Important API standards and specifications include:

| Standard | Purpose |
|---|---|
| HTTP | Defines request-response communication |
| HTTPS | Provides HTTP communication over TLS |
| JSON | Standardized data interchange format |
| REST | Architectural style for networked applications |
| OpenAPI | Describes HTTP APIs |
| OAuth 2.0 | Authorization framework |
| JWT | Compact token format |
| RFC 9457 | Problem Details for HTTP APIs |
| RFC 3339 | Date and time representation |
| RFC 3986 | URI syntax |

### Real-World Example

A banking application developed in Java and a payment gateway developed in .NET can communicate using HTTPS, JSON, standardized HTTP status codes, and OAuth-based access tokens.

Both applications can interoperate without sharing the same programming language or database.

---

## 2.8 Design First vs Code First

There are two common approaches to API development.

### 2.8.1 Design First

Design-first development starts by defining the API contract.

The development team decides:

- What endpoints are required.
- What HTTP methods will be used.
- What request and response structures are expected.
- What validation rules apply.
- What errors can occur.

After the design is reviewed, developers implement the API.

**Flow:**

```mermaid
flowchart TD
    A["Business Requirements"] --> B["API Design"]
    B --> C["Create API Contract"]
    C --> D["Review and Approval"]
    D --> E["Backend Implementation"]
    E --> F["Contract Testing"]
    F --> G["Deployment"]
```

**Advantages:**

- Frontend and backend teams can work in parallel.
- API behavior is agreed upon before implementation.
- Documentation can be generated from the contract.
- Design inconsistencies can be identified early.

**Disadvantages:**

- Initial design requires additional effort.
- Poorly understood requirements can lead to repeated contract changes.
- The contract must be maintained as implementation evolves.

### 2.8.2 Code First

Code-first development begins with implementation.

Developers create controllers, methods, models, and business logic.

API documentation or specifications are then generated from the code using tools such as Swagger/OpenAPI generators.

**Flow:**

```mermaid
flowchart TD
    A["Business Requirements"] --> B["Create Models"]
    B --> C["Implement API Endpoints"]
    C --> D["Generate OpenAPI Documentation"]
    D --> E["Test APIs"]
    E --> F["Deployment"]
```

**Advantages:**

- Developers can start implementation quickly.
- Useful for small applications and prototypes.
- API documentation can be generated automatically.

**Disadvantages:**

- Design decisions may be driven by implementation convenience.
- Frontend teams may need to wait for backend availability.
- Documentation can become outdated if it is not generated or validated consistently.

### Comparison

| Criteria | Design First | Code First |
|---|---|---|
| Starting point | API contract | Source code |
| Documentation | Created before implementation | Commonly generated afterward |
| Parallel development | Easier | May require coordination |
| Initial effort | Higher | Often lower |
| Best suited for | Large systems and multiple consumers | Prototypes and smaller applications |
| Contract validation | Central to workflow | Must be added to development process |

### 2.8.3 Which Approach Should Be Used?

Design-first is particularly useful when multiple teams or external consumers depend on the same API.

Code-first can be suitable for smaller internal applications where requirements are simple and the development team controls all consumers.

Many mature organizations use a hybrid approach: they define contracts first, implement APIs, and continuously generate or validate documentation against the implementation.

### Real-World Example

A company developing a banking API for multiple mobile applications and external partners should strongly consider design-first development.

A small internal application for managing office assets might use code-first development.

---

## 2.9 API Testing

API testing verifies that an API behaves according to its contract and business requirements.

It checks more than whether an endpoint returns a successful response.

### Types of API Testing

**1. Functional Testing**

Verifies whether API operations perform the expected business functions. For example, creating an employee should create a valid employee record.

**2. Integration Testing**

Verifies communication between the API and external dependencies such as databases, payment gateways, and other services.

**3. Contract Testing**

Checks whether the API implementation follows its published contract. It is especially useful when multiple applications consume the same API.

**4. Security Testing**

Checks authentication, authorization, access control, input validation, and protection against common API vulnerabilities.

**5. Performance Testing**

Evaluates response time, throughput, concurrency, and resource utilization under different workloads.

**6. Negative Testing**

Checks how the API handles invalid input, missing parameters, unauthorized requests, and unsupported operations.

### API Testing Tools

| Tool | Purpose |
|---|---|
| Postman | Manual API testing and automated collections |
| Swagger UI | Interactive API exploration |
| curl | Command-line HTTP requests |
| REST Assured | Java API automation |
| NUnit / xUnit | .NET API testing |
| JMeter | Performance testing |
| k6 | Load and performance testing |
| Pact | Consumer-driven contract testing |

### Example: Testing an Employee API with curl

```bash
curl -X GET \
  "https://localhost:5001/api/employees/101" \
  -H "Accept: application/json"
```

Testing employee creation:

```bash
curl -X POST \
  "https://localhost:5001/api/employees" \
  -H "Content-Type: application/json" \
  -d '{
    "employeeName": "Arjun Kumar",
    "city": "Chennai",
    "department": "IT"
  }'
```

### Example Test Cases

| Test Case | Input | Expected Result |
|---|---|---|
| Retrieve existing employee | ID 101 | 200 OK |
| Retrieve missing employee | ID 999 | 404 Not Found |
| Create valid employee | Valid JSON | 201 Created |
| Create invalid employee | Missing name | 400 Bad Request |
| Delete existing employee | ID 101 | Successful deletion |
| Access protected API | No token | 401 Unauthorized |

### Real-World Example

Before releasing an employee management API, the QA team tests employee creation, retrieval, update, and deletion. It also verifies that employees cannot access administrative endpoints without the required permissions.

---

# MODULE 3: API DESIGN, SECURITY AND STANDARDS

## 3.1 Designing APIs for Existing Systems

Organizations frequently need to expose API functionality from systems that were developed many years ago.

These systems are commonly called legacy systems.

A legacy system may use:

- Mainframe applications.
- Traditional relational databases.
- Stored procedures.
- SOAP web services.
- Desktop applications.
- Proprietary communication protocols.
- Older programming languages.

Replacing such systems immediately can be expensive and risky.

A better approach is often to introduce an API layer around the existing application.

### 3.1.1 Why Do We Need APIs for Existing Systems?

Consider an organization that maintains an employee management application developed 15 years ago.

The system provides employee information through:

- SQL Server stored procedures.
- Desktop application interfaces.
- Internal business components.

Now the organization wants to introduce a modern mobile application.

The mobile application should not directly access the old database.

Instead, the organization can introduce an API layer that communicates with the existing system.

### Architecture

```mermaid
flowchart TD
    A["Mobile Application"] --> D["New REST API Layer"]
    B["Web Application"] --> D
    C["Partner Application"] --> D

    D --> E["Legacy Adapter"]
    E --> F["Existing Business Logic"]
    F --> G[("Legacy SQL Server")]
```

The REST API acts as an abstraction layer between modern consumers and the legacy application.

### 3.1.2 Conversion of Concepts

The most important challenge when exposing an API for an existing system is converting legacy concepts into modern API concepts.

For example, a legacy system might expose operations such as:

```text
GET_EMP_DETAILS
INSERT_EMP_RECORD
UPDATE_EMP_INFO
DELETE_EMP_RECORD
```

These operations may be based on stored procedures or remote functions.

A REST API should model business resources and their operations.

Possible REST endpoints:

```http
GET    /api/employees
GET    /api/employees/101
POST   /api/employees
PUT    /api/employees/101
PATCH  /api/employees/101
DELETE /api/employees/101
```

### Legacy Concept vs REST Concept

| Legacy Concept | REST API Equivalent |
|---|---|
| Stored procedure | API operation |
| Employee table | Employee resource |
| Employee primary key | Resource identifier |
| Stored procedure parameters | Request parameters or request body |
| Stored procedure result set | JSON response |
| Database error | Appropriate HTTP error response |
| Database transaction | Business operation with transaction management |

### 3.1.3 Anti-Corruption Layer

An anti-corruption layer is a software design pattern used to prevent one system's internal model from leaking into another system.

For example, a legacy payroll system may use an internal field called `EMP_CD`, whereas the modern API exposes `employeeId`.

The adapter translates between these representations.

```mermaid
flowchart LR
    A["REST API Request"] --> B["Modern Employee DTO"]
    B --> C["Anti-Corruption Layer"]
    C --> D["Legacy Employee Model"]
    D --> E["Legacy Business Logic"]
```

This approach helps protect the new architecture from legacy implementation details.

### 3.1.4 Strangler Pattern

The Strangler Fig Pattern is a modernization approach in which new functionality gradually replaces old functionality.

Instead of rewriting the entire system at once, the organization introduces new services incrementally.

Example:

- Employee retrieval is moved to a new REST service.
- Employee registration is migrated later.
- Payroll functionality remains in the legacy system until it is ready for modernization.

### Real-World Example

A Bengaluru-based manufacturing company has a legacy employee application built using .NET Framework and SQL Server.

The company develops a new .NET 8 REST API that communicates with the existing database through a controlled repository and adapter layer. The mobile application consumes the new API without directly depending on the legacy desktop application.

---

## 3.2 API Security

API security protects the information, operations, and infrastructure exposed through APIs.

APIs can expose sensitive information such as customer records, financial transactions, employee details, and payment operations.

Security must be considered during API design rather than added only after development.

### 3.2.1 Authentication vs Authorization

These two terms are often confused.

**Authentication** answers:

"Who are you?"

It verifies the identity of a user or application.

**Authorization** answers:

"What are you allowed to do?"

It determines whether an authenticated identity has permission to perform a particular operation.

**Analogy:**

Imagine entering an office building.

- Your employee identity card proves who you are. This is authentication.
- Your access permissions determine whether you can enter the server room. This is authorization.

### Comparison

| Authentication | Authorization |
|---|---|
| Verifies identity | Verifies permissions |
| Happens before protected access is granted | Determines permitted operations |
| Uses credentials or identity tokens | Uses roles, claims, scopes, or policies |
| Example: Login | Example: Access payroll data |

### 3.2.2 Common API Security Mechanisms

**1. HTTPS**

HTTPS protects communication between client and server using TLS.

It provides encryption and server authentication, helping prevent attackers from reading or modifying traffic in transit.

**2. API Keys**

An API key is a credential used to identify an application or API consumer.

API keys are useful for certain application integrations, but they should not be treated as a replacement for user authentication and fine-grained authorization.

**3. Basic Authentication**

Basic authentication transmits a username and password encoded using Base64.

Base64 is not encryption. Basic authentication should only be used over HTTPS and is generally unsuitable for modern user authentication without additional protections.

**4. Bearer Tokens**

A bearer token is a credential that grants access to whoever possesses it.

Clients generally send bearer tokens in the HTTP Authorization header.

```http
Authorization: Bearer <access-token>
```

Anyone who obtains a valid bearer token may be able to use it, so tokens must be protected.

**5. OAuth 2.0**

OAuth 2.0 is an authorization framework that allows applications to obtain limited access to protected resources.

**6. JWT**

JWT is a compact token format that can carry claims about an identity or authorization context.

It is frequently used in token-based authentication and authorization architectures.

### 3.2.3 Common API Security Threats

| Threat | Explanation | Mitigation |
|---|---|---|
| Broken Object Level Authorization | Users access another user's records | Validate resource ownership and permissions |
| Broken Authentication | Weak or incorrectly implemented authentication | Use established identity protocols |
| Broken Function Level Authorization | Users invoke unauthorized operations | Enforce role and policy checks |
| Injection | Malicious input affects queries or commands | Validate input and use parameterized queries |
| Sensitive Data Exposure | APIs reveal confidential information | Minimize data exposure and encrypt sensitive information |
| Excessive Resource Consumption | Attackers overload the API | Apply rate limits and resource controls |
| Security Misconfiguration | Incorrect security settings expose the API | Secure configuration and regular reviews |

The OWASP API Security Top 10 is an important reference for understanding API-specific vulnerabilities.

### Real-World Example

A banking API exposes account information through:

```http
GET /api/accounts/1001
```

The API must verify that the authenticated customer owns account 1001 or has another explicitly authorized relationship with that account.

Checking only whether the user is logged in is insufficient.

---

## 3.3 Authorization and OAuth 2.0

OAuth 2.0 is an authorization framework defined by RFC 6749.

It enables an application to obtain access to protected resources without directly receiving or storing the resource owner's password.

### 3.3.1 Important OAuth Terminology

| Term | Meaning |
|---|---|
| Resource Owner | Entity that owns the protected information |
| Client | Application requesting access |
| Authorization Server | Server that issues access tokens |
| Resource Server | Server that hosts protected resources |
| Access Token | Credential used to access protected resources |
| Refresh Token | Credential used to obtain new access tokens |
| Scope | Defines the access requested or granted |

### 3.3.2 OAuth 2.0 Authorization Code Flow with PKCE

This is the recommended approach for many user-facing applications, including mobile and browser-based applications.

PKCE stands for Proof Key for Code Exchange.

It adds protection against authorization code interception.

**Flow:**

```mermaid
sequenceDiagram
    participant U as User
    participant C as Client Application
    participant A as Authorization Server
    participant R as Resource API

    U->>C: Initiate Login
    C->>A: Authorization Request + PKCE Challenge
    A->>U: Login and Consent
    U->>A: Authenticate
    A->>C: Authorization Code
    C->>A: Code + PKCE Verifier
    A->>C: Access Token
    C->>R: API Request + Access Token
    R->>R: Validate Token and Permissions
    R-->>C: Protected Resource
```

### 3.3.3 OAuth 2.0 Grant Types

| Grant Type | Purpose | Current Guidance |
|---|---|---|
| Authorization Code | User authorization through an authorization server | Recommended, generally with PKCE |
| Client Credentials | Machine-to-machine access | Suitable for confidential clients |
| Device Authorization | Devices with limited input capability | Suitable for device-based scenarios |
| Refresh Token | Obtain new access tokens | Used as part of supported authorization flows |
| Implicit | Legacy browser-based token flow | Avoid in modern implementations |
| Resource Owner Password Credentials | Direct username/password grant | Deprecated and should not be used |

### 3.3.4 Scope-Based Authorization

OAuth scopes define the permissions requested by a client.

Example:

```text
employee.read
employee.write
payroll.read
payroll.approve
```

An application granted `employee.read` should not automatically be permitted to modify employee records.

### 3.3.5 OAuth 2.0 vs OpenID Connect

OAuth 2.0 is primarily an authorization framework.

OpenID Connect (OIDC) adds an identity layer on top of OAuth 2.0 and enables clients to authenticate users.

OIDC introduces an ID token, which communicates information about the authenticated user.

| OAuth 2.0 | OpenID Connect |
|---|---|
| Authorization | Authentication and identity |
| Access token | ID token and access token |
| Grants access to resources | Communicates user identity |
| Defines scopes and authorization flows | Defines identity claims and authentication behavior |

### Real-World Example

An employee logs in to an organization's application using Microsoft Entra ID.

The application receives tokens through an OIDC authorization flow and uses an access token to call the protected employee API.

The API validates the token and checks whether the employee has permission to retrieve payroll information.

---

## 3.4 API Design Basics

A well-designed REST API should use consistent naming conventions, appropriate HTTP methods, correct status codes, and meaningful resource structures.

### 3.4.1 Resource-Oriented Design

REST APIs should generally expose nouns representing business resources rather than verbs representing operations.

**Preferred:**

```http
GET /api/employees
GET /api/employees/101
POST /api/employees
DELETE /api/employees/101
```

**Avoid where possible:**

```http
GET /api/getEmployees
POST /api/createEmployee
GET /api/deleteEmployee/101
```

The HTTP method already describes the intended operation.

### 3.4.2 Collection and Individual Resources

A collection represents multiple resources.

```http
GET /api/employees
```

An individual resource represents one specific entity.

```http
GET /api/employees/101
```

### 3.4.3 Nested Resources

Nested endpoints can represent relationships between resources.

Example:

```http
GET /api/employees/101/projects
```

This retrieves projects associated with employee 101.

However, deeply nested URL structures should be avoided because they become difficult to maintain.

### 3.4.4 Filtering, Sorting and Pagination

Large collections should support controlled retrieval.

Filtering:

```http
GET /api/employees?city=Bengaluru
```

Sorting:

```http
GET /api/employees?sortBy=employeeName&order=asc
```

Pagination:

```http
GET /api/employees?page=1&pageSize=15
```

A response could look like:

```json
{
  "items": [
    {
      "employeeId": 101,
      "employeeName": "Rahul Sharma",
      "city": "Bengaluru"
    }
  ],
  "page": 1,
  "pageSize": 15,
  "totalRecords": 125,
  "totalPages": 9
}
```

For large datasets, cursor-based pagination can be more efficient and stable than offset-based pagination.

### Real-World Example

An HR application contains 10,000 employee records. Instead of sending all records to the browser, the frontend requests 15 records at a time and retrieves additional pages when required.

---

## 3.5 HTTP Methods

HTTP methods describe the intended action on a resource.

The most important methods used in REST APIs are GET, POST, PUT, PATCH, and DELETE.

### 3.5.1 GET

GET retrieves a resource or collection of resources.

Example:

```http
GET /api/employees/101
```

Response:

```json
{
  "employeeId": 101,
  "employeeName": "Rahul Sharma",
  "city": "Bengaluru"
}
```

GET is considered a safe method because it should not change the state of the requested resource.

It is also idempotent.

### 3.5.2 POST

POST submits information to a resource, commonly to create a new resource or initiate a processing operation.

Example:

```http
POST /api/employees
Content-Type: application/json
```

```json
{
  "employeeName": "Sneha Rao",
  "city": "Mysuru"
}
```

POST is generally not idempotent.

Submitting the same creation request multiple times may create multiple employee records unless the application implements an idempotency mechanism.

### 3.5.3 PUT

PUT creates or replaces the state of a resource at the target URI, depending on the API's design.

Example:

```http
PUT /api/employees/101
```

```json
{
  "employeeName": "Rahul Sharma",
  "city": "Hubballi",
  "department": "Engineering"
}
```

PUT is idempotent.

Repeating the same request should result in the same resource state.

### 3.5.4 PATCH

PATCH applies a partial modification to a resource.

Example:

```http
PATCH /api/employees/101
```

```json
{
  "city": "Mangaluru"
}
```

Only the city is updated.

PATCH is not automatically idempotent. Its idempotency depends on the patch operation and API implementation.

### 3.5.5 DELETE

DELETE requests removal of a resource.

Example:

```http
DELETE /api/employees/101
```

DELETE is idempotent in HTTP semantics: repeating the same deletion should not produce an additional state change, even though subsequent responses may differ.

### HTTP Method Comparison

| Method | Purpose | Safe | Idempotent |
|---|---|---|---|
| GET | Retrieve resource | Yes | Yes |
| POST | Create or process | No | No, generally |
| PUT | Create or replace resource | No | Yes |
| PATCH | Partially modify resource | No | Not necessarily |
| DELETE | Remove resource | No | Yes |

**Important concepts:**

- Safe means the client is not requesting a state-changing operation.
- Idempotent means repeating the same request has the same intended effect on server state as performing it once.

### Real-World Example

An HR application uses GET to retrieve Rahul's employee record, POST to register a new employee, PUT to replace the employee profile, PATCH to update only the employee's city, and DELETE to remove the employee record.

---

## 3.6 HTTP Status Codes

HTTP status codes communicate the result of an HTTP request.

They are grouped into five categories.

### 3.6.1 1xx – Informational

These codes indicate that the request has been received and processing is continuing.

Example: `100 Continue`.

### 3.6.2 2xx – Success

These codes indicate successful processing.

| Code | Meaning | Common API Scenario |
|---|---|---|
| 200 | OK | Successful GET or update |
| 201 | Created | Successful resource creation |
| 202 | Accepted | Request accepted for asynchronous processing |
| 204 | No Content | Successful operation without response body |

### 3.6.3 3xx – Redirection

These codes indicate that additional action is required or that a resource has moved.

| Code | Meaning |
|---|---|
| 301 | Moved Permanently |
| 302 | Found |
| 304 | Not Modified |
| 307 | Temporary Redirect |
| 308 | Permanent Redirect |

### 3.6.4 4xx – Client Errors

These codes indicate problems with the request or client permissions.

| Code | Meaning |
|---|---|
| 400 | Bad Request |
| 401 | Unauthorized |
| 403 | Forbidden |
| 404 | Not Found |
| 405 | Method Not Allowed |
| 409 | Conflict |
| 415 | Unsupported Media Type |
| 422 | Unprocessable Content |
| 429 | Too Many Requests |

### 3.6.5 5xx – Server Errors

These codes indicate server-side processing failures.

| Code | Meaning |
|---|---|
| 500 | Internal Server Error |
| 501 | Not Implemented |
| 502 | Bad Gateway |
| 503 | Service Unavailable |
| 504 | Gateway Timeout |

### Important Interview Question: Difference Between 401 and 403

**401 Unauthorized:**

The request does not contain valid authentication credentials.

Example: A client calls a protected endpoint without a valid access token.

**403 Forbidden:**

The client is authenticated but does not have permission to perform the requested operation.

Example: An employee attempts to access an administrative payroll endpoint without the required role.

### Real-World Example

Rahul accesses an employee portal without logging in. The API returns 401.

After logging in, Rahul attempts to access the HR administrator's endpoint. The API returns 403 if he does not have the required permissions.

---

## 3.7 API Versioning

API versioning helps maintain compatibility when the API contract changes.

Suppose an existing API returns:

```json
{
  "employeeName": "Rahul Sharma"
}
```

A new version introduces a different response structure:

```json
{
  "firstName": "Rahul",
  "lastName": "Sharma"
}
```

Existing consumers may break if the response changes unexpectedly.

Versioning allows organizations to introduce changes without immediately breaking existing applications.

### Common Versioning Approaches

**1. URI Versioning**

```http
GET /api/v1/employees
GET /api/v2/employees
```

This is simple and widely used.

**2. Query Parameter Versioning**

```http
GET /api/employees?version=2
```

The API version is passed as a query parameter.

**3. Header Versioning**

```http
GET /api/employees
Accept: application/vnd.company.employee-v2+json
```

The requested version is indicated through HTTP headers.

### Comparison

| Approach | Example | Advantage |
|---|---|---|
| URI | /api/v1/employees | Easy to understand |
| Query | ?version=2 | Keeps URL structure stable |
| Header | Accept: application/vnd... | Separates version from resource URI |

### Real-World Example

A mobile application released two years ago may still depend on API v1. A newly developed application can use API v2 while the organization gradually migrates existing consumers.

---

# MODULE 4: OPENAPI AND RICHARDSON MATURITY MODEL

## 4.1 What Is OpenAPI?

OpenAPI is a standard specification used to describe HTTP APIs in a machine-readable format.

It defines:

- API endpoints.
- HTTP methods.
- Request parameters.
- Request body schemas.
- Response structures.
- Authentication schemes.
- Data models.
- API metadata.

OpenAPI helps developers, testers, documentation tools, and API consumers understand how an API works without reading its implementation source code.

### 4.1.1 What Is Swagger?

Swagger is a collection of tools associated with the OpenAPI ecosystem.

Historically, Swagger was the name of the specification. The specification was donated to the OpenAPI Initiative and became the OpenAPI Specification.

Today:

- OpenAPI refers to the specification.
- Swagger UI provides interactive API documentation.
- Swagger Editor helps author API definitions.
- Swagger Codegen and related tools support code generation.

### 4.1.2 Why Is OpenAPI Important?

OpenAPI enables consistent API documentation and supports automation.

For example, a frontend developer can inspect an API specification and understand the request and response formats without contacting the backend developer for every detail.

### Architecture

```mermaid
flowchart TD
    A["OpenAPI Specification"] --> B["Swagger UI"]
    A --> C["API Documentation"]
    A --> D["Client Code Generation"]
    A --> E["Server Stub Generation"]
    A --> F["Contract Validation"]
    A --> G["API Testing"]
```

### Real-World Example

A company provides an employee API to external business partners. It publishes an OpenAPI document so partner developers can understand available endpoints, authentication requirements, and response structures.

---

## 4.2 OpenAPI 2.0 – Swagger 2.0

OpenAPI 2.0 was historically known as Swagger 2.0.

It provides a machine-readable format for describing HTTP-based APIs.

It is still encountered in older enterprise systems and legacy API documentation.

### 4.2.1 Structure of OpenAPI 2.0

An OpenAPI 2.0 document commonly contains:

| Property | Purpose |
|---|---|
| swagger | Specifies specification version |
| info | API title, description, and version |
| host | API server hostname |
| basePath | Base URL path |
| schemes | HTTP or HTTPS |
| consumes | Accepted request media types |
| produces | Response media types |
| paths | API endpoints |
| definitions | Reusable data models |
| parameters | Reusable request parameters |
| responses | Reusable responses |
| securityDefinitions | Authentication schemes |
| security | Security requirements |

### 4.2.2 OpenAPI 2.0 Example

```yaml
swagger: "2.0"

info:
  title: Employee Management API
  description: API for managing employee information
  version: "1.0.0"

host: api.company.in

basePath: /api

schemes:
  - https

consumes:
  - application/json

produces:
  - application/json

paths:
  /employees:
    get:
      summary: Get all employees
      responses:
        "200":
          description: Successful response

    post:
      summary: Create employee
      parameters:
        - in: body
          name: employee
          required: true
          schema:
            $ref: "#/definitions/Employee"
      responses:
        "201":
          description: Employee created

definitions:
  Employee:
    type: object
    properties:
      employeeId:
        type: integer
      employeeName:
        type: string
      city:
        type: string
```

### 4.2.3 Important Limitations and Differences

OpenAPI 2.0 uses:

- `definitions` for reusable schemas.
- `securityDefinitions` for security schemes.
- `consumes` and `produces` for media types.
- A specific `body` parameter mechanism for request bodies.

It also has a more limited model for describing request bodies than OpenAPI 3.x.

### Real-World Example

An enterprise application developed several years ago may contain a Swagger 2.0 specification. New developers can use the specification to understand existing endpoints before implementing changes.

---

## 4.3 Richardson Maturity Model

The Richardson Maturity Model (RMM) helps evaluate how closely an API follows REST architectural principles.

It was popularized by Leonard Richardson and is commonly described through four levels: 0, 1, 2, and 3.

The higher the maturity level, the more effectively the API uses resource-oriented concepts, HTTP methods, and hypermedia controls.

### 4.3.1 Level 0 – The Swamp of POX

POX stands for Plain Old XML.

At Level 0, an application uses HTTP mainly as a transport mechanism.

Multiple business operations may be exposed through a single endpoint, with the actual operation identified through the request body.

Example:

```http
POST /employeeService
Content-Type: application/xml
```

```xml
<GetEmployee>
    <EmployeeId>101</EmployeeId>
</GetEmployee>
```

Here, the same endpoint may support several operations depending on the message content.

**Characteristics:**

- Single endpoint or limited endpoint structure.
- HTTP methods are not used meaningfully.
- Operations are identified through message contents.
- Resource-oriented design is absent.

### 4.3.2 Level 1 – Resources

At Level 1, the API introduces individual resources.

Instead of using one endpoint for everything, different resources have different identifiers.

Example:

```http
POST /employeeService/employees/101
POST /employeeService/departments/10
```

Different URLs identify different resources.

However, HTTP methods may still be used in a non-standard or inconsistent way.

**Characteristics:**

- Resources are introduced.
- Different resource URLs are available.
- HTTP may still be treated mainly as a transport mechanism.
- Operations are not necessarily represented through standard HTTP semantics.

### 4.3.3 Level 2 – HTTP Verbs

At Level 2, the API correctly uses HTTP methods and status codes.

Example:

```http
GET /api/employees/101
POST /api/employees
PUT /api/employees/101
DELETE /api/employees/101
```

This is the level at which most commonly used REST-style APIs operate.

**Characteristics:**

- Resource-oriented URLs.
- Appropriate HTTP methods.
- Meaningful status codes.
- Correct use of request and response representations.

### 4.3.4 Level 3 – Hypermedia Controls

Level 3 introduces HATEOAS.

HATEOAS stands for Hypermedia as the Engine of Application State.

The API response contains links describing related actions or navigation options.

Example:

```json
{
  "employeeId": 101,
  "employeeName": "Rahul Sharma",
  "city": "Bengaluru",
  "_links": {
    "self": {
      "href": "/api/employees/101"
    },
    "department": {
      "href": "/api/departments/10"
    },
    "update": {
      "href": "/api/employees/101"
    }
  }
}
```

The consumer can discover related operations through the response instead of relying entirely on hardcoded navigation rules.

### Richardson Maturity Model Comparison

| Level | Name | Main Concept | HTTP Usage |
|---|---|---|---|
| 0 | POX | Single service endpoint | HTTP as transport |
| 1 | Resources | Resource identification | Resource-oriented URLs |
| 2 | HTTP Verbs | Correct HTTP semantics | Proper methods and status codes |
| 3 | Hypermedia | Discoverable actions and links | Hypermedia controls |

### Visual Representation

```mermaid
flowchart TD
    A["Level 0: Single Endpoint"] --> B["Level 1: Resources"]
    B --> C["Level 2: HTTP Methods"]
    C --> D["Level 3: Hypermedia Controls"]
```

### Real-World Example

Consider an employee management API.

- Level 0: All employee operations are sent to `/employeeService`.
- Level 1: Employees have individual resource URLs.
- Level 2: GET, POST, PUT, and DELETE are used correctly.
- Level 3: Responses contain links that help clients discover related resources and available actions.

**Important:** The Richardson Maturity Model is a way to evaluate REST maturity. It is not a formal replacement for the REST architectural constraints.

---

## 4.4 OpenAPI 3.0

OpenAPI 3.0 introduced important improvements over OpenAPI 2.0.

It provides a cleaner and more expressive structure for describing modern APIs.

### 4.4.1 Major Changes from OpenAPI 2.0

| Feature | OpenAPI 2.0 | OpenAPI 3.0 |
|---|---|---|
| Specification property | swagger: "2.0" | openapi: "3.0.0" |
| Server configuration | host, basePath, schemes | servers |
| Request body | body parameter | requestBody |
| Reusable models | definitions | components/schemas |
| Security definitions | securityDefinitions | components/securitySchemes |
| Media types | consumes, produces | content |
| File upload | Special form-data handling | Improved request-body support |
| Callbacks | Not supported | Supported |

### 4.4.2 OpenAPI 3.0 Example

```yaml
openapi: 3.0.3

info:
  title: Employee Management API
  description: API for managing employee information
  version: 1.0.0

servers:
  - url: https://api.company.in/api

paths:
  /employees:
    get:
      summary: Retrieve employees
      responses:
        "200":
          description: Employees retrieved successfully
          content:
            application/json:
              schema:
                type: array
                items:
                  $ref: "#/components/schemas/Employee"

    post:
      summary: Create employee
      requestBody:
        required: true
        content:
          application/json:
            schema:
              $ref: "#/components/schemas/CreateEmployee"

      responses:
        "201":
          description: Employee created successfully

        "400":
          description: Invalid request

  /employees/{employeeId}:
    get:
      summary: Retrieve an employee
      parameters:
        - name: employeeId
          in: path
          required: true
          schema:
            type: integer

      responses:
        "200":
          description: Employee found
          content:
            application/json:
              schema:
                $ref: "#/components/schemas/Employee"

        "404":
          description: Employee not found

components:
  schemas:
    Employee:
      type: object
      properties:
        employeeId:
          type: integer
        employeeName:
          type: string
        city:
          type: string

    CreateEmployee:
      type: object
      required:
        - employeeName
        - city
      properties:
        employeeName:
          type: string
        city:
          type: string

  securitySchemes:
    BearerAuth:
      type: http
      scheme: bearer
      bearerFormat: JWT

security:
  - BearerAuth: []
```

### 4.4.3 Understanding the OpenAPI 3.0 Structure

**openapi**

Specifies which OpenAPI specification version the document uses.

**info**

Contains metadata such as API title, description, and version.

**servers**

Defines the base URLs through which the API can be accessed.

**paths**

Describes available endpoints and their supported HTTP operations.

**components**

Contains reusable schemas, parameters, responses, and security schemes.

**requestBody**

Describes the data submitted to an endpoint.

**responses**

Describes possible server responses.

**securitySchemes**

Defines the authentication mechanisms supported by the API.

### 4.4.4 Swagger UI

Swagger UI displays API documentation in an interactive browser interface.

Developers can:

- View available endpoints.
- Understand request parameters.
- Inspect JSON schemas.
- Execute API requests.
- View responses.
- Understand security requirements.

### Real-World Example

A .NET REST API exposes an OpenAPI 3.0 specification. Developers open Swagger UI, inspect the employee endpoint, provide a JWT access token, and execute a GET request directly from the browser.

---

# MODULE 5: API MECHANICS – JSON AND JWT

## 5.1 JSON – JavaScript Object Notation

JSON stands for JavaScript Object Notation.

It is a lightweight data-interchange format used to exchange information between applications.

JSON is language-independent even though its syntax is derived from JavaScript object notation.

It is widely used in REST APIs because it is relatively compact, readable, and supported by most programming languages.

### 5.1.1 Why JSON Is Used in APIs

JSON provides a standard way to represent structured data.

Applications written in different programming languages can exchange JSON without needing to understand one another's internal object structures.

For example:

- Angular can send JSON to a .NET API.
- A Java application can consume the same API.
- Python can process the response.
- A mobile application can deserialize the response.

### 5.1.2 JSON Data Types

JSON supports six basic value types.

| Data Type | Description | Example |
|---|---|---|
| String | Text value | "Rahul Sharma" |
| Number | Integer or decimal | 101, 85000.50 |
| Boolean | True or false | true |
| Object | Collection of key-value pairs | {"city":"Bengaluru"} |
| Array | Ordered collection of values | ["CSE","ECE"] |
| Null | Absence of a value | null |

### 5.1.3 JSON Object

A JSON object is represented using curly braces.

Example:

```json
{
  "employeeId": 101,
  "employeeName": "Rahul Sharma",
  "city": "Bengaluru",
  "isActive": true
}
```

Each property contains a name and a value.

Property names must be strings enclosed in double quotes.

### 5.1.4 JSON Array

An array is represented using square brackets.

Example:

```json
[
  {
    "employeeId": 101,
    "employeeName": "Rahul Sharma"
  },
  {
    "employeeId": 102,
    "employeeName": "Sneha Rao"
  },
  {
    "employeeId": 103,
    "employeeName": "Arjun Kumar"
  }
]
```

An array is useful for representing collections of employees, products, orders, or other resources.

### 5.1.5 Nested JSON Objects

JSON supports nested structures.

Example:

```json
{
  "employeeId": 101,
  "employeeName": "Rahul Sharma",
  "address": {
    "city": "Bengaluru",
    "state": "Karnataka",
    "country": "India",
    "pinCode": "560001"
  },
  "skills": [
    "C#",
    ".NET",
    "SQL Server",
    "Angular"
  ]
}
```

Here, `address` is another JSON object and `skills` is an array.

### 5.1.6 JSON vs XML

| Feature | JSON | XML |
|---|---|---|
| Structure | Key-value objects and arrays | Elements and attributes |
| Readability | Generally concise | More verbose |
| Data types | Basic native value types | Primarily text with schema-based typing |
| Parsing | Usually lightweight | Can require more processing |
| Namespaces | Not built into JSON | Supported |
| Common usage | Modern REST APIs | SOAP and document-oriented systems |

### 5.1.7 JSON Validation

Consider the following invalid JSON:

```json
{
  employeeId: 101,
  "employeeName": "Rahul Sharma",
}
```

Problems:

- `employeeId` is not enclosed in double quotes.
- A trailing comma is present.

Correct JSON:

```json
{
  "employeeId": 101,
  "employeeName": "Rahul Sharma"
}
```

### 5.1.8 JSON Serialization and Deserialization

Serialization converts an in-memory object into JSON.

Deserialization converts JSON into an in-memory object.

**Analogy:**

Imagine packing your clothes into a suitcase before travelling.

Serialization is like packing information into a standard format for transport.

Deserialization is like unpacking the information at the destination.

### C# Example

```csharp
using System.Text.Json;

public class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; }

    public string City { get; set; }
}

class Program
{
    static void Main()
    {
        Employee employee = new Employee
        {
            EmployeeId = 101,
            EmployeeName = "Rahul Sharma",
            City = "Bengaluru"
        };

        // Serialization
        string json = JsonSerializer.Serialize(employee);

        Console.WriteLine(json);

        // Deserialization
        Employee? result =
            JsonSerializer.Deserialize<Employee>(json);

        Console.WriteLine(result?.EmployeeName);
    }
}
```

Expected JSON:

```json
{
  "EmployeeId": 101,
  "EmployeeName": "Rahul Sharma",
  "City": "Bengaluru"
}
```

The exact output formatting depends on serializer options.

### Real-World Example

An Angular employee registration form sends employee information as JSON to a .NET Web API. The .NET application deserializes the request into a C# DTO, validates the information, and saves it to SQL Server.

---

## 5.2 JSON Web Token – JWT

JWT stands for JSON Web Token.

It is a compact, URL-safe format for representing claims between two parties.

JWTs are commonly used in authentication and authorization architectures.

A JWT can carry information about:

- User identity.
- User roles.
- Token issuer.
- Token audience.
- Token expiration.
- Token permissions.

### 5.2.1 Why Do We Need JWT?

Consider a web application where a user logs in with a username and password.

After successful login, the server needs a mechanism to identify the user when subsequent API requests arrive.

One approach is to maintain a server-side session.

Another approach is to issue an access token that the client sends with subsequent requests.

JWT is one commonly used token format.

### Session-Based vs Token-Based Authentication

| Session-Based | Token-Based |
|---|---|
| Server maintains session state | Client presents a token |
| Session identifier stored by client | Access token stored by client |
| Server looks up session | Server validates token or checks its status |
| Session storage is required | Can support stateless access-token validation |
| Session invalidation is straightforward with centralized session storage | Immediate token revocation may require additional mechanisms |

A JWT-based system is not automatically stateless in every respect. Refresh-token records, revocation lists, and other security state may still be maintained on the server.

### 5.2.2 Structure of JWT

A standard compact JWT contains three parts:

1. Header.
2. Payload.
3. Signature.

The three parts are separated by periods.

```text
HEADER.PAYLOAD.SIGNATURE
```

Example:

```text
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9
.
eyJzdWIiOiIxMDEiLCJuYW1lIjoiUmFodWwgU2hhcm1hIn0
.
<signature>
```

### 5.2.3 JWT Header

The header describes the token type and signing algorithm.

Example:

```json
{
  "alg": "HS256",
  "typ": "JWT"
}
```

Here:

- `alg` identifies the signing algorithm.
- `typ` identifies the token type.

### 5.2.4 JWT Payload

The payload contains claims.

A claim is a statement about an entity, commonly a user, and additional metadata.

Example:

```json
{
  "sub": "101",
  "name": "Rahul Sharma",
  "role": "Employee",
  "iss": "https://identity.company.in",
  "aud": "employee-api",
  "iat": 1795000000,
  "exp": 1795003600
}
```

Important registered claims include:

| Claim | Meaning |
|---|---|
| iss | Issuer |
| sub | Subject |
| aud | Audience |
| exp | Expiration time |
| nbf | Not valid before |
| iat | Issued at |
| jti | JWT ID |

### 5.2.5 JWT Signature

The signature protects the integrity of the token.

For an HMAC-based JWT, the signing process conceptually uses:

```text
HMACSHA256(
    BASE64URL(HEADER) + "." + BASE64URL(PAYLOAD),
    SECRET_KEY
)
```

The signature helps the API verify that the token has not been modified.

Other signing algorithms, such as RSA and ECDSA variants, use asymmetric cryptography.

### 5.2.6 Important: JWT Is Not Encrypted by Default

A normal signed JWT is encoded, not encrypted.

Anyone who possesses the token can generally decode and read its header and payload.

Therefore:

- Never place passwords inside JWT claims.
- Avoid placing confidential personal information in the payload.
- Always protect token transmission using HTTPS.
- Validate the signature and all relevant claims.
- Use appropriate expiration times.

A JWT can also be encrypted using JWE, but that is different from an ordinary signed JWT.

### 5.2.7 JWT Authentication Flow

```mermaid
sequenceDiagram
    participant U as User
    participant C as Client
    participant A as Authentication Server
    participant R as REST API

    U->>C: Enter Username and Password
    C->>A: Login Request
    A->>A: Validate Credentials
    A->>C: Issue Access Token
    C->>R: API Request + Bearer Token
    R->>R: Validate Signature and Claims
    R->>R: Check Authorization
    R-->>C: Protected API Response
```

### 5.2.8 Sending JWT in HTTP Requests

The client generally sends the access token through the Authorization header.

```http
GET /api/employees HTTP/1.1
Host: api.company.in
Authorization: Bearer <access-token>
Accept: application/json
```

The server validates the token before allowing access to protected resources.

### 5.2.9 JWT Validation

A secure JWT validation process should verify:

1. Signature: The token must have a valid signature.
2. Issuer: The token must come from a trusted issuer.
3. Audience: The token must be intended for the API receiving it.
4. Expiration: The token must not have expired.
5. Not Before: The token must not be used before its validity period.
6. Algorithm: Only explicitly permitted signing algorithms should be accepted.
7. Permissions: Required roles, scopes, or claims must be present.

### 5.2.10 Access Token vs Refresh Token

An access token is used to access protected APIs.

A refresh token is used to obtain a new access token through the authorization server.

| Access Token | Refresh Token |
|---|---|
| Sent to resource APIs | Sent to authorization server |
| Usually short-lived | Can have a longer lifetime |
| Grants access to protected resources | Obtains new access tokens |
| Should be carefully protected | Requires particularly careful protection |

Refresh tokens should be stored securely and rotated or revoked according to the identity provider's security policies.

### 5.2.11 JWT Security Best Practices

- Use HTTPS for all token transmission. Tokens must not be sent over unencrypted connections.
- Keep access-token lifetimes reasonably short. This limits the impact of token exposure.
- Store tokens carefully. Browser storage decisions should consider cross-site scripting and cross-site request forgery risks.
- Never trust token claims before validating the token. A client can modify the encoded payload, so authorization must depend on validated claims.
- Validate the issuer and audience. A token intended for another application should not be accepted.
- Implement refresh-token rotation and revocation where supported. This helps reduce the risk of stolen long-lived credentials.
- Avoid logging complete access or refresh tokens. Logs should not become a source of credential leakage.

### Real-World Example

Rahul logs in to an employee portal using his corporate account.

The identity provider authenticates him and issues an access token. The Angular application sends the token when requesting employee information from the .NET REST API.

The API validates the token and checks whether Rahul has the required permission.

---

## 5.3 JWT Implementation in ASP.NET Core – Conceptual Example

Consider a .NET REST API that needs to protect employee information.

The API uses JWT bearer authentication.

### 5.3.1 Install Required Package

```bash
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
```

Use a package version compatible with the target .NET framework.

### 5.3.2 Configure JWT Authentication

Example `appsettings.json`:

```json
{
  "Jwt": {
    "Issuer": "https://identity.company.in",
    "Audience": "employee-api"
  }
}
```

The signing key should be supplied through a secure configuration provider, such as a secret manager or environment variable, rather than committed to source control.

### 5.3.3 Configure Authentication in Program.cs

```csharp
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var jwtIssuer =
    builder.Configuration["Jwt:Issuer"];

var jwtAudience =
    builder.Configuration["Jwt:Audience"];

var jwtKey =
    builder.Configuration["Jwt:SigningKey"]
    ?? throw new InvalidOperationException(
        "JWT signing key is not configured.");

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtIssuer,

                ValidateAudience = true,
                ValidAudience = jwtAudience,

                ValidateLifetime = true,

                ValidateIssuerSigningKey = true,

                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtKey)
                ),

                ClockSkew = TimeSpan.FromMinutes(1)
            };
    });

builder.Services.AddAuthorization();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
```

This example assumes the application has a properly configured signing key and token issuer.

In production, asymmetric signing and a dedicated identity provider are often preferable to sharing one symmetric signing secret across multiple services.

### 5.3.4 Create a Protected API Controller

```csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/employees")]
public class EmployeeController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult GetEmployees()
    {
        var employees = new[]
        {
            new
            {
                EmployeeId = 101,
                EmployeeName = "Rahul Sharma",
                City = "Bengaluru"
            },
            new
            {
                EmployeeId = 102,
                EmployeeName = "Sneha Rao",
                City = "Mysuru"
            }
        };

        return Ok(employees);
    }
}
```

The `[Authorize]` attribute requires an authenticated principal.

The application must configure a trusted authentication scheme that validates the supplied token.

### 5.3.5 Role-Based Authorization

The application can restrict operations based on roles.

```csharp
[HttpDelete("{id}")]
[Authorize(Roles = "Admin")]
public IActionResult DeleteEmployee(int id)
{
    return NoContent();
}
```

Only users whose validated identity has the required `Admin` role can access this endpoint.

### Real-World Example

An employee can retrieve employee directory information, but only an administrator can delete employee records. The API uses authentication to identify the user and role-based authorization to control access.

---

# MODULE 6: HANDS-ON PRACTICAL LABS

## 6.1 Lab 1 – Explore an Existing REST API

**Objective:** Understand how a client communicates with a REST API.

**Tools Required:**

- Postman or curl.
- Internet connection.
- A public test API.

Use the JSONPlaceholder test service.

Base URL:

```text
https://jsonplaceholder.typicode.com
```

### Step 1: Retrieve All Posts

```http
GET https://jsonplaceholder.typicode
