using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Task_Manager_GPT.Interfaces;
using Task_Manager_GPT.Models;
using Task_Manager_GPT.Services;

namespace Task_Manager_GPT.UI
{
    public class ConsoleInputHandler
    {
        private readonly ITaskService _taskServiceInput;
        private readonly ConsoleMenu _consoleMenu;
        private readonly DateTime _startTime;

        private readonly Dictionary<string, Action> _actionHandler;
        private readonly Dictionary<int, TaskItemStatus> _status;

        public ConsoleInputHandler(ITaskService taskServiceInput, ConsoleMenu consoleMenu)
        {
            _taskServiceInput = taskServiceInput;
            _consoleMenu = consoleMenu;

            _actionHandler = new Dictionary<string, Action>
            {
                ["1"] = HandlerCreateTask,
                ["2"] = HandlerGetAllTasks,
                ["3"] = HandlerGetTaskById,
                ["4"] = HandlerUpdateTask,
                ["5"] = HandlerDeleteTask,
            };

            _status = new Dictionary<int, TaskItemStatus>
            {
                [1] = TaskItemStatus.New,
                [2] = TaskItemStatus.InProgress,
                [3] = TaskItemStatus.Completed,
                [4] = TaskItemStatus.Cancelled,

            };
            _startTime = DateTime.Now;
        }


        public void WorkProcess()
        {
            while (true)
            {
                _consoleMenu.DrawShowMenu();
                string? choice = Console.ReadLine()?.ToUpper();

                if (choice == "B")
                {
                    TimeSpan workTime = DateTime.Now - _startTime;
                    int countTask = _taskServiceInput.GetTaskCount();

                    _consoleMenu.DrawExitProgram(countTask, workTime);
                    Console.SetCursorPosition(0, 15);
                    break;
                }
                if (choice != null && _actionHandler.TryGetValue(choice, out Action action))
                {
                    action();
                }
                else
                {
                    Console.WriteLine("Invalid option");
                }
            }
        } // main method

        public void HandlerCreateTask()
        {
            while (true)
            {
                Console.Clear();

                _consoleMenu.DrawCreateTitle();
                string? inputTitle = _consoleMenu.CreateReadTitle();

                _consoleMenu.DrawCreateDescription();
                string? inputDescription = _consoleMenu.CreateReadDescription();

                _taskServiceInput.CreateTask(inputTitle, inputDescription);

                int currentId = _taskServiceInput.ServiceGetId();

                _consoleMenu.DrawCompleteCreate(currentId);

                string? choice = Console.ReadLine()?.ToUpper();

                if (choice == "B")
                {
                    Console.Clear();
                    break;
                }
                _consoleMenu.ShowError("Invalid intput");
                break;
            }
        } // full finished
        public void HandlerGetAllTasks()
        {
            while (true)
            {
                Console.Clear();

                var allTasks = _taskServiceInput.GetAllTasks();
                if (!allTasks.Any())
                {
                    _consoleMenu.ShowNotTaskFound("User don't have tasks");
                    break;
                }

                _consoleMenu.DrawTasksGetAll(allTasks);

                _consoleMenu.DrawMenuGetAll();

                string? choice = Console.ReadLine()?.ToUpper();
                if (choice == "B")
                {
                    Console.Clear();
                    break;
                }
                switch (choice)
                {
                    case "1":
                        HandlerUpdateTask();
                        break;
                    case "2":
                        HandlerGetTaskById();
                        break;
                    case "3":
                        HandlerDeleteTask();
                        break;
                    default:
                        _consoleMenu.ShowError("Invalid intput");
                        break;
                }
                break;
            }
        }  // full finished
        public void HandlerGetTaskById()
        {
            while (true)
            {
                Console.Clear();

                _consoleMenu.DrawMenuGetId();

                string? input = Console.ReadLine();

                if (int.TryParse(input, out int id))
                {
                    try
                    {
                        var taskById = _taskServiceInput.GetTaskById(id);

                        _consoleMenu.DrawTaskGetId(taskById!);
                        string? choice = Console.ReadLine()?.ToUpper() ?? "";
                        if (choice == "B")
                        {
                            Console.Clear();
                            break;
                        }
                        switch (choice)
                        {
                            case "1":
                                HandlerUpdateTask();
                                break;
                            case "2":
                                HandlerDeleteTask();
                                break;
                            default:
                                _consoleMenu.ShowError("Invalid intput");
                                break;
                        }
                        break;
                    }
                    catch (KeyNotFoundException)
                    {
                        _consoleMenu.ShowNotTaskFound("User don't have tasks");
                        break;
                    }
                }
                else
                {
                    _consoleMenu.ShowError("Invalid intput");
                    break;
                }
            }
        } // full finished

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
            Console.WriteLine($"Input name (was: {existingTask.Title}): ");
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
            while (true)
            {
                Console.Clear();

                _consoleMenu.DrawMenuDeleteTask();
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int id))
                {
                    try
                    {
                        var deletedTask = _taskServiceInput.GetTaskById(id);
                        _consoleMenu.DrawDeletionProcess(deletedTask!);

                        string? choice = Console.ReadLine()?.ToUpper() ?? "";
                        switch (choice)
                        {
                            case "Y":
                                _taskServiceInput.DeleteTask(id);
                                _consoleMenu.DrawDeleteConfirmed();

                                string? choiceY = Console.ReadLine()?.ToUpper() ?? "";
                                if (choiceY == "B")
                                {
                                    Console.Clear();
                                    break;
                                }
                                else
                                    _consoleMenu.ShowError("Invalid intput");
                                break;
                            case "N":
                                _consoleMenu.DrawDeleteCancelled();

                                string? choiceN = Console.ReadLine()?.ToUpper() ?? "";
                                if (choiceN == "B")
                                {
                                    Console.Clear();
                                    break;
                                }
                                else
                                    Console.SetCursorPosition(0, 17);
                                _consoleMenu.ShowError("Invalid intput");
                                break;
                            default:
                                _consoleMenu.ShowError("Invalid intput");
                                break;
                        }
                        break;
                    }

                    catch (KeyNotFoundException)
                    {
                        _consoleMenu.ShowNotTaskFound("User don't have tasks");
                        break;
                    }
                }
                else
                {
                    _consoleMenu.ShowError("Invalid intput");
                    break;
                }
            }
        }  // full finished
    }
}
