using System;
using System.Collections.Generic;
using System.Text;

namespace CMTask.UI
{
    internal class UIWritter
    {
        public void WriteOn(string text, int x, int y, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static string _space; 
        static UIWritter()
        {
            StringBuilder sb = new StringBuilder();
            int width = Console.WindowWidth;
            
            for (int i = 0; i < width; i++)
                sb.Append(" ");
            _space = sb.ToString();
        }
        public void Clear()
        {
            for (int i = 0; i <= 15; i++)
                WriteOn(_space, 10, i, ConsoleColor.White);
            WriteOn(_space,10, 2, ConsoleColor.White);
            WriteOn(_space, 10, 3, ConsoleColor.White);
        }
    }
}
