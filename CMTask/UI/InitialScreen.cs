using CMTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using TaskWorking.Service;

namespace TaskWorking.View
{
    internal class InitialScreen : IShowable
    {
        public void Show()
        {

            // Title
            Console.SetCursorPosition(50, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Welcome to CMTASK!");
            Console.SetCursorPosition(50, 3);
            Console.Write("------------------");
            Console.ForegroundColor = ConsoleColor.White;

            // Options

            Console.SetCursorPosition(47, 5);
            Console.Write("x---------------------x");
            Console.SetCursorPosition(47, 6);
            Console.Write("1 - View Tasks");
            Console.SetCursorPosition(47, 7);
            Console.Write("0 - Close Application");
            Console.SetCursorPosition(47, 8);
            Console.Write("x---------------------x");

            // sets where the cursor will be.

            Console.SetCursorPosition(50, 9);
            Console.Write("input > ");
        }
    }
}
