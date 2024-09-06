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

## A comon Clean Architecture Folder and File Structure (Tree View)
<img width="1024" alt="image" src="https://github.com/user-attachments/assets/6d8c0e52-9bff-4c9f-84be-6f3e61b95d30">

## Installation

1. **Clone the repository**:

   ```bash
   git clone https://github.com/olemalik/Academy.git
