# 🐾 Vet Diary

>  This project is a veterinary practice management solution which allows tracking clients, patients, and diary entries all in one place.

![.NET Version](https://img.shields.io/badge/.NET-8.0-purple)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-8.0-blue)
![License](https://img.shields.io/badge/license-MIT-green)

---

## 📋 Table of Contents

- [About the Project](#about-the-project)
- [Technologies Used](#technologies-used)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Features](#features)
- [Usage](#usage)
- [Database Setup](#database-setup)
- [Configuration](#configuration)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

---

## 📖 About the Project

This is a simple vet clinic management web application intended to help veterinary doctors keep track of patient profiles, animal species and breed details, as well as medical examination records. 
It is built as part of the *ASP.NET Fundamentals* course and demonstrates core concepts like MVC architecture and Entity Framework Core.

---

## 🛠️ Technologies Used

| Technology            | Version  | Purpose                          |
|-----------------------|----------|----------------------------------|
| ASP.NET Core MVC      | 8.0      | Web framework                    |
| Entity Framework Core | 8.0      | ORM / Database access            |
| SQL Server / SQLite   | -        | Database                         |
| Bootstrap             | 5.1.0    | Frontend styling                 |
| Razor Pages / Views   | -        | Server-side HTML rendering       |

---

## ✅ Prerequisites

Make sure you have the following installed before running the project:

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- [Git](https://git-scm.com/)

---

## 🚀 Getting Started

Follow these steps to get the project running locally.

### 1. Clone the repository

```bash
git clone https://github.com/anita-k/VetDiary
cd VetDiary/VetDiary.Web
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Apply database migrations

```bash
dotnet ef database update
```

### 4. Run the application

```bash
dotnet run
```

The app will be available at `https://localhost:7242` or `http://localhost:5118`.

---

## 📁 Project Structure

```
VetDiary Solution/
│
├── Data
    ├──VetDiary.Data              # DbContext and migrations
        ├──Configurations         
        ├──Migrations
    ├──VetDiary.Data.Models       # Domain models
├── Services                      # Business logic / service layer
    ├──VetDiary.Services
        ├──Interfaces
├── Shared                        # Validation constants and enumerations  
├── Web
    ├──VetDiary.ViewModels                
    ├──VetDiary.Web
        ├── Controllers           # MVC Controllers
        ├── Views                 # Razor Views (.cshtml)
        ├── wwwroot/              # Static files (CSS, JS, images)
        ├── appsettings.json      # App configuration
        └── Program.cs            # App entry point
```

---

## ✨ Features

- [x] User registration and login (ASP.NET Identity)
- [x] CRUD operations for entities (Pet, Species, Breed, Client, DiaryEntry, VisitReason)
- [x] Input validation (server-side & client-side)
- [x] Responsive UI with Bootstrap

---

## 💻 Usage

After launching the app:

```
1. Navigate to /Register to create an account.
2. Log in at /Login.
3. Use the dashboard to manage all entities (Pet, Species, Breed, Client, DiaryEntry, VisitReason).
```

![Screenshot](docs/homepage_screenshot.jpg)

---

## 🗄️ Database Setup

The project uses **Entity Framework Core** with a Code-First approach.

Connection string is configured in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=YourDbName;Trusted_Connection=True;"
}
```

To create and seed the database:

```bash
dotnet ef database update
```

---

## ⚙️ Configuration

Key settings in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "your-connection-string-here"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  }
}
```
---

## 🤝 Contributing

Contributions are welcome! To contribute:

1. Fork the repository
2. Create a new branch: `git checkout -b feature/your-feature-name`
3. Commit your changes: `git commit -m "Add some feature"`
4. Push to the branch: `git push origin feature/your-feature-name`
5. Open a Pull Request

---

## 📄 License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.

---

## 📬 Contact

**Anita K.** – [@anita-k](https://github.com/anita-k)

Project Link: [https://github.com/anita-k/VetDiary](https://github.com/anita-k/VetDiary)

---

*Built as part of the **ASP.NET Fundamentals** course.*
