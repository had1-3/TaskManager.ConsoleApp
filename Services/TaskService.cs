using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task_Manager_GPT.Helpers;
using Task_Manager_GPT.Interfaces;
using Task_Manager_GPT.Models;

namespace Task_Manager_GPT.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        private readonly IIdGenerator _idGenerator;
        public TaskService(ITaskRepository repository, IIdGenerator idGenerator)
        {
            _repository = repository;
            _idGenerator = idGenerator;
        }
        public void CreateTask(string name, string desciption)
        {
            if (name == null)
            {
                throw new KeyNotFoundException("A task must have name!");
            }
            var task = new TaskItem
            {
                Name = name,
                Id = _idGenerator.GenerateId(),
                Description = desciption,
            };
            _repository.Add(task);
        }
        public void GetAllTasks()
        {
            var tasks = _repository.GetAll();
            foreach (var task in tasks)
            {
                Console.WriteLine($"Name: {task.Name}; - ID: {task.Id}; - Status: {task.Status} ");
            }
        }
        public TaskItem GetTaskById(int Id)
        {
            var taskId = _repository.GetById(Id);
            if (taskId == null)
            {
                throw new KeyNotFoundException($"Task with ID {Id} not found");
            }
            return taskId;
        }
        public void UpdateTask(TaskItem updatedTask)
        {
            if (updatedTask == null)
            {
                throw new ArgumentNullException(nameof(updatedTask), "Task cannot be null");
            }
            var existingTask = _repository.GetById(updatedTask.Id);
            if (existingTask == null)
            {
                throw new KeyNotFoundException($"Task with ID {updatedTask.Id} not found");
            }
            existingTask.Name = updatedTask.Name;
            existingTask.Description = updatedTask.Description;
            existingTask.Status = updatedTask.Status;

            _repository.Update(existingTask);
        }
        public TaskItemStatus CheckItemStatus(int Id)
        {
            var taskStatus = _repository.GetById(Id);
            if (taskStatus == null)
            {
                throw new KeyNotFoundException($"Task with ID {Id} not found");
            }
            return taskStatus.Status;
        }
        public void DeleteTask(int Id)
        {
            var removeTask = _repository.GetById(Id);
            if (removeTask == null)
            {
                throw new KeyNotFoundException($"Task with ID {Id} not found");
            }
            _repository.Remove(Id);
        }
    }
}
