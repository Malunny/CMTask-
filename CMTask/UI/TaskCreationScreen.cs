using System;
using System.Collections.Generic;
using System.Text;

namespace CMTask.UI
{
    internal class TaskCreationScreen : IShowable
    {
        public void Show()
        {
            Console.Clear();

            UICage.Create();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(10, 2);
            Console.Write("- Task Creator Mode -");
            Console.SetCursorPosition(10, 3);
            Console.Write("---------------------");
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
