using System;
using System.Collections.Generic;
using System.Text;
using Task_Manager.Interfaces;
using Task_Manager.Models;

namespace Task_Manager.Helpers
{
    public class IdGenerator : IIdGenerator // Full finished
    {
        private int _currentId = 0;
        public int GenerateId()
        {
            _currentId++;
            return _currentId;
        }
        public int GetId()
        {
            return _currentId;
        }
    }
}
