using System;
using System.Collections.Generic;
using System.Text;

namespace TaskWorking.Service
{
    internal class TryCatchIntConverter
    {
        public static int ConvertStringToInt(string value)
        {
            try
            {
                return int.Parse(value);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("O que você escrevou está fora do padrão exigido.");
                Console.ResetColor();
                return -1;
            }
            catch (OverflowException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("O número foi muito alto ou muito baixo.");
                Console.ResetColor();
                return -1;
            }
            catch (ArgumentNullException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Você deu um input nulo.");
                Console.ResetColor();
                return -1;
            }
            
        }
    }
}
