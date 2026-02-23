using System;
using System.Collections.Generic;
using System.Text;
using CMTask.Data;
using TaskWorking.Service.StringCutterExtension;

namespace CMTask.UI
{
    internal class TaskDetailsScreen(ToDoTask task, UIWritter uIWritter) : IShowable
    {
        private readonly ToDoTask _task = task;
        private readonly UIWritter _uIWritter = uIWritter;
        public void Show()
        {
            bool running = true;
            while (running)
            {
                _uIWritter.Clear();
                UICage.Create();

                string[] description = (_task.Description.Length / 100 >= 1) ?
                    _task.Description.CutIntoSmaller(100, 7).ToArray() : new string[] { _task.Description };

                _uIWritter.WriteOn($"Task ID: {_task.Id}", 10, 2, ConsoleColor.Green);
                _uIWritter.WriteOn($"Title: {_task.Title}", 10, 3, ConsoleColor.White);
                _uIWritter.WriteOn($" Concluded: ", 80, 3, ConsoleColor.White);
                _uIWritter.WriteOn($"{_task.Concluded}                  ", 92, 3, (_task.Concluded) ?
                    ConsoleColor.Green : ConsoleColor.Red);
                int i = 4;
                if (description.Length > 1)
                {
                    foreach (var line in description)
                    {
                        _uIWritter.WriteOn(line, 10, i, ConsoleColor.White);
                        i++;
                    }
                }
                else
                {
                    _uIWritter.WriteOn($"Description: {_task.Description}", 10, i, ConsoleColor.White);
                }

                _uIWritter.WriteOn("Options:", 10, ++i, ConsoleColor.Yellow);
                _uIWritter.WriteOn("'e' to edit the task - 'x' to delete the task - ", 10, ++i, ConsoleColor.Yellow);
                _uIWritter.WriteOn("'c' to mark as concluded or 'd' to mark as not concluded - '0' to return", 10, ++i, ConsoleColor.Yellow);
                Console.SetCursorPosition(10, ++i);
                running = HandleInput();
            }
        }

        private bool HandleInput()
        {
            string input = Console.ReadLine()?.Trim() ?? "";
            bool running = true;
            switch (input)
            {
                case "e":
                    var taskEditor = new TaskEditorScreen(_uIWritter, _task);
                    taskEditor.Show();
                    break;
                case "x":
                    var archiveDeleter = new XmlDataEditor();
                    archiveDeleter.RemoveTask(_task.Id);
                    running = false;
                    break;
                case "c":
                    if (!_task.Concluded)
                    {
                        new XmlDataEditor().EditTask(_task.Id, true);
                        _task.Concluded = true;
                    }
                    
                    break;
                case "d":
                    if (_task.Concluded)
                    {
                        new XmlDataEditor().EditTask(_task.Id, false);
                        _task.Concluded = false;
                    }
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    _uIWritter.WriteOn("Invalid input. Please try again. ", 10, 15, ConsoleColor.Red);
                    Console.ReadKey();
                    break;
            }
            return running;
        }
    }
}
