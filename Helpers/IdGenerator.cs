using System;
using System.Collections.Generic;
using System.Text;
using Task_Manager_GPT.Interfaces;
using Task_Manager_GPT.Models;

namespace Task_Manager_GPT.Helpers
{
    public class IdGenerator : IIdGenerator
    {
        private int _currentId = 0;
        public int GenerateId()
        {
            _currentId++;
            return _currentId;
        }
    }
}
