using System;
using System.Collections.Generic;
using System.Text;
using TaskWorking.Model;

namespace CMTask.Interfaces
{
    internal interface IDataAcess
    {
        IEnumerable<ToDoTask> GetData();
    }
}
