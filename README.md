## 👨‍💻 Author

Nickname - hadi

# Task Manager (Console App)

A simple but well-structured console-based task manager built with C# and .NET, demonstrating clean architecture principles and separation of concerns.

---

## Features

- Create new tasks  
- View all tasks  
- View task by ID  
- Update task (title, description,status)  
- Delete tasks  
- Input validation and error handling  

---

## Architecture

The project follows a layered structure:

---

### Responsibilities

- **UI**  
  Handles rendering of console interface and user interaction  

- **Handler**  
  Controls application flow and connects UI with business logic  

- **Service**  
  Contains business logic (CRUD operations, validation, status changes)  

- **Repository**  
  Manages data storage (in-memory)  

---

## Design Principles

- Separation of concerns  
- Single Responsibility Principle (SRP)  
- Dependency injection (manual)  
- Clean and readable console UI  

---

## Task Model

public class TaskItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskItemStatus Status { get; set; }
    public DateTime CreatedDate { get; set; }
}

---

## Task Status:
- New
- In Progress
- Completed
- Canceled

---

# How to Run
- Clone the repository:
- git clone https://github.com/your-username/task-manager.git
- Open in Visual Studio
- Run the project:
- Ctrl + F5

---

## ⚠️ Known Limitations

- Data is stored in-memory (not persistent)
- No multi-user support
- Console UI depends on window size
- It is important that the console be open in full-screen mode

---

## Future Improvements

🔄 Persistent storage (file / database)
🎨 Improved UI navigation
🧪 Unit tests
🔍 Search and filtering
🌐 API version (ASP.NET Core)

---
