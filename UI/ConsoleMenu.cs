using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Task_Manager_GPT.Models;

namespace Task_Manager_GPT.UI
{
    public class ConsoleMenu
    {
        public string CreateReadTitle()
        {
            Console.SetCursorPosition(22, 5);
            return Console.ReadLine() ?? "";
        }
        public string CreateReadDescription()
        {
            Console.SetCursorPosition(28, 9);
            return Console.ReadLine() ?? "";
        }



        // Drawing methods

        // Draw menu and exit
        public void DrawShowMenu()
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
                "║  Choose option [1-B]:                                      ║\n" +
                "╚════════════════════════════════════════════════════════════╝\n");
            Console.SetCursorPosition(24, 12);
        }
        public void DrawExitProgram(int count, TimeSpan workTime )
        {
            Console.Clear();
            Console.WriteLine("" +
               "╔════════════════════════════════════════════════════════════╗\n" +
               "║                      SUMMARY OF WORK                       ║\n" +
               "╠════════════════════════════════════════════════════════════╣\n" +
               "║  ┌───────────────────────────────────────────────────────┐ ║\n" +
              $"║  │   Tasks created: {count, -12}                         │ ║\n" +
               "║  │                                                       │ ║\n" +
              $"║  │   Time spent: {workTime.Seconds,-2} seconds                              │ ║\n" +
               "║  └───────────────────────────────────────────────────────┘ ║\n" +
               "║                                                            ║\n" +
               "║  ┌────────────────────────────────────┐                    ║\n" +
               "║  │  Thank you for your work!          │                    ║\n" +
               "║  └────────────────────────────────────┘                    ║\n" +
               "╚════════════════════════════════════════════════════════════╝\n");
        }

        // Not task and erorr option
        public void ShowNotTaskFound(string notTask)
        {
            Console.Clear();
            Console.WriteLine("" +
            "╔═══════════════════════════════════════════════════════════╗\n" +
            "║                       System message                      ║\n" +
            "╠═══════════════════════════════════════════════════════════╣\n" +
            "║                                                           ║\n" +
            "║              No task with this ID was found               ║\n" +
            "║                                                           ║\n" +
            "╠═══════════════════════════════════════════════════════════╣\n" +
            "║   ┌───────────────────────────────────────────────────┐   ║\n" +
            "║   │  Press any key, to return to the menu...          │   ║\n" +
            "║   └───────────────────────────────────────────────────┘   ║\n" +
            "╚═══════════════════════════════════════════════════════════╝");
            Console.SetCursorPosition(46, 8);
            Console.ReadKey();
        }
        public void ShowError(string error)
        {
            Console.Clear();
            Console.WriteLine("" +
                "╔═══════════════════════════════════════════════════════════╗\n" +
                "║                      System message                       ║\n" +
                "╠═══════════════════════════════════════════════════════════╣\n" +
                "║                                                           ║\n" +
                "║   ┌───────────────────────────────────────────────────┐   ║\n" +
                "║   │  ! Invalid input                                  │   ║\n" +
                "║   │                                                   │   ║\n" +
                "║   │  Please select a valid option from the menu       │   ║\n" +
                "║   └───────────────────────────────────────────────────┘   ║\n" +
                "║   ┌───────────────────────────────────────────────────┐   ║\n" +
                "║   │  Press any key to continue...                     │   ║\n" +
                "║   └───────────────────────────────────────────────────┘   ║\n" +
                "╚═══════════════════════════════════════════════════════════╝");
            Console.SetCursorPosition(35, 10);
            Console.ReadKey();
        }

        // Create
        public void DrawCreateTitle()
        {
            Console.WriteLine("" +
                "╔═══════════════════════════════════════════════════════════╗\n" +
                "║                     Creatting new task                    ║\n" +
                "╠═══════════════════════════════════════════════════════════╣\n" +
                "║                                                           ║\n" +
                "║   ┌───────────────────────────────────────────────────┐   ║\n" +
                "║   │  Title of task:                                   │   ║\n" +
                "║   └───────────────────────────────────────────────────┘   ║\n" +
                "╚═══════════════════════════════════════════════════════════╝\n");
            Console.SetCursorPosition(22, 5);
        }
        public void DrawCreateDescription()
        {
            Console.SetCursorPosition(0, 7);
            Console.WriteLine(
                "║                                                           ║\n" +
                "║   ┌───────────────────────────────────────────────────┐   ║\n" +
                "║   │  Description of task:                             │   ║\n" +
                "║   └───────────────────────────────────────────────────┘   ║\n" +
                "╚═══════════════════════════════════════════════════════════╝\n");
            Console.SetCursorPosition(28, 9);
        }
        public void DrawCompleteCreate(int ID)
        {
            Console.Clear();
            Console.WriteLine("" +
                "╔═══════════════════════════════════════════════════════════╗\n" +
                "║                      Operation status                     ║\n" +
                "╠═══════════════════════════════════════════════════════════╣\n" +
                "║                                                           ║\n" +
                "║   ┌───────────────────────────────────────────────────┐   ║\n" +
                "║   │  Status of task: New (default)                    │   ║\n" +
                "║   └───────────────────────────────────────────────────┘   ║\n" +
                "║                                                           ║\n" +
                "╠═══════════════════════════════════════════════════════════╣\n" +
                "║                                                           ║\n" +
                "║   ┌───────────────────────────────────────────────────┐   ║\n" +
               $"║   │  Task has been create successfull! ID: {ID,-7}    │   ║\n" +
                "║   └───────────────────────────────────────────────────┘   ║\n" +
                "║                                                           ║\n" +
                "╠═══════════════════════════════════════════════════════════╣\n" +
                "║                                                           ║\n" +
                "║            Press [B] to return to the menu:               ║\n" +
                "║                                                           ║\n" +
                "╚═══════════════════════════════════════════════════════════╝");

            Console.SetCursorPosition(46, 16);
        }

        // Get all
        public void DrawTasksGetAll(List<TaskItem> allTasks)
        {
            Console.WriteLine("" +
                "╔═══════════════════════════════════════════════════════════╗\n" +
                "║                         All tasks                         ║\n" +
                "╠═══════════════════════════════════════════════════════════╣\n" +
                "║                                                           ║\n" +
                "║  ID  │ Name               │ Status       │ Create time    ║\n" +
                "╠══════╪════════════════════╪══════════════╪════════════════╣");
            foreach (var task in allTasks)
            {
                Console.WriteLine(
                $"║  {task.Id,2}. │ {task.Title,-18} │ {task.Status,-12} │ {task.CreatedDate:HH:mm}          ║");
            }
        }
        public void DrawMenuGetAll()
        {
            Console.WriteLine("" +
                "╠══════╪════════════════════╪══════════════╪════════════════╣\n" +
                "║                                                           ║\n" +
                "║                      Choose Options                       ║\n" +
                "║                                                           ║\n" +
                "╠═══════════════════════════════════════════════════════════╣\n" +
                "║                                                           ║\n" +
                "║   ┌───────────────────────────────────────────────────┐   ║\n" +
                "║   │  1.  Edit task                                    │   ║\n" +
                "║   │  2.  Detail about task                            │   ║\n" +
                "║   │  3.  Delete task                                  │   ║\n" +
                "║   │                                                   │   ║\n" +
                "║   │  B.  Back to menu                                 │   ║\n" +
                "║   └───────────────────────────────────────────────────┘   ║\n" +
                "║                                                           ║\n" +
                "║   ┌───────────────────────────────────────────────────┐   ║");
            int inputLine = Console.CursorTop;
            Console.WriteLine(
                "║   │  Choose your option:                              │   ║\n" +
                "║   └───────────────────────────────────────────────────┘   ║\n" +
                "║                                                           ║\n" +
                "╚═══════════════════════════════════════════════════════════╝\n");

            Console.SetCursorPosition(27, inputLine);
        }

        // Get by ID
        public void DrawMenuGetId()
        {
            Console.WriteLine("" +
               "╔═══════════════════════════════════════════════════════════╗\n" +
               "║                      Detail about task                    ║\n" +
               "╠═══════════════════════════════════════════════════════════╣\n" +
               "║                                                           ║\n" +
               "║   ┌───────────────────────────────────────────────────┐   ║\n" +
               "║   │  Enter your task ID:                              │   ║\n" +
               "║   └───────────────────────────────────────────────────┘   ║\n" +
               "║                                                           ║\n" +
               "╚═══════════════════════════════════════════════════════════╝\n");

            Console.SetCursorPosition(27, 5);
        }
        public void DrawTaskGetId(TaskItem taskId)
        {
            Console.Clear();
            string DrawRow(string label, string value)
            {
                value = value.Length > 37 ? value[..37] : value;
                return $"║   │  {label,-13}{value,-36}│   ║";
            }

            Console.WriteLine("" +
               "╔═══════════════════════════════════════════════════════════╗\n" +
               "║                      Task information                     ║\n" +
               "╠═══════════════════════════════════════════════════════════╣\n" +
               "║                                                           ║\n" +
               "║   ┌───────────────────────────────────────────────────┐   ║");
            Console.WriteLine(DrawRow("ID: ", taskId.Id.ToString()));
            Console.WriteLine(DrawRow("Name: ", taskId.Title ?? "No name"));
            Console.WriteLine(DrawRow("Description: ", taskId.Description ?? "No Description"));
            Console.WriteLine(DrawRow("Status: ", taskId.Status.ToString()));
            Console.WriteLine(DrawRow("Create time: ", taskId.CreatedDate.ToString("HH:mm")));
            Console.WriteLine(
               "║   └───────────────────────────────────────────────────┘   ║\n" +
               "║                                                           ║\n" +
               "║                      Choose Options                       ║\n" +
               "║                                                           ║\n" +
               "╠═══════════════════════════════════════════════════════════╣\n" +
               "║                                                           ║\n" +
               "║   ┌───────────────────────────────────────────────────┐   ║\n" +
               "║   │  1.  Edit task                                    │   ║\n" +
               "║   │  2.  Delete task                                  │   ║\n" +
               "║   │                                                   │   ║\n" +
               "║   │  B.  Back to menu                                 │   ║\n" +
               "║   └───────────────────────────────────────────────────┘   ║\n" +
               "║                                                           ║\n" +
               "║   ┌───────────────────────────────────────────────────┐   ║\n" +
               "║   │  Choose your option:                              │   ║\n" +
               "║   └───────────────────────────────────────────────────┘   ║\n" +
               "║                                                           ║\n" +
               "╚═══════════════════════════════════════════════════════════╝\n");
            Console.SetCursorPosition(27, 24);
        }

        // Delete task
        public void DrawMenuDeleteTask()
        {
            Console.WriteLine("" +
                "╔═══════════════════════════════════════════════════════════╗\n" +
                "║                        Deletion task                      ║\n" +
                "╠═══════════════════════════════════════════════════════════╣\n" +
                "║                                                           ║\n" +
                "║   ┌───────────────────────────────────────────────────┐   ║\n" +
                "║   │  Enter your task ID:                              │   ║\n" +
                "║   └───────────────────────────────────────────────────┘   ║\n" +
                "║                                                           ║\n" +
                "╚═══════════════════════════════════════════════════════════╝\n");

            Console.SetCursorPosition(27, 5);
        }
        public void DrawDeletionProcess(TaskItem taskId)
        {
            Console.Clear();
            string DrawRow(string label, string value)
            {
                value = value.Length > 37 ? value[..37] : value;
                return $"║   │  {label,-13}{value,-35} │   ║";
            }
            Console.WriteLine("" +
                "╔═══════════════════════════════════════════════════════════╗\n" +
                "║                      Task information                     ║\n" +
                "╠═══════════════════════════════════════════════════════════╣\n" +
                "║                                                           ║\n" +
                "║   ┌───────────────────────────────────────────────────┐   ║");
            Console.WriteLine(DrawRow("ID: ", taskId.Id.ToString()));
            Console.WriteLine(DrawRow("Name: ", taskId.Title ?? "No name"));
            Console.WriteLine(DrawRow("Description: ", taskId.Description ?? "No Description"));
            Console.WriteLine(DrawRow("Status: ", taskId.Status.ToString()));
            Console.WriteLine(DrawRow("Create time: ", taskId.CreatedDate.ToString("HH:mm")));
            Console.WriteLine("" +
                "║   └───────────────────────────────────────────────────┘   ║\n" +
                "║                                                           ║\n" +
                "║   ┌───────────────────────────────────────────────────┐   ║\n" +
                "║   │  Do you want delet this task?                     │   ║\n" +
                "║   │     [y] Yes / [n] No:                             │   ║\n" +
                "║   └───────────────────────────────────────────────────┘   ║\n" +
                "╚═══════════════════════════════════════════════════════════╝\n");
            Console.SetCursorPosition(28, 14);
        }
        public void DrawDeleteConfirmed()
        {
            Console.Clear();
            Console.WriteLine("" +
            "╔═══════════════════════════════════════════════════════════╗\n" +
            "║                      Operation status                     ║\n" +
            "╠═══════════════════════════════════════════════════════════╣\n" +
            "║                                                           ║\n" +
            "║   ┌───────────────────────────────────────────────────┐   ║\n" +
            "║   │  Task was deleted successfully                    │   ║\n" +
            "║   └───────────────────────────────────────────────────┘   ║\n" +
            "║                                                           ║\n" +
            "╠═══════════════════════════════════════════════════════════╣\n" +
            "║                                                           ║\n" +
            "║            Press [B] to return to the menu:               ║\n" +
            "║                                                           ║\n" +
            "╚═══════════════════════════════════════════════════════════╝");
            Console.SetCursorPosition(46, 10);
        }
        public void DrawDeleteCancelled()
        {
            Console.Clear();
            Console.WriteLine("" +
            "╔═══════════════════════════════════════════════════════════╗\n" +
            "║                      Operation status                     ║\n" +
            "╠═══════════════════════════════════════════════════════════╣\n" +
            "║                                                           ║\n" +
            "║   ┌───────────────────────────────────────────────────┐   ║\n" +
            "║   │  Task wasn't deleted                              │   ║\n" +
            "║   └───────────────────────────────────────────────────┘   ║\n" +
            "║                                                           ║\n" +
            "╠═══════════════════════════════════════════════════════════╣\n" +
            "║                                                           ║\n" +
            "║            Press [B] to return to the menu:               ║\n" +
            "║                                                           ║\n" +
            "╚═══════════════════════════════════════════════════════════╝");
            Console.SetCursorPosition(46, 10);
        }
    }
}