using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Task_Manager.Interfaces;
using Task_Manager.Models;
using Task_Manager.Services;

namespace Task_Manager.UI
{
    public class ConsoleInputHandler
    {
        private readonly ITaskService _taskService;
        private readonly ConsoleMenu _consoleMenu;
        private readonly DateTime _startTime;

        private readonly Dictionary<string, Action> _actionHandler;
        private readonly Dictionary<string, TaskItemStatus> _status;

        public ConsoleInputHandler(ITaskService taskService, ConsoleMenu consoleMenu)
        {
            _taskService = taskService;
            _consoleMenu = consoleMenu;

            _actionHandler = new Dictionary<string, Action>
            {
                ["1"] = HandlerCreateTask,
                ["2"] = HandlerGetAllTasks,
                ["3"] = HandlerGetTaskById,
                ["4"] = HandlerUpdateTask,
                ["5"] = HandlerDeleteTask,
            };

            _status = new Dictionary<string, TaskItemStatus>
            {
                ["1"] = TaskItemStatus.New,
                ["2"] = TaskItemStatus.InProgress,
                ["3"] = TaskItemStatus.Completed,
                ["4"] = TaskItemStatus.Canceled,

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
                    int countTask = _taskService.GetTaskCount();

                    _consoleMenu.DrawExitProgram(countTask, workTime);
                    break;
                }
                if (choice != null && _actionHandler.TryGetValue(choice, out Action? action))
                {
                    action?.Invoke();
                }
                else
                {
                    _consoleMenu.ShowError("Invalid input");
                }
            }
        } // Main method
        public string ReadInput(int x, int y) // Reader
        {
            Console.SetCursorPosition(x, y);
            return Console.ReadLine() ?? "";
        }

        public void HandlerCreateTask()
        {
            while (true)
            {
                Console.Clear();

                _consoleMenu.DrawCreateTitle();
                string? inputTitle = ReadInput(19, 5);
                if ( inputTitle == "" || inputTitle == " ")
                {
                    inputTitle = "Title";
                }

                _consoleMenu.DrawCreateDescription();
                string? inputDescription = ReadInput(25, 9);

                _taskService.CreateTask(inputTitle, inputDescription);

                int currentId = _taskService.GetTaskId();

                _consoleMenu.DrawCompleteCreate(currentId);

                string? choice = Console.ReadLine()?.ToUpper();

                if (choice == "B")
                {
                    Console.Clear();
                    break;
                }
                _consoleMenu.ShowError("Invalid input");
                break;
            }
        } // Full finished
        public void HandlerGetAllTasks()
        {
            while (true)
            {
                Console.Clear();

                var allTasks = _taskService.GetAllTasks();
                if (!allTasks.Any())
                {
                    _consoleMenu.DrawGetAllNotTask("User doesn't have tasks");
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
                        _consoleMenu.ShowError("Invalid input");
                        break;
                }
                break;
            }
        } // Full finished
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
                        var taskById = _taskService.GetTaskById(id);

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
                                _consoleMenu.ShowError("Invalid input");
                                break;
                        }
                        break;
                    }
                    catch (KeyNotFoundException)
                    {
                        _consoleMenu.ShowNotTaskFound("User doesn't have task");
                        break;
                    }
                }
                else
                {
                    _consoleMenu.ShowError("Invalid input");
                    break;
                }
            }
        } // Full finished
        public void HandlerUpdateTask()
        {
            while (true)
            {
                string? newTitle;
                string? newDescription;
                TaskItemStatus currentStatus;

                Console.Clear();

                _consoleMenu.DrawMenuUpdate();

                string? input = Console.ReadLine();
                if (int.TryParse(input, out int id))
                {
                    try
                    {
                        var updateTaskId = _taskService.GetTaskById(id);
                        _consoleMenu.DrawCurrentInformation(updateTaskId!);

                        string? choice = Console.ReadLine()?.ToUpper() ?? "";
                        if (choice == "B")
                        {
                            Console.Clear();
                            break;
                        }
                        switch (choice)
                        {
                            case "1":
                                Console.Clear();

                                _consoleMenu.DrawChangeTitle();

                                newTitle = ReadInput(26, 5);

                                _taskService.UpdateTaskTitle(id, newTitle);
                                _consoleMenu.DrawUpdateComplited();
                                choice = Console.ReadLine()?.ToUpper() ?? "";
                                if (choice == "B")
                                {
                                    Console.Clear();
                                    break;
                                }
                                else
                                    _consoleMenu.ShowError("Invalid input");
                                break; // Update title finished
                            case "2":
                                Console.Clear();

                                _consoleMenu.DrawChangeDescription();

                                newDescription = ReadInput(32, 5);

                                _taskService.UpdateTaskDescription(id, newDescription);
                                _consoleMenu.DrawUpdateComplited();
                                choice = Console.ReadLine()?.ToUpper() ?? "";
                                if (choice == "B")
                                {
                                    Console.Clear();
                                    break;
                                }
                                else
                                    _consoleMenu.ShowError("Invalid input");
                                break; // Update description finished
                            case "3":
                                Console.Clear();

                                currentStatus = _taskService.GetTaskStatus(id);

                                _consoleMenu.DrawChangeStatus(currentStatus);

                                choice = Console.ReadLine()?.ToUpper() ?? "";
                                if (choice == "B")
                                {
                                    Console.Clear();
                                    break;
                                }
                                if (_status.TryGetValue(choice, out TaskItemStatus newStatus))
                                {
                                    _taskService.UpdateTaskStatus(id, newStatus);
                                    _consoleMenu.DrawUpdateComplited();
                                    choice = Console.ReadLine()?.ToUpper() ?? "";
                                    if (choice == "B")
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                }
                                else
                                {
                                    _consoleMenu.ShowError("Invalid task");
                                }
                                break; // Update status finished
                            default:
                                _consoleMenu.ShowError("Invalid input");
                                break;
                        }
                        break;
                    }
                    catch (KeyNotFoundException)
                    {
                        _consoleMenu.ShowNotTaskFound("User doesn't have task");
                        break;
                    }
                }
                else
                {
                    _consoleMenu.ShowError("Invalid input");
                    break;
                }
            }
        } // Full finished
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
                        var deletedTask = _taskService.GetTaskById(id);
                        _consoleMenu.DrawDeletionProcess(deletedTask!);

                        string? choice = Console.ReadLine()?.ToUpper() ?? "";
                        switch (choice)
                        {
                            case "Y":
                                _taskService.DeleteTask(id);
                                _consoleMenu.DrawDeleteComplited();

                                choice = Console.ReadLine()?.ToUpper() ?? "";
                                if (choice == "B")
                                {
                                    Console.Clear();
                                    break;
                                }
                                else
                                    _consoleMenu.ShowError("Invalid input");
                                break;
                            case "N":
                                _consoleMenu.DrawDeleteCancelled();

                                choice = Console.ReadLine()?.ToUpper() ?? "";
                                if (choice == "B")
                                {
                                    Console.Clear();
                                    break;
                                }
                                else
                                    _consoleMenu.ShowError("Invalid input");
                                break;
                            default:
                                _consoleMenu.ShowError("Invalid input");
                                break;
                        }
                        break;
                    }

                    catch (KeyNotFoundException)
                    {
                        _consoleMenu.ShowNotTaskFound("User doesn't have task");
                        break;
                    }
                }
                else
                {
                    _consoleMenu.ShowError("Invalid input");
                    break;
                }
            }
        } // Full finished
    }
}
