using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Task_Manager_GPT.Models;
using Task_Manager_GPT.Repositories;

// Тестування TASKREPOSITORY

//namespace Task_Manager_GPT;
//internal class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("=== Тестування TaskRepository ===");

//        // 1. Створюємо репозиторій
//        var repository = new TaskRepository();

//        // 2. Тестуємо Add()
//        var task1 = new TaskItem { ID = 1, Name = "Перше завдання"};
//        repository.Add(task1);
//        Console.WriteLine("✓ Додано завдання 1");

//        // 3. Тестуємо Add() ще раз
//        var task2 = new TaskItem { ID = 2, Name = "Друге завдання"};
//        repository.Add(task2);
//        Console.WriteLine("✓ Додано завдання 2");
//        // get all
//        var allTasks = repository.GetAll();
//        Console.WriteLine($"\nВсього завдань: {allTasks.Count}");
//        foreach(var task in allTasks)
//        {
//            Console.WriteLine($"- {task.ID}: {task.Name}");
//        }
//        // 5. Тестуємо GetById()
//        var foundTask = repository.GetByID(1);
//        Console.WriteLine($"\nЗнайдено за ID=1: {foundTask?.Name}");
//        // 6. Тестуємо Update()
//        task1.Name = "Оновлена назва";
//        repository.Update(task1);
//        Console.WriteLine($"\nОновлено завдання 1");
//        // 7. Перевіряємо оновлення
//        var updatedTask = repository.GetByID(1);
//        Console.WriteLine($"Нова назва: {updatedTask.Name}");

//        // 8. Тестуємо Delete()
//        repository.Remove(2);
//        Console.WriteLine($"\nВидалено завдання 2");

//        // 9. Фінальна перевірка
//        var finalTasks = repository.GetAll();
//        Console.WriteLine($"\nЗалишилось завдань: {finalTasks.Count}");
//    }
//}
