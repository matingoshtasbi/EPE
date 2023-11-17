# Employee Performance Evaluation App

[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

## Description

This Windows Forms application, built with .NET 6, manages employee information, basic employee details, and evaluation items used for employee performance assessments. The application utilizes a SQL Server database with Entity Framework Core Code-First to ensure the creation of the database. It performs calculations for employee performance evaluations.

## Features

- **Employee Management:**
  - Add, edit, and delete employee information.
  - Manage basic employee details.

- **Evaluation Item Management:**
  - Define and customize evaluation criteria.
  - Use these criteria for employee performance assessments.

- **Performance Evaluation:**
  - Perform calculations based on evaluation items.
  - Generate reports or summaries of employee performance.

## Getting Started

### Prerequisites

- [.NET 6](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/sql-server)

### Installation

1. Clone the repository.
2. Open the solution in Visual Studio or your preferred IDE.
3. Restore NuGet packages.
4. Update the connection string in `appsettings.json` to point to your SQL Server instance.
5. Run the application.

## NuGet Packages

- [Microsoft.Extensions.Hosting 6.0.1]
- [Microsoft.EntityFrameworkCore.SqlServer 6.0.23]
- [Microsoft.EntityFrameworkCore.Design 6.0.23]
- [Microsoft.EntityFrameworkCore.Tools 6.0.23]
- [Microsoft.Extensions.DependencyInjection 6.0.1]
- [Microsoft.Extensions.Localization.Abstractions 7.0.12]
- [AutoMapper 12.0.1]
- [AutoMapper.Extensions.Microsoft.DependencyInjection 12.0.1]
- [Microsoft.EntityFrameworkCore.Proxies 6.0.23]

## Usage

1. Launch the application.
2. Use the interface to manage employee information and evaluation items.
3. Perform employee performance evaluations using the provided features.

## Configuration

- Update the connection string in `appsettings.json` with your database details.

## Database Setup

- This application uses Entity Framework Core Code-First Approch to ensure the creation of the database.

## Contributing

Contributions are welcome! Please follow [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Documentation

Additional documentation can be found Inside the Code ;)
