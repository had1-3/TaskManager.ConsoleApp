using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
        public void CreateTask(string title, string description)
        {
            if (title == null)
            {
                throw new KeyNotFoundException("A task must have name!");
            }
            if (description == null)
            {
                description = "Empty desciption";
            }
            var task = new TaskItem
            {
                Title = title,
                Id = _idGenerator.GenerateId(),
                Description = description,
            };
            _repository.Add(task);
        }
        public List<TaskItem> GetAllTasks()
        {
            return _repository.GetAll();
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
        public void UpdateTask(int updatedTaskId, string updatedTaskTitle, string updatedTaskDescription, TaskItemStatus updatedTaskStatus)
        {
            if (updatedTaskTitle == null)
            {
                throw new ArgumentNullException(nameof(updatedTaskTitle), "Task cannot be null");
            }
            var existingTask = _repository.GetById(updatedTaskId);
            if (existingTask == null)
            {
                throw new KeyNotFoundException($"Task with ID {updatedTaskId} not found");
            }
            existingTask.Title = updatedTaskTitle;
            existingTask.Description = updatedTaskDescription;
            existingTask.Status = updatedTaskStatus;

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
        public int ServiceGetId()
        {
            return _idGenerator.GetId();
        }
        public int GetTaskCount()
        {
            return _repository.GetAll().Count;
        }
    }
}
