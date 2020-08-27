using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving.StringManipulate
{
    public class ReverseString
    {
        public static string Reverse(string input)
        {
            int i = input.Length - 1;
            string str = string.Empty;
            while (i >= 0)
            {
                str += input[i];
                i--;
            }

            return str;
        }

        public static void ReverseByRecursion(string input)
        {
            if (input == null || input.Length <= 0)
            {
                Console.WriteLine(input);
            }
            else
            {
                Console.WriteLine(input[input.Length - 1]);
                ReverseByRecursion(input.Substring(0, input.Length - 1));
            }
        }
    }
}
