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
        private readonly ITaskRepository _baseRepo;
        public TaskRepository(ITaskRepository baseRepo)
        {
            _baseRepo = baseRepo;
        }
        public void Add(TaskItem task)
        {
            _tasks.Add(task);
        }
        public List<TaskItem> GetAll()
        {
            return _tasks;
        }
        public TaskItem? GetById(int Id)
        {
            return _tasks.FirstOrDefault(taskItem => taskItem.Id == Id);
        }
        public void Update(TaskItem task)
        {
            var selectedTask = _tasks.FirstOrDefault(taskItem => taskItem.Id == task.Id);
            if (selectedTask == null)
            {
                throw new KeyNotFoundException($"Task with ID {task.Id} not found");
            }
        }
        public TaskItemStatus CheckItemStatus(int Id)
        {
            var taskStatus = _baseRepo.GetById(Id);
            if (taskStatus == null)
            {
                throw new KeyNotFoundException($"Task with ID {Id} not found");
            }
            return taskStatus.Status;
        }
        public void Remove(int Id)
        {
            var removeTask = GetById(Id);
            if (removeTask != null)
                _tasks.Remove(removeTask);
        }

    }
}
