using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Task_Manager_GPT.Models;

namespace Task_Manager_GPT.Interfaces
{
    interface ITaskService
    {
        void CreateTask(string name, string desciption);
        void GetAllTasks();
        TaskItem? GetTaskById (int Id);
        void UpdateTask(TaskItem updatedTask, int Id);
        void CheckItemTask(int Id);
        void DeleteTask(int Id);
    }
}
