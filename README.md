# Particulate Register

## Overview
Particulate Register is a full-stack web application for managing and tracking particulates, their types, detection statuses, and historical changes. The solution is built with a .NET 7 backend and a React/TypeScript frontend. It is designed as a proof of concept (POC) with rapid prototyping and demonstration in mind.

## Projects

- **ParticulateRegister.Server**: ASP.NET Core Web API backend.
- **ParticulateRegister.Domain**: Domain models, services, and business logic.
- **ParticulateRegister.Data**: Data access layer and Entity Framework context.
- **ParticulateRegister.Contracts**: Shared contracts and enums for API models.
- **particulateregister.client**: React + TypeScript frontend client.

## Architecture

### Backend (.NET 7)
- **ASP.NET Core Web API**: Exposes RESTful endpoints for CRUD operations and enum value retrieval.
- **Domain Layer**: Contains business logic, models, and services (e.g., `ParticulateService`).
- **Data Layer**: Uses Entity Framework Core with an **in-memory database** for POC purposes. No data is persisted between restarts.
- **Contracts Layer**: Defines shared API models and enums for type safety between backend and frontend.
- **AutoMapper**: Used for mapping between API models and domain models, with explicit configuration to ignore history during updates.

### Frontend (React + TypeScript)
- **React Components**: Implements UI for listing, viewing, editing, and registering particulates.
- **API Layer**: Handles communication with backend endpoints using `fetch`.
- **Enum Value Fetching**: Enum values for particulate type and detection status are fetched from the backend in each component (not cached globally).
- **Context**: Uses React Context for particulate data management and refresh logic.
- **Styling**: Uses Bootstrap classes and custom CSS for a clean, responsive UI.

## Features

- Register, view, edit, and delete particulates.
- Track particulate type and detection status (enum-based).
- Maintain history of status/type changes.
- Search and filter particulates in the client UI.
- Responsive and modern UI with improved layout and accessibility.

## Proof of Concept (POC)

- The backend uses an **in-memory database** for demonstration and testing purposes. This allows rapid prototyping and does not persist data between application restarts.

## Getting Started

### Prerequisites
- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Node.js & npm](https://nodejs.org/)
- [Visual Studio 2022 or later](https://visualstudio.microsoft.com/)

## Running the Solution
- Open the solution in **Visual Studio** and press `F5` to start both backend and frontend projects automatically.
- Alternatively, use the command line to run backend (`dotnet run`) and frontend (`npm run dev`) projects separately.

## API Endpoints
- `GET /api/particulates` - List all particulates
- `GET /api/particulates/{id}` - Get particulate by ID
- `POST /api/particulates` - Create a new particulate
- `PUT /api/particulates/{id}` - Update a particulate
- `DELETE /api/particulates/{id}` - Delete a particulate
- `GET /api/enums/particulate-types` - Get particulate types
- `GET /api/enums/detection-statuses` - Get detection statuses

## Development Notes
- Enum values are mapped between backend (number) and frontend (string) for user-friendly display.
- History tracking is automatic on status/type/note changes.
- UI components are styled for clarity and accessibility.

## Assumptions
- The application is intended as a proof of concept and uses an in-memory database for backend storage.
- The backend and frontend are run locally and communicate over HTTP/HTTPS.
- No authentication or authorization is implemented.
- Data is not persisted between application restarts.

## Prioritization & Stubs
- **Prioritized:** Core CRUD features, enum mapping, history tracking, and a clean UI for demonstration.
- **Stubbed/Skipped:**
  - Authentication and authorization (not implemented).
  - Persistent database (using in-memory for POC).
  - Advanced error handling and validation (basic only).
  - Production deployment scripts and configuration.
  - Accessibility and internationalization (basic only).
  - Any features not directly related to particulate management.

## Future Improvements
- Implement persistent database (e.g., SQL Server, PostgreSQL).
- Add authentication and authorization.
- Enhance error handling and validation.
- Improve accessibility and internationalization.
- Prepare for production deployment.

## License
This project is open source and available under the MIT License.
