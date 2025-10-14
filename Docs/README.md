# Hospital Doctors & Patients - Console App (C#)

Scaffold project for the "Prueba de desempeño" adapted to manage **Doctors**, **Patients**, and **Appointments**.

## Features implemented (minimum viable)
- Patients: create, edit, list, unique document validation.
- Doctors: create, edit, list, filter by specialty, unique document validation.
- Appointments: schedule (with conflict checks for doctor and patient), cancel, mark as attended, list by doctor, list by patient.
- Email sending is implemented as a stub (`Utils/EmailService`) which prints to console and updates appointment `EmailSentStatus` ("sent"/"not sent").
- In-memory persistence via `Data/InMemoryDatabase` using `List<>`.
- Basic validation and try/catch handling across flows.

## Requirements
- .NET 8.0 SDK

## How to run
1. Install .NET 8 SDK: https://dotnet.microsoft.com
2. From the project folder run:
```bash
dotnet run
```

## Project layout
- `Domain/` - models and interfaces
- `Repositories/` - in-memory repositories and database
- `Services/` - business logic and interactive console helpers
- `Utils/` - helper services (email)
- `Program.cs` and `Menu.cs`

## Notes
- This is an educational scaffold that follows the enunciado requirements. To use a real DB replace repository implementations with EF Core and a real RDBMS (MySQL/Postgres) and update the README with migration steps.

## Author
- Elias Ching 
- Caiman
- srching23@gamil.com
