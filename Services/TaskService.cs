using System;
using System.Collections.Generic;
using System.Text;
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
                throw new KeyNotFoundException("A task must have name!");
            var task = new TaskItem
            {
                Name = name,
                ID = _idGenerator.GetId(),
                Description = desciption,
            };
            _repository.Add(task);
        }
        public void GetAllTasks()
        {
            var tasks =  _repository.GetAll();
            foreach(var task in tasks)
            {
                Console.WriteLine($"Name: {task.Name}; - ID: {task.ID}; - Status: {task.Status} ");
            }
        }
    }
}
