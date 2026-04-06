using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Task_Manager.Models;

namespace Task_Manager.Interfaces
{
    public interface ITaskService // Full finished
    {
        // Create task
        void CreateTask(string title, string description);

        // Get all task
        List<TaskItem> GetAllTasks();

        // Get task by id
        TaskItem? GetTaskById (int Id);

        // Update task
        void UpdateTaskTitle(int updatedTaskId, string updatedTaskTitle);
        void UpdateTaskDescription(int updatedTaskId, string updatedTaskDescription);
        void UpdateTaskStatus(int updatedTaskId, TaskItemStatus updatedTaskStatus);

        // Delete task
        void DeleteTask(int Id);

        // Method for get value
        TaskItemStatus GetTaskStatus(int Id);
        int GetTaskId();
        int GetTaskCount();
        string GetTaskDescription(int currentId);
        string GetTaskTitle(int currentId);
    }
}
