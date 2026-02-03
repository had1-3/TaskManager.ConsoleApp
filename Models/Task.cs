using System;
using System.Collections.Generic;
using System.Text;

namespace Task_Manager_GPT.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public TaskStatus Status { get; set; }

        public Task()
        {
            CreatedDate = DateTime.Now;
        }

    }
}
