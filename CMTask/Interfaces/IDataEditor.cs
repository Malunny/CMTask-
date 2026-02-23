using System;
using System.Collections.Generic;
using System.Text;

namespace CMTask.Interfaces
{
    internal interface IDataEditor
    {
        public void EditTask(int id, string? title = null, string? description = null);
        public void RemoveTask(int id);
    }
}
