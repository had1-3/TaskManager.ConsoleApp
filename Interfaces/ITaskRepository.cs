using System;
using System.Collections.Generic;
using System.Text;
using Task_Manager_GPT.Models;

namespace Task_Manager_GPT.Interfaces
{
    public interface ITaskRepository
    {
        void Add(TaskItem task);
        void Update(TaskItem updatedTask);
        List<TaskItem> GetAll();
        TaskItem GetByID(int ID);
        void Remove(int ID);
    };
}
