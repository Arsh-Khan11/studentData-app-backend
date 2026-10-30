# Student API

An ASP.NET Core Web API built with .NET 10, Entity Framework Core, and PostgreSQL. It provides a configured admin login endpoint and CRUD endpoints for student details.

## Requirements

- .NET 10 SDK
- PostgreSQL

## Configuration

The API reads its PostgreSQL connection string from `ConnectionStrings:Default` and login credentials from `AdminLogin:Email` and `AdminLogin:Password`.

For local development, store these values with .NET user-secrets rather than committing credentials:

```bash
dotnet user-secrets set "ConnectionStrings:Default" "Host=localhost;Database=YOUR_DB;Username=YOUR_USER;Password=YOUR_PASSWORD"
dotnet user-secrets set "AdminLogin:Email" "YOUR_ADMIN_EMAIL"
dotnet user-secrets set "AdminLogin:Password" "YOUR_ADMIN_PASSWORD"
```

Replace the example values with your local PostgreSQL connection details and desired admin credentials. The checked-in `appsettings.json` connection string is only a placeholder.

## Run locally

```bash
dotnet restore
dotnet ef database update
dotnet run
```

Swagger UI is enabled in the Development environment. The API's CORS policy allows requests from `http://localhost:5173`.

## API endpoints

### Admin login

`POST /api/student/login`

Request body:

```json
{
  "email": "YOUR_ADMIN_EMAIL",
  "password": "YOUR_ADMIN_PASSWORD"
}
```

Returns `200 OK` with `true` for matching configured credentials, or `401 Unauthorized` with `false` otherwise.

### Student details

The student model includes `id`, `name`, `email`, `course`, `year`, and `status`.

| Method | Route | Description |
|---|---|---|
| `GET` | `/api/studentdetails` | Get all student records |
| `POST` | `/api/studentdetails` | Create a student record |
| `PUT` | `/api/studentdetails/{id}` | Update a student record |
| `DELETE` | `/api/studentdetails/{id}` | Delete a student record |

Example request body for creating or updating a student:

```json
{
  "name": "Example Student",
  "email": "student@example.com",
  "course": "Computer Science",
  "year": "1",
  "status": "Active"
}
```

## Build

```bash
dotnet build
```
