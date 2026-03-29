using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task_Manager_GPT.Helpers;
using Task_Manager_GPT.Interfaces;
using Task_Manager_GPT.Models;
using Task_Manager_GPT.Repositories;
using Task_Manager_GPT.Services;
using Task_Manager_GPT.UI;

namespace Task_Manager_GPT;

internal class Program
{
    static void Main()
    {
        var taskRepository = new TaskRepository();
        var taskIdGenerator = new IdGenerator();
        var taskService = new TaskService(taskRepository, taskIdGenerator);
        var taskConsoleMenu = new ConsoleMenu();
        var taskInputHandler = new ConsoleInputHandler(taskService, taskConsoleMenu);
        taskInputHandler.WorkProcess();
    }
}
/* Тестування Idgenerator
     var generator = new IdGenerator();
     var time = generator.GenerateId();
     Console.WriteLine(time);
     var time2 = generator.GenerateId();
     Console.WriteLine(time2);
     var time3 = generator.GenerateId();
     Console.WriteLine(time3);
     var time4 = generator.GenerateId();
     Console.WriteLine(time4);
     var time5 = generator.GenerateId();
     Console.WriteLine(time5);
*/
/* Тестування TaskRepository
Console.WriteLine("=== Тестування TaskRepository ===");

// 1. Створюємо репозиторій
var repository = new TaskRepository();

// 2. Тестуємо Add()
var task1 = new TaskItem { Id = 1, Name = "Перше завдання" };
repository.Add(task1);
Console.WriteLine("✓ Додано завдання 1");

// 3. Тестуємо Add() ще раз
var task2 = new TaskItem { Id = 2, Name = "Друге завдання" };
repository.Add(task2);
Console.WriteLine("✓ Додано завдання 2");
// get all
var allTasks = repository.GetAll();
Console.WriteLine($"\nВсього завдань: {allTasks.Count}");
foreach (var task in allTasks)
{
    Console.WriteLine($"- {task.Id}: {task.Name}");
}
// 5. Тестуємо GetById()
var foundTask = repository.GetByID(1);
Console.WriteLine($"\nЗнайдено за ID=1: {foundTask?.Name}");
// 6. Тестуємо Update()
task1.Name = "Оновлена назва";
repository.Update(task1);
Console.WriteLine($"\nОновлено завдання 1");
// 7. Перевіряємо оновлення
var updatedTask = repository.GetByID(1);
Console.WriteLine($"Нова назва: {updatedTask?.Name}");

// 8. Тестуємо Delete()
repository.Remove(2);
Console.WriteLine($"\nВидалено завдання 2");

// 9. Фінальна перевірка
var finalTasks = repository.GetAll();
Console.WriteLine($"\nЗалишилось завдань: {finalTasks.Count}");
}
*/
/* Тестування TaskSerivce

Console.WriteLine("=== Testing TaskService ===");

var fakeRepo = new FakeTaskRepository();
var fakeId = new FakeIdGenerator();

var service = new TaskService(fakeRepo, fakeId);
// Create
service.CreateTask("Test Task", "Desciption about title2");
var tasks = fakeRepo.GetAll();
if (tasks.Count == 1 && tasks[0].Name == "Test Task")
{
    Console.WriteLine("CreateTask працює правильно");
}
else
{
    Console.WriteLine("CreateTask не працює");
}
// Get by id
var tasksg = service.GetTaskById(1);
if (tasksg.Id == 1)
{
    Console.WriteLine("GetTaskById працює");
}
else
{
    Console.WriteLine("GetTaskById не працює");
}
// Update task 
var taskUp = service.GetTaskById(1);
Console.WriteLine($"До оновлення: {taskUp.Name} - {taskUp.Description} - {taskUp.Status}");
var updatedTask1 = new TaskItem
{
    Id = 1,
    Name = "Update title",
    Description = "Update Description",
    Status = TaskItemStatus.InProgress
};
service.UpdateTask(updatedTask1);
var result = service.GetTaskById(1);
if (result.Name == "Update title" && result.Description == "Update Description" && result.Status == TaskItemStatus.InProgress)
    Console.WriteLine("UpdateTask OK");
else
    Console.WriteLine("UpdateTask FAIL");


var status = service.CheckItemStatus(1);
if (status == TaskItemStatus.InProgress)
    Console.WriteLine("CheckItemStatus OK");
else
    Console.WriteLine("CheckItemStatus FAIL");
// get all 
service.GetAllTasks();
// delete task
service.DeleteTask(1);
if (fakeRepo.GetAll().Count == 0)
{
    Console.WriteLine("DeleteTask працює");
}
else
{
    Console.WriteLine("DeleteTask не працює");
}
}
public class FakeTaskRepository : ITaskRepository
{
private readonly List<TaskItem> _tasks = new();

public void Add(TaskItem task)
{
    _tasks.Add(task);
}

public List<TaskItem> GetAll()
{
    return _tasks;
}

public TaskItem? GetById(int id)
{
    return _tasks.FirstOrDefault(t => t.Id == id);
}

public void Update(TaskItem task) { }

public void Remove(int id)
{
    var task = GetById(id);
    if (task != null)
        _tasks.Remove(task);
}
}
public class FakeIdGenerator : IIdGenerator
{
private int _id = 0;

public int GenerateId()
{
    _id++;
    return _id;
}
}
 */

