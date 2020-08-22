using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving.Utilties
{
    public static class ConsoleExtension
    {
        public static void PrintArray(this int[] values, string message = "", ConsoleColor consoleColor = ConsoleColor.White)
        {
            string str = $"{message} Array [";
            for (int i = 0; i < values.Length; i++)
            {
                str += $"{values[i]} ,";
            }
            str = str.Trim(',') + "]";

            Console.ForegroundColor = consoleColor;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintArray(
            this int[] values,
            int startIndex = 0,
            int endIndex = -1,
            string message = "",
            ConsoleColor consoleColor = ConsoleColor.White)
        {
            if (endIndex == -1)
            {
                endIndex = values.Length;
            }
            string str = $"{message} Array [";
            for (int i = startIndex; i < endIndex + 1; i++)
            {
                str += $"{values[i]} ,";
            }
            str = str.Trim(',') + "]";
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
