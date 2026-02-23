using System;
using System.Collections.Generic;
using System.Text;

namespace CMTask.View
{
    internal static class UICage
    {
        /// <summary>
        /// Height: 15
        /// Width: 119
        /// </summary>
        public static void Create()
        {
            // if you want to modificate the cage proportions, just change these variables:  
            int height = 15;
            int width = 119;

            Console.SetCursorPosition(0, 0);
            Console.Write("x----------------------------------------------------------------------------------------------------------------------x");

            for (int i = 1; i <= height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
                Console.SetCursorPosition(width, i);
                Console.Write("|");
                if (i == height)
                {
                    Console.SetCursorPosition(0, i + 1);
                    Console.Write("x----------------------------------------------------------------------------------------------------------------------x");
                }
            }
        }
    }
}
