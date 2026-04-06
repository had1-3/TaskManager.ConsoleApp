using System;
using System.Collections.Generic;
using System.Text;
using Task_Manager.Models;

namespace Task_Manager.Interfaces
{
    public interface ITaskRepository // Full finished
    {
        void Add(TaskItem task);
        void Update(TaskItem task);
        List<TaskItem> GetAll();
        TaskItem? GetById(int Id);
        void Remove(int Id);
    };
}
