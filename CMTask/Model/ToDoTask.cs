using System;
using System.Collections.Generic;
using System.Text;

namespace TaskWorking.Model
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Concluded { get; set; } = false;
    }
}
