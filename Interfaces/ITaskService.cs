using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Task_Manager_GPT.Models;

namespace Task_Manager_GPT.Interfaces
{
    public interface ITaskService
    {
        void CreateTask(string name, string desciption);
        List<TaskItem> GetAllTasks();
        TaskItem? GetTaskById (int Id);
        void UpdateTask(int updatedTaskId, string updatedTaskName, string updatedTaskDescription, TaskItemStatus updatedTaskStatus);
        TaskItemStatus CheckItemStatus(int Id);
        void DeleteTask(int Id);
        void GetId();
    }
}
