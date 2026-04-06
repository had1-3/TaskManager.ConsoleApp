using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task_Manager.Helpers;
using Task_Manager.Interfaces;
using Task_Manager.Models;

namespace Task_Manager.Services
{
    public class TaskService : ITaskService // Full finished
    {
        private readonly ITaskRepository _repository;
        private readonly IIdGenerator _idGenerator;

        public TaskService(ITaskRepository repository, IIdGenerator idGenerator)
        {
            _repository = repository;
            _idGenerator = idGenerator;
        }

        // Create task
        public void CreateTask(string title, string description)
        {
            if (title == null && description == null)
            {
                throw new KeyNotFoundException($"title and description must have a value");
            }
            var task = new TaskItem
            {
                Title = title,
                Id = _idGenerator.GenerateId(),
                Description = description,
            };
            _repository.Add(task);
        }

        // Get all task
        public List<TaskItem> GetAllTasks()
        {
            return _repository.GetAll();
        }

        // Get task by id
        public TaskItem GetTaskById(int Id)
        {
            var taskId = _repository.GetById(Id);
            if (taskId == null)
            {
                throw new KeyNotFoundException($"ID not found");
            }
            return taskId;
        }

        // Update task
        public void UpdateTaskTitle(int taskId, string updatedTaskTitle)
        {
            var existingTask = _repository.GetById(taskId);
            if (existingTask == null)
            {
                throw new KeyNotFoundException($"Task not found");
            }
            existingTask.Title = updatedTaskTitle;

            _repository.Update(existingTask);
        }
        public void UpdateTaskDescription(int taskId, string updatedTaskDescription)
        {
            var existingTask = _repository.GetById(taskId);
            if (existingTask == null)
            {
                throw new KeyNotFoundException($"Task not found");
            }

            existingTask.Description = updatedTaskDescription;

            _repository.Update(existingTask);
        }
        public void UpdateTaskStatus(int taskId, TaskItemStatus updatedTaskStatus)
        {
            var existingTask = _repository.GetById(taskId);
            if (existingTask == null)
            {
                throw new KeyNotFoundException($"Task not found");
            }

            existingTask.Status = updatedTaskStatus;

            _repository.Update(existingTask);
        }

        // Delete task
        public void DeleteTask(int Id)
        {
            var existingTask = _repository.GetById(Id);
            if (existingTask == null)
            {
                throw new KeyNotFoundException($"Task not found");
            }
            _repository.Remove(Id);
        }

        // Method for get value
        public TaskItemStatus GetTaskStatus(int Id)
        {
            var taskStatus = _repository.GetById(Id);
            if (taskStatus == null)
            {
                throw new KeyNotFoundException($"Task with ID {Id} not found");
            }
            return taskStatus.Status;
        }
        public int GetTaskId()
        {
            return _idGenerator.GetId();
        }
        public int GetTaskCount()
        {
            return _repository.GetAll().Count;
        }
        public string GetTaskTitle(int currentId)
        {
            var existingTask = _repository.GetById(currentId);
            if (existingTask?.Title == null)
            {
                throw new KeyNotFoundException($"Task not found");
            }
            return existingTask.Title;
        }
        public string GetTaskDescription(int currentId)
        {
            var existingTask = _repository.GetById(currentId);
            if (existingTask?.Description == null)
            {
                throw new KeyNotFoundException($"Task not found");
            }
            return existingTask.Description;
        }
    }
}
