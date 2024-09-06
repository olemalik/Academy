# Academy

## Overview

**Academy** is a web application focused on student registration and management. Built using .NET Framework with clean architecture principles, the project aims to provide a structured approach to handling student data with future plans to include QR code functionality.

## Features

- **Student Registration**: Manage student records with ease.
- **Future Development**:
  - QR code integration for quick access and validation of student information.

## Tech Stack

- **Backend**: .NET Framework 4.7.2, Web API with Clean Architecture
- **Frontend**: ASP.NET Web Forms
- **Database**: SQLite (configured in the Infrastructure layer)
- **Architecture**: Clean Architecture (Presentation, Application, Domain, and Infrastructure layers)

## Architecture

The project follows the Clean Architecture pattern, ensuring a well-organized codebase:

- **Presentation Layer**: ASP.NET Web Forms for the user interface.
- **Application Layer**: Manages business logic and use cases.
- **Domain Layer**: Defines core entities and business rules.
- **Infrastructure Layer**: Handles data access, including SQLite configuration.

## Prerequisites

- .NET Framework 4.7.2
- Visual Studio 2019 or later
- SQLite installed in the Infrastructure layer

## Clean Architecture Folder and File Structure (Tree View)
Academy
│
├── src
│   ├── Academy.WebForms             # Presentation Layer (ASP.NET Web Forms)
│   │   ├── App_Start                # Configuration files (e.g., RouteConfig, BundleConfig)
│   │   ├── Controls                 # User controls (e.g., .ascx files)
│   │   ├── Pages                    # Web Forms pages (e.g., .aspx files)
│   │   ├── Scripts                  # JavaScript and client-side scripts
│   │   ├── Styles                   # CSS files and stylesheets
│   │   ├── Models                   # View Models specific to the Web Forms project
│   │   ├── Global.asax.cs           # Global application class
│   │   └── Web.config               # Configuration file for the Web Forms application
│   │
│   ├── Academy.API                  # Presentation Layer (Web API)
│   │   ├── Controllers              # API Controllers
│   │   ├── Models                   # DTOs and request/response models
│   │   ├── Filters                  # API filters (e.g., Authorization filters)
│   │   ├── Startup.cs               # Application startup configuration
│   │   └── appsettings.json         # Configuration file for the Web API
│   │
│   ├── Academy.Application          # Application Layer
│   │   ├── Interfaces               # Service interfaces, repositories, etc.
│   │   ├── Services                 # Implementation of business logic and use cases
│   │   ├── DTOs                     # Data Transfer Objects for communication
│   │   └── Exceptions               # Custom exceptions for the application layer
│   │
│   ├── Academy.Domain               # Domain Layer
│   │   ├── Entities                 # Core entities of the domain
│   │   ├── Interfaces               # Domain interfaces (e.g., IRepository, IUnitOfWork)
│   │   └── ValueObjects             # Value objects and enums
│   │
│   ├── Academy.Infrastructure       # Infrastructure Layer
│   │   ├── Data                     # Database context and migrations (EF Core or other ORMs)
│   │   ├── Repositories             # Implementation of repository interfaces
│   │   ├── Services                 # Infrastructure services (e.g., Email, Logging)
│   │   └── Configurations           # Database and entity configurations
│
├── tests
│   ├── Academy.Application.Tests    # Unit Tests for the Application Layer
│   ├── Academy.Domain.Tests         # Unit Tests for the Domain Layer
│   ├── Academy.Infrastructure.Tests # Integration Tests for the Infrastructure Layer
│   └── Academy.API.Tests            # Integration Tests for the Web API
│
└── README.md                        # Project documentation

<img width="1024" alt="image" src="https://github.com/user-attachments/assets/6d8c0e52-9bff-4c9f-84be-6f3e61b95d30">

## Installation

1. **Clone the repository**:

   ```bash
   git clone https://github.com/olemalik/Academy.git
