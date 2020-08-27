using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving.StringManipulate
{
    public class SuperReducedString
    {
        public static void ReducedString(string input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                //this is use when we need to compare next and previous start
                //loop from 1 and then i-1
                Console.WriteLine($"{input[i]} : {input[i - 1]} ");
                if (input[i] == input[i - 1])
                {

                    input = input.Substring(0, i - 1) + input.Substring(i + 1);
                    Console.WriteLine($"value is matched to adjacent");
                    i = 0;
                }
                else
                {
                    Console.WriteLine($"value is matched to non-adjacent");
                }
            }
            if (input.Length > 0)
            {
                Console.WriteLine(input);
            }
            else
            {
                Console.WriteLine("Empty String");
            }
        }
    }
}
