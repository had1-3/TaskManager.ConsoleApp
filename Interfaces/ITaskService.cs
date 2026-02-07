using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Task_Manager_GPT.Interfaces
{
    interface ITaskService
    {
        void CreateTask(string name, string desciption);
        void GetAllTasks();
        void GetTaskById();
        void UpdateTask();
        void UpdateStatusTask();
        void CheckAvabilityTask();
        void DeleteTask();
    }
}
