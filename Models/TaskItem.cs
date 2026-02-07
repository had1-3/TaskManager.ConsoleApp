using System;
using System.Collections.Generic;
using System.Text;

namespace Task_Manager_GPT.Models
{
    public class TaskItem
    {
        public string? Name { get; set; }
        public int ID { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public TaskItemStatus Status { get; set; }

        public TaskItem()
        {
            CreatedDate = DateTime.Now;
            Status = TaskItemStatus.New;
        }

    }
}
