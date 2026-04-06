using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task_Manager.Helpers;
using Task_Manager.Repositories;
using Task_Manager.Services;
using Task_Manager.UI;

namespace Task_Manager;

internal class Program
{
    static void Main() // Full finished
    {
        var taskRepository = new TaskRepository();
        var taskIdGenerator = new IdGenerator();
        var taskService = new TaskService(taskRepository, taskIdGenerator);
        var taskConsoleMenu = new ConsoleMenu();
        var taskInputHandler = new ConsoleInputHandler(taskService, taskConsoleMenu);
        taskInputHandler.WorkProcess();
    }
}

