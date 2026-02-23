using System;
using System.Collections.Generic;
using System.Text;
using TaskWorking.Model;

namespace CMTask.Interfaces
{
    internal interface IDataSaver
    {
        void SaveData(ToDoTask dataObject);
        void SaveData(IEnumerable<ToDoTask> dataObject);
    }
}
