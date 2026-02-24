using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task_Manager_GPT.Interfaces;
using Task_Manager_GPT.Models;

namespace Task_Manager_GPT.UI
{
    public class ConsoleInputHandle
    {
        private readonly ITaskService _taskServiceInput;
        public ConsoleInputHandle(ITaskService taskServiceInput)
        {
            _taskServiceInput = taskServiceInput;
        }
        private readonly Dictionary<int, TaskItemStatus> _status = new()
        {
            [1] = TaskItemStatus.New,
            [2] = TaskItemStatus.InProgress,
            [3] = TaskItemStatus.Completed,
            [4] = TaskItemStatus.Cancelled,
        };

        public void HandlerCreateTask()
        {
            Console.Write("Input name for task: ");
            string? InputName = Console.ReadLine()!;

            Console.Write("Input desciption for task: ");
            string? InputDesciption = Console.ReadLine()!;

            _taskServiceInput.CreateTask(InputName, InputDesciption);
            Console.WriteLine("Your task created!");
        }
        public void HandlerGetAllTasks()
        {

            Console.WriteLine("\nYOUR ALL TASKS:");
            Console.WriteLine("──────────────────");

            var allTasks = _taskServiceInput.GetAllTasks();
            if (!allTasks.Any())
            {
                Console.WriteLine("No tasks found.");
                return;
            }
            foreach (var task in allTasks)
            {
                Console.WriteLine($"Name: {task.Name}; - ID: {task.Id}; - Status: {task.Status}; Time - {task.CreatedDate:HH:mm} ");
                Console.WriteLine();
            }
            Console.WriteLine("──────────────────");
        }
        public void HandlerGetTaskById()
        {
            Console.WriteLine("Input ID your task: ");

            if (!int.TryParse(Console.ReadLine(), out int inputId))
            {
                Console.WriteLine("Invalid ID!\nTry again: ");
                return;
            }
            var taskById = _taskServiceInput.GetTaskById(inputId);
            if (taskById == null)
            {
                Console.WriteLine($"Task with ID {inputId} not found!");
                return;
            }

        }
        public void HandlerUpdateTask()
        {
            _taskServiceInput.GetAllTasks();

            Console.Write("Input ID your task for update: ");
            if (!int.TryParse(Console.ReadLine(), out int inputId))
            {
                Console.WriteLine("Invalid ID!");
                return;
            }

            var existingTask = _taskServiceInput.GetTaskById(inputId);
            if (existingTask == null)
            {
                Console.WriteLine($"Task with ID {inputId} not found");
                return;
            }
                Console.WriteLine($"Input name (was: {existingTask.Name}): ");
                string updatedTaskName = Console.ReadLine()!;

                Console.WriteLine($"Input description (was: {existingTask.Description}): ");
                string updatedTaskDescription = Console.ReadLine()!;

                Console.WriteLine("Select status for your task: ");
                TaskItemStatus updatedTaskstatus = HandlerSelectStatus();

                _taskServiceInput.UpdateTask(inputId, updatedTaskName, updatedTaskDescription, updatedTaskstatus);
                Console.WriteLine("Task has been updated");
        }
        public TaskItemStatus HandlerSelectStatus()
        {
            while (true)
            {
                foreach (var item in _status)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
                Console.Write("Your choice: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid ID!\nTry again: ");
                    return TaskItemStatus.New;
                }
                if (_status.TryGetValue(choice, out var status))
                {
                    return status;
                }
                Console.WriteLine("Invalid choice");
            }
        }
        public void HandlerDeleteTask()
        {
            Console.WriteLine("Input ID your task: ");
            if (!int.TryParse(Console.ReadLine(), out int inputId))
            {
                Console.WriteLine("Invalid ID!");
                return;
            }
            var deletedTask = _taskServiceInput.GetTaskById(inputId);
            if (deletedTask == null)
            {
                Console.WriteLine($"Task with ID {inputId} not found!");
                return;
            }
            _taskServiceInput.DeleteTask(inputId);
            Console.WriteLine("Your task has been deleted! ");
        }
    }
}
