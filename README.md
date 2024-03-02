# Project Name

This project implements a database structure for managing recyclable types and items using Entity Framework and .NET 4.8.

## Overview

The project consists of two main entities: **Recyclable Type** and **Recyclable Item**.

### Recyclable Type

- **Attributes:**
  - **Id:** Integer (Primary Key)
  - **Type:** String (Unique, max length of 100)
  - **Rate:** Decimal (2 decimal places)
  - **MinKg:** Decimal (2 decimal places)
  - **MaxKg:** Decimal (2 decimal places)

- **Views:**
  - **List:** View all recyclable types
  - **Add:** Add a new recyclable type
  - **Edit:** Edit existing recyclable type
  - **Delete:** Delete existing recyclable type
  - **Save:** Save changes
  - **Reset:** Reset form

- **Notes:**
  - Use any ORM you are comfortable with:
    - Entity Framework (used in this project)
    - Dapper 
    - Plain ADO .NET plus stored procedure is a plus 
  - Use JavaScript if applicable
  - .NET Framework 4.5 to 4.8

### Recyclable Item

- **Attributes:**
  - **Id:** Integer (Primary Key)
  - **Description:** String (Max length of 150)
  - **RecyclableTypeId:** Integer (Foreign Key)
  - **Weight:** Decimal (2 decimal places)
  - **ComputedRate:** Decimal (2 decimal places, auto computed)

- **Views:**
  - **List:** View all recyclable items
  - **Add:** Add a new recyclable item
  - **Edit:** Edit existing recyclable item
  - **Delete:** Delete existing recyclable item
  - **Save:** Save changes
  - **Reset:** Reset form

- **Computed Rate computation:**
  - Formula: Recyclable Type Rate * Weight input
  - Roundoff to two decimal places

## Tools

- **Development Environment:** Visual Studio
- **Framework:** .NET 4.8
- **Database:** SQL Server
- **Database Management Tool:** SQL Server Management Studio

## Notes

- This project utilizes C# and MVC architecture for development.
- Make sure to configure your development environment and database connection appropriately before running the project.
