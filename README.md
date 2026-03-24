# 🎸 Band Management API: Clean Architecture & Unit Testing

## **Overview**
This project is a high-quality **ASP.NET Core Web API** designed to demonstrate the implementation of **Clean Architecture** and the **Repository Pattern** in C#. The goal was to create a system that is easy to scale, maintain, and—most importantly—test in isolation.

---

## **🏗️ Architectural Layers**

### **1. Web API Layer (Controllers)**
The `BandController` serves as the entry point. It uses **Primary Constructors** to inject the `IBandService`, ensuring the controller only handles request routing and HTTP status code responses (Ok, NotFound, BadRequest).

### **2. Business Logic Layer (Services)**
The `BandService` acts as the "brain" of the application. It sits between the Controller and the Data Access layer, ensuring that business rules are applied before any data is persisted.

### **3. Data Access Layer (Repositories)**
The `BandRepository` handles all communication with the **SQL Server** database via **Entity Framework Core**. By using the Repository Pattern, the rest of the application remains unaware of the specific database technology used.

### **4. Abstraction Layer (Interfaces)**
Interfaces like `IBandService` and `IBandRepository` decouple the components, allowing for seamless **Dependency Injection** and making the system highly modular.

---

## **🧪 Testing Strategy**
The project features a robust **Unit Testing** project (`LearningProject2Testing`) that achieves high code coverage using:

* **NUnit:** The primary testing framework.
* **Moq:** Used to create mock objects of the Service layer. This allows the tests to verify the Controller's logic without needing a live database or running the actual service code.
* **Edge Case Validation:** Tests cover positive paths (returning lists), negative paths (NotFound responses), and exception handling (validating that specific error messages are returned to the user).

---

## **🛠️ Technical Stack**
| Category | Technology |
| :--- | :--- |
| **Framework** | .NET 8 / ASP.NET Core |
| **ORM** | Entity Framework Core |
| **Architecture** | Clean Architecture / Repository Pattern |
| **Testing** | NUnit & Moq |
| **DI** | Built-in .NET Dependency Injection |

---

## **🏆 Key Learning Outcomes**
* Implementing **Dependency Injection** to increase code flexibility.
* Mastering **Mocking** with Moq to isolate components during testing.
* Building a **Layered Architecture** where each class has a Single Responsibility (SRP).
* Handling **Custom Exceptions** to provide clear, meaningful API feedback.
