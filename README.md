# unit-conversion-api

# Unit Conversion API

## Overview

The Unit Conversion API is a RESTful web service built with **ASP.NET Core 8** that converts numerical values between different units of measurement.

The API currently supports the following conversion categories:

* Length
* Weight (Mass)
* Temperature

The solution is designed using **Clean Architecture** principles to promote maintainability, scalability, and separation of concerns. Although conversion data is hardcoded for this assignment, the architecture allows future expansion to support hundreds of units and conversion categories.

---

# Technologies Used

* ASP.NET Core 8 Web API
* C#
* Clean Architecture
* Dependency Injection
* Swagger (OpenAPI)
* FluentValidation
* xUnit

---

# Project Structure

```text
UnitConversionApi
│
├── src
│   ├── UnitConversion.Api
│   ├── UnitConversion.Application
│   ├── UnitConversion.Domain
│   └── UnitConversion.Infrastructure
│
├── tests
│   └── UnitConversion.Tests
│
├── UnitConversionApi.sln
└── README.md
```

---

# Prerequisites

Before running the project, ensure you have the following installed:

* .NET 8 SDK
* Visual Studio 2022 (2022 v17.8 or later) or Visual Studio Code
* Git (optional)

Verify your .NET installation:

```bash
dotnet --version
```

The output should show **8.x.x**.

---

# Clone the Repository

```bash
git clone <your-github-repository-url>
```

Navigate to the project folder:

```bash
cd UnitConversionApi
```

---

# Restore Dependencies

```bash
dotnet restore
```

---

# Build the Solution

```bash
dotnet build
```

---

# Run the Application

Navigate to the API project:

```bash
cd src/UnitConversion.Api
```

Run the application:

```bash
dotnet run
```

Example output:

```text
Now listening on:
https://localhost:7001
http://localhost:5001
```

---

# Open Swagger

Open the following URL in your browser:

```
https://localhost:7001/swagger
```

Swagger provides interactive documentation for testing the API.

---

# API Endpoint

**POST**

```
/api/conversion
```

### Sample Request

```json
{
  "category": "Length",
  "fromUnit": "Meter",
  "toUnit": "Foot",
  "value": 10
}
```

### Sample Response

```json
{
  "category": "Length",
  "fromUnit": "Meter",
  "toUnit": "Foot",
  "originalValue": 10,
  "convertedValue": 32.8084
}
```

---

# Supported Units

## Length

* Millimeter
* Centimeter
* Meter
* Kilometer
* Inch
* Foot
* Yard
* Mile

## Weight

* Milligram
* Gram
* Kilogram
* Ton
* Ounce
* Pound

## Temperature

* Celsius
* Fahrenheit
* Kelvin

---

# Running Unit Tests

From the solution root:

```bash
dotnet test
```

This executes all unit tests in the `UnitConversion.Tests` project.

---

# Design Decisions

* Implemented using Clean Architecture for clear separation of responsibilities.
* Business logic is isolated from the API layer.
* Dependency Injection is used for loose coupling.
* Validation is implemented using FluentValidation.
* Global exception handling provides consistent error responses.
* Conversion factors are currently hardcoded, as permitted by the assignment.
* The architecture can be extended to load units from a database, configuration, or external service without changing the API.

---

# Future Improvements

* Add additional conversion categories (Area, Volume, Speed, Time, Pressure, Energy, etc.).
* Store unit definitions in a database.
* Implement caching for frequently used conversions.
* Add API versioning.
* Add structured logging.
* Add authentication and authorization.
* Containerize the application using Docker.
* Add CI/CD pipeline integration.
* Increase integration and end-to-end test coverage.

---

# License

This project was created as a technical assessment and is intended for demonstration purposes.
