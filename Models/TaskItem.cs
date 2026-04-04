using System;
using System.Collections.Generic;
using System.Text;

namespace Task_Manager_GPT.Models
{
    public class TaskItem // Full finished
    {
        public string? Title { get; set; }
        public int Id { get; set; }
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
