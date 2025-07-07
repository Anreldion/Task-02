# Task-02: Product System with Operator Overloading, Serialization, and Testing

## Project Structure

### `ProductManager.Core` — Class Library
Contains:
- `Products/` — abstract base class `Product` and concrete types (e.g., `Meat`, `Milk`, `Fish`, etc.).
- `Exceptions/` — custom exceptions such as `ProductException`.
- `Services/`
  - `Parser.cs` — serialization/deserialization of product objects using `Newtonsoft.Json` with polymorphic support.
  - `FileService.cs` — file I/O operations: save, read, delete.
  - `FolderService.cs` — folder creation and deletion.
- `Utilities/` — helper classes for validation (`Guard`, etc.).

### `ProductManager.Core.Interfaces`
Interfaces for service abstraction:
- `IParser`, `IFileService`, `IFolderService`

### `ProductManager.Tests` — Test Project
Contains:
- `Unit/Products/` — unit tests for:
  - unit cost and total cost calculation
  - operator overloading (`+`, `-`)
  - type conversion to `decimal` and `int`
  - equality and string representation
- `Unit/Parsers/` — tests for JSON serialization and deserialization
- `Shared/` — reusable test helpers (`TestProduct`, `TestData`)
- `Integration/` — integration tests that cover:
  - full cycle: product → JSON → file → JSON → product
  - file and folder handling
  - error handling on corrupted JSON
  - working with collections of products

## Features

- Object-oriented structure with abstract base and derived product types
- Operator overloading:
  - `+` for combining same products with weighted price/markup averaging
  - `-` for subtracting quantity with validation
  - implicit conversion to `decimal` (total cost)
  - implicit conversion to `int` (cost in cents)
- Full unit and integration test coverage
- JSON serialization with polymorphism support using `Newtonsoft.Json`
- File and folder management via dedicated services

## Example Test Coverage

- `Product + Product`
- `Product - int`
- `(decimal)Product`, `(int)Product`
- `Equals()`, `ToString()`
- `Parser.Serialize()`, `Parser.Deserialize()`
- `FileService.Save()`, `TryRead()`, `TryDelete()`
- End-to-end test: Save → Load → Compare

## Dependencies

- .NET SDK 8 or higher
- `Newtonsoft.Json` for polymorphic serialization
- `MSTest` for unit and integration testing

## Author

Developed by Andrei Samusenka as part of a test task for EPAM Systems.