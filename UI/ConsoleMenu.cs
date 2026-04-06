using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Task_Manager.Models;

namespace Task_Manager.UI
{
    public class ConsoleMenu // Full finished
    {
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
                "║  B.  Exit the program                                      ║\n" +
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
            Console.SetCursorPosition(0, 15);
        }

        // Draw not task and erorr option
        public void ShowNotTaskFound(string userHasNotTask)
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

        // Draw create
        public void DrawCreateTitle()
        {
            Console.WriteLine("" +
                "╔═══════════════════════════════════════════════════════════╗\n" +
                "║                     Creatting new task                    ║\n" +
                "╠═══════════════════════════════════════════════════════════╣\n" +
                "║                                                           ║\n" +
                "║   ┌───────────────────────────────────────────────────┐   ║\n" +
                "║   │  Title Task:                                      │   ║\n" +
                "║   └───────────────────────────────────────────────────┘   ║\n" +
                "╚═══════════════════════════════════════════════════════════╝\n");
        }
        public void DrawCreateDescription()
        {
            Console.SetCursorPosition(0, 7);
            Console.WriteLine(
                "║                                                           ║\n" +
                "║   ┌───────────────────────────────────────────────────┐   ║\n" +
                "║   │  Description Task:                                │   ║\n" +
                "║   └───────────────────────────────────────────────────┘   ║\n" +
                "╚═══════════════════════════════════════════════════════════╝\n");
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

        // Draw get all
        public void DrawTasksGetAll(List<TaskItem> allTasks)
        {
            Console.WriteLine("" +
                "╔═══════════════════════════════════════════════════════════╗\n" +
                "║                         All tasks                         ║\n" +
                "╠═══════════════════════════════════════════════════════════╣\n" +
                "║                                                           ║\n" +
                "║  ID  │ Title              │ Status       │ Created time   ║\n" +
                "╠══════╪════════════════════╪══════════════╪════════════════╣");
            foreach (var task in allTasks)
            {
                Console.WriteLine(
                $"║  {task.Id,2}. │ {task.Title,-18} │ {EnumHelper.GetDescription(task.Status),-12} │ {task.CreatedDate:HH:mm}          ║");
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
        public void DrawGetAllNotTask(string userHasNotTasks)
        {
            Console.Clear();
            Console.WriteLine("" +
            "╔═══════════════════════════════════════════════════════════╗\n" +
            "║                       System message                      ║\n" +
            "╠═══════════════════════════════════════════════════════════╣\n" +
            "║                                                           ║\n" +
            "║                       No tasks found                      ║\n" +
            "║                                                           ║\n" +
            "╠═══════════════════════════════════════════════════════════╣\n" +
            "║   ┌───────────────────────────────────────────────────┐   ║\n" +
            "║   │  Press any key, to return to the menu...          │   ║\n" +
            "║   └───────────────────────────────────────────────────┘   ║\n" +
            "╚═══════════════════════════════════════════════════════════╝");
            Console.SetCursorPosition(46, 8);
            Console.ReadKey();
        }


        // Draw get by ID
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
            Console.WriteLine(DrawRow("Title: ", taskId.Title ?? "Title"));
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

        // Draw update Task
        public void DrawMenuUpdate()
        {
            Console.WriteLine("" +
               "╔═══════════════════════════════════════════════════════════╗\n" +
               "║                        Update task                        ║\n" + 
               "╠═══════════════════════════════════════════════════════════╣\n" +
               "║                                                           ║\n" +
               "║   ┌───────────────────────────────────────────────────┐   ║\n" +
               "║   │  Enter your task ID:                              │   ║\n" +
               "║   └───────────────────────────────────────────────────┘   ║\n" +
               "║                                                           ║\n" +
               "╚═══════════════════════════════════════════════════════════╝\n");

            Console.SetCursorPosition(27, 5);
        }
        public void DrawCurrentInformation(TaskItem taskId)
        {
            Console.Clear();
            string DrawRow(string label, string value)
            {
                value = value.Length > 37 ? value[..37] : value;
                return $"║   │  {label,-13}{value,-36}│   ║";
            }

            Console.WriteLine("" +
               "╔═══════════════════════════════════════════════════════════╗\n" +
               "║                     Current information                   ║\n" +
               "╠═══════════════════════════════════════════════════════════╣\n" +
               "║                                                           ║\n" +
               "║   ┌───────────────────────────────────────────────────┐   ║");
            Console.WriteLine(DrawRow("ID: ", taskId.Id.ToString()));
            Console.WriteLine(DrawRow("Title: ", taskId.Title ?? "Title"));
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
               "║   │  1.  Edit title                                   │   ║\n" +
               "║   │  2.  Edit Description                             │   ║\n" +
               "║   │  3.  Edit Status                                  │   ║\n" +
               "║   │                                                   │   ║\n" +
               "║   │  B.  Back to menu                                 │   ║\n" +
               "║   └───────────────────────────────────────────────────┘   ║\n" +
               "║                                                           ║\n" +
               "║   ┌───────────────────────────────────────────────────┐   ║\n" +
               "║   │  Choose your option:                              │   ║\n" +
               "║   └───────────────────────────────────────────────────┘   ║\n" +
               "║                                                           ║\n" +
               "╚═══════════════════════════════════════════════════════════╝\n");
            Console.SetCursorPosition(27, 25);
        }
        public void DrawChangeTitle()
        {
            Console.WriteLine("" +
               "╔═══════════════════════════════════════════════════════════╗\n" +
               "║                      Update task title                    ║\n" +
               "╠═══════════════════════════════════════════════════════════╣\n" +
               "║                                                           ║\n" +
               "║   ┌───────────────────────────────────────────────────┐   ║\n" +
               "║   │  Enter a new title:                               │   ║\n" +
               "║   └───────────────────────────────────────────────────┘   ║\n" +
               "║                                                           ║\n" +
               "╚═══════════════════════════════════════════════════════════╝\n");
        }
        public void DrawChangeDescription()
        {
            Console.WriteLine("" +
               "╔═══════════════════════════════════════════════════════════╗\n" +
               "║                  Update task description                  ║\n" +
               "╠═══════════════════════════════════════════════════════════╣\n" +
               "║                                                           ║\n" +
               "║   ┌───────────────────────────────────────────────────┐   ║\n" +
               "║   │  Enter a new description:                         │   ║\n" +
               "║   └───────────────────────────────────────────────────┘   ║\n" +
               "║                                                           ║\n" +
               "╚═══════════════════════════════════════════════════════════╝\n");
        }
        public void DrawChangeStatus(TaskItemStatus status)
        {
            string DrawRow(string label, string value)
            {
                value = value.Length > 37 ? value[..37] : value;
                return $"║   │  {label}{value,-41}│   ║";
            }
            Console.WriteLine("" +
               "╔═══════════════════════════════════════════════════════════╗\n" +
               "║                      Current status                       ║\n" +
               "╠═══════════════════════════════════════════════════════════╣\n" +
               "║   ┌───────────────────────────────────────────────────┐   ║");
            Console.WriteLine(DrawRow("Status: ", status.ToString()));
            Console.WriteLine("" +
               "║   └───────────────────────────────────────────────────┘   ║\n" +
               "╠═══════════════════════════════════════════════════════════╣\n" +
               "║                      Select new status                    ║\n" +
               "╠═══════════════════════════════════════════════════════════╣\n" +
               "║                                                           ║\n" +
               "║   ┌───────────────────────────────────────────────────┐   ║\n" +
               "║   │  1.  New                                          │   ║\n" +
               "║   │  2.  In progress                                  │   ║\n" +
               "║   │  3.  Completed                                    │   ║\n" +
               "║   │  4.  Canceled                                     │   ║\n" +
               "║   │                                                   │   ║\n" +
               "║   │  B.  Back to menu                                 │   ║\n" +
               "║   └───────────────────────────────────────────────────┘   ║\n" +
               "║                                                           ║\n" +
               "║   ┌───────────────────────────────────────────────────┐   ║\n" +
               "║   │  Choose your option:                              │   ║\n" +
               "║   └───────────────────────────────────────────────────┘   ║\n" +
               "║                                                           ║\n" +
               "╚═══════════════════════════════════════════════════════════╝\n");
            Console.SetCursorPosition(27, 20);
        }
        public void DrawUpdateComplited()
        {
            Console.Clear();
            Console.WriteLine("" +
            "╔═══════════════════════════════════════════════════════════╗\n" +
            "║                      Operation status                     ║\n" +
            "╠═══════════════════════════════════════════════════════════╣\n" +
            "║                                                           ║\n" +
            "║   ┌───────────────────────────────────────────────────┐   ║\n" +
            "║   │  The task has been updated successfully !         │   ║\n" +
            "║   └───────────────────────────────────────────────────┘   ║\n" +
            "║                                                           ║\n" +
            "╠═══════════════════════════════════════════════════════════╣\n" +
            "║                                                           ║\n" +
            "║            Press [B] to return to the menu:               ║\n" +
            "║                                                           ║\n" +
            "╚═══════════════════════════════════════════════════════════╝");
            Console.SetCursorPosition(46, 10);
        }

        // Draw delete task
        public void DrawMenuDeleteTask()
        {
            Console.WriteLine("" +
                "╔═══════════════════════════════════════════════════════════╗\n" +
                "║                        Deleting task                      ║\n" +
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
                "║   │  Do you want delete this task?                    │   ║\n" +
                "║   │     [y] Yes / [n] No:                             │   ║\n" +
                "║   └───────────────────────────────────────────────────┘   ║\n" +
                "╚═══════════════════════════════════════════════════════════╝\n");
            Console.SetCursorPosition(28, 14);
        }
        public void DrawDeleteComplited()
        {
            Console.Clear();
            Console.WriteLine("" +
            "╔═══════════════════════════════════════════════════════════╗\n" +
            "║                      Operation status                     ║\n" +
            "╠═══════════════════════════════════════════════════════════╣\n" +
            "║                                                           ║\n" +
            "║   ┌───────────────────────────────────────────────────┐   ║\n" +
            "║   │  Task has been successfully deleted               │   ║\n" +
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
            "║   │  Task hasn't been deleted                         │   ║\n" +
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