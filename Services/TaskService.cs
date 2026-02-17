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
        private readonly IdGenerator _idGenerator;
        public TaskService(ITaskRepository repository, IdGenerator idGenerator)
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
        public void UpdateTask(TaskItem updatedTask, int Id)
        {
            if (updatedTask != null)
            {
                var existingTask = _repository.GetById(Id);
                if (existingTask == null)
                {
                    throw new KeyNotFoundException($"Task with ID {Id} not found");
                }
                existingTask.Name = updatedTask.Name;
                existingTask.Description = updatedTask.Description;
                existingTask.Status = updatedTask.Status;

                _repository.Update(updatedTask);
            }
        }
        public void CheckItemTask(int Id)
        {
            var taskStatus = _repository.CheckItemStatus(Id);
            switch (taskStatus)
            {
                case TaskItemStatus.New:
                    throw new Exception("New task");

                case TaskItemStatus.Completed:
                    throw new Exception("Task has been completed");

                case TaskItemStatus.InProgress:
                    throw new Exception("Task in progress");

                case TaskItemStatus.Cancelled:
                    throw new Exception("Task has been cancelled");
            }
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
