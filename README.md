# Students Education Platform

Welcome to the **Students Education Platform**, a robust and feature-rich ASP.NET Core MVC web application designed to streamline student registration, department assignments, course tracking, and exam scheduling. 

This platform offers dedicated portals for **Students** and **Administrators (Admins)**, ensuring seamless management of educational activities.

---

## 🚀 Features

### 🔐 Authentication & Role Management
- **Dual-role Authentication**: Supports sign-in for both **Students** and **Admins**.
- **Secure Registration**: Register new students with department assignments and input validation.
- **Session-Based State**: Safe session management using cookie-backed HTTP Session state.

### 🎓 Administrator (Admin) Portal
- **Student Management**: CRUD operations for managing student profiles (Name, Age, Address, Email, Department).
- **Department Administration**: Manage educational departments (e.g. CS, Front-End, Cyber Security, ASP.NET).
- **Course Cataloging**: Track courses by duration and map them to their respective departments.
- **Exam Scheduling**: Create, edit, and schedule examinations for specific courses, indicating dates and full marks.

### 📖 Student Portal
- View personalized dashboard showing enrolled details and associated department info.
- View courses and check scheduled exams.

---

## 🛠️ Technology Stack

- **Framework**: ASP.NET Core 9.0 (MVC Pattern)
- **Database ORM**: Entity Framework Core 9.0
- **Database Engine**: Microsoft SQL Server
- **Frontend Utilities**: Bootstrap 5, HTML5, CSS3, jQuery (Client-Side Validation)
- **Session Management**: ASP.NET Core Session Middleware

---

## 📊 Database Schema & Seed Data

The platform initializes with pre-configured seed data for quick testing.

### Entity Relationships
- **Department**: Has many **Students** and many **Courses**.
- **Course**: Belongs to a **Department** and has many **Exams**.
- **Exam**: Belongs to a **Course**.
- **Student**: Belongs to a **Department**.
- **User (Admin)**: Standalone user with administrative privileges.

### Pre-Seeded Departments
- SOC
- ASP.NET
- IS
- Laravel
- Cyber Security
- CS
- Front-End

---

## ⚙️ Prerequisites & Setup

Ensure you have the following installed on your system:
- **.NET SDK 9.0**
- **Microsoft SQL Server** (LocalDB or Express)

### 1. Database Connection Configuration
Open [MyContext.cs](file:///c:/Users/omars/source/repos/Students_Education_Platform/Models/MyContext.cs#L9-L12) and configure your SQL Server connection string under the `OnConfiguring` method:
```csharp
optionsBuilder.UseSqlServer("Server=YOUR_SERVER_NAME;database=FinalProjectITI;trusted_connection=true;trustServerCertificate=true");
```

### 2. Apply Migrations
Initialize the database and schema structure using Entity Framework Core tools. Run the following command in the project directory:
```bash
dotnet ef database update
```

---

## 🏃 Run the Application

Navigate to the project root directory and execute:

```bash
# Build the project
dotnet build

# Start the application
dotnet run --project Students_Education_Platform
```

Once running, navigate to `http://localhost:5000` (or the port specified in the console output) in your web browser.

### Default Credentials (Seed Data)
| User Role | Username/Email | Password |
|---|---|---|
| **Admin** | `marawan@example.com` | `00000000` |
| **Admin** | `omaraahmed7@example.com` | `99999999` |
| **Student** | `omaraahmed00@example.com` | `opoppoop` |
| **Student** | `ahmedomar@example.com` | `mkimki` |