using System;
using System.Collections.Generic;
using System.Text;
using Task_Manager_GPT.Models;

namespace Task_Manager_GPT.Helpers
{
    internal class IdGenerator
    {
        private TaskItem _taskItem = new TaskItem();
        private void GenerateId()
        {
            _taskItem.ID = new Random().Next(1, 10001);
        }
        public int GetId()
        {
            GenerateId();
            return _taskItem.ID;
        }
    }
}
