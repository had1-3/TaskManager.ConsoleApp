using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task_Manager_GPT.Interfaces;
using Task_Manager_GPT.Models;

namespace Task_Manager_GPT.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly List<TaskItem> _tasks = new List<TaskItem>();
        public void Add(TaskItem task)
        {
            _tasks.Add(task);
        }
        public void Update(TaskItem updatedTask)
        {
            var selectedTask = _tasks.Find(taskItem => taskItem.ID == updatedTask.ID);
            if (selectedTask != null)
            {
                selectedTask.Name = updatedTask.Name;
                selectedTask.Description = updatedTask.Description;
                selectedTask.Status = updatedTask.Status;
            }
        }
        public TaskItem GetByID(int ID)
        {
            var task = _tasks.Find(taskItem => taskItem.ID == ID);
            if (task == null)
            {
                throw new KeyNotFoundException($"Task with ID {ID} not found");
            }
            return task;
        }
        public List<TaskItem> GetAll()
        {
            return _tasks;
        }
        public void Remove(int ID)
        {
            var removeTask = GetByID(ID);
            if (removeTask != null)
            {
                _tasks.Remove(removeTask);
            }
            else
            {
                Console.WriteLine($"Not found task with {ID} ID");
            }
        }

    }
}

