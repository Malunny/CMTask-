using System;
using System.Collections.Generic;
using System.Text;
using CMTask.Data;

namespace CMTask.UI
{
    internal class TaskEditorScreen(UIWritter uIWritter, ToDoTask task) : IShowable
    {
        private readonly UIWritter _uIWritter = uIWritter;
        private readonly int _id = task.Id;
        private readonly ToDoTask _task = task;

        public void Show()
        {
            _uIWritter.Clear();
            UICage.Create();

            _uIWritter.WriteOn($"Editing task with ID: {_id}", 10, 2, ConsoleColor.Green);
            _uIWritter.WriteOn("-----------------------------", 10, 3, ConsoleColor.White);
            _uIWritter.WriteOn("Write and press enter to change - Leave empty and press enter to don't change.", 10, 5, ConsoleColor.Yellow);

            _uIWritter.WriteOn("Title: ", 10, 6, ConsoleColor.White);
            string? title = Console.ReadLine() ?? "";
            if (title == "0")
                return;

            _uIWritter.WriteOn("Description: ", 10, 7, ConsoleColor.White);
            string? description = Console.ReadLine() ?? "";
            if (description == "0")
                return;

            if (title == "")
               title = _task.Title;
            else
                _task.Title = title;
            if (description == "")
               description = _task.Description;
            else
                _task.Description = description;

            var archiveEditor = new XmlDataEditor();
            
            archiveEditor.EditTask(_id, title, description);
        }
    }
}
