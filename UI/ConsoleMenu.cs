using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Task_Manager_GPT.UI
{
    public class ConsoleMenu
    {
        private readonly ConsoleInputHandler _inputHandler;
        private readonly Dictionary<string, Action> _consoleMenuAction;
        public ConsoleMenu(ConsoleInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
            _consoleMenuAction = new Dictionary<string, Action>
            {
                ["1"] = _inputHandler.HandlerCreateTask,
                ["2"] = _inputHandler.HandlerGetAllTasks,
                ["3"] = _inputHandler.HandlerGetTaskById,
                ["4"] = _inputHandler.HandlerUpdateTask,
                ["5"] = _inputHandler.HandlerDeleteTask,
            };
        }

        public void WorkProcess()
        {
            while (true)
            {
                ShowMenu();
                string? choice = Console.ReadLine();

                if (choice == "B")
                {
                    Console.Clear();
                    Console.WriteLine("Press any key to continue...");
                    break;
                }
                if (choice != null && _consoleMenuAction.TryGetValue(choice, out Action action))
                {
                    action();
                }
                else
                {
                    Console.WriteLine("Invalid option");
                }
            }
        }
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("" +
                "╔════════════════════════════════════════════════════════════╗\n" +
                "║                     TASK MANAGER v1.0                      ║\n" +
                "╠════════════════════════════════════════════════════════════╣\n" +
                "║                                                            ║\n" +
                "║  1.  Create task                                           ║\n" +
                "║  2.  Show all task                                         ║\n" +
                "║  3.  Find task by ID                                       ║\n" +
                "║  4.  Edit task                                             ║\n" +
                "║  5.  Delete task                                           ║\n" +
                "║                                                            ║\n" +
                "║  B.  Exit of program                                       ║\n" +
                "╠════════════════════════════════════════════════════════════╣\n" +
                "║  Choose option [B-6]:                                      ║\n" +
                "╚════════════════════════════════════════════════════════════╝\n");
            Console.SetCursorPosition(24, 12);
        }
        
    }
}