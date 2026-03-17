using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Task_Manager_GPT.Interfaces;
using Task_Manager_GPT.Models;

namespace Task_Manager_GPT.UI
{
    public class ConsoleInputHandler
    {
        private readonly ITaskService _taskServiceInput;
        public ConsoleInputHandler(ITaskService taskServiceInput)
        {
            _taskServiceInput = taskServiceInput;
        }
    }
}
