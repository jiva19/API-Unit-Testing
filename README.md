# 🎸 Band Management API: Clean Architecture & Unit Testing

## **🎯 Project Objective**
The primary goal of this project was to move beyond basic CRUD and deeply understand the practical implementation of **Dependency Injection (DI)**. I built this to explore:
* **Decoupling:** How using **Interfaces** (`IBandService`, `IBandRepository`) allows the Controller to remain "blind" to the underlying database logic.
* **Testability with Mocks:** How DI enables the use of **Moq** to isolate the Controller during Unit Testing, ensuring that tests are fast and independent of the data layer.
* **Clean Architecture:** Gaining a hands-on grasp of how a 3-layer structure (Web, Business, Infrastructure) prevents code from becoming a "Big Ball of Mud."

---

## **🏗️ Architectural Layers**

### **1. Web API Layer (Controllers)**
The `BandController` serves as the entry point. It uses **Primary Constructors** to inject the `IBandService`. This layer is strictly responsible for request routing and returning appropriate HTTP status codes.

### **2. Business Logic Layer (Services)**
The `BandService` acts as the intermediary. By implementing `IBandService`, it ensures that business rules are applied before data reaches the repository, keeping the logic centralized and reusable.

### **3. Data Access Layer (Repositories)**
The `BandRepository` handles all communication with the database via **Entity Framework Core**. This demonstrates the **Repository Pattern**, where the data access logic is completely abstracted away from the rest of the application.

---

## **🧪 Testing Strategy**
To validate the benefits of Dependency Injection, I built a robust **Unit Testing** suite:

* **NUnit & Moq:** I used **Moq** to create "fake" versions of the Service layer. This allowed me to test if the Controller correctly handles different scenarios (like a `404 Not Found` when a list is empty) without ever needing a real database.
* **Behavior Validation:** Tests cover positive paths, empty results, and **Custom Exception Handling** (verifying that `ArgumentException` triggers a `400 BadRequest`).

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
* **Interfaces as Contracts:** Understood how coding to an interface makes the system modular.
* **Mocking Mastery:** Learned how to setup `ReturnsAsync` and `ThrowsAsync` in Moq to simulate complex backend behaviors.
* **Separation of Concerns:** Achieved a practical understanding of keeping "Web" logic and "Data" logic in their own boxes.
