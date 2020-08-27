using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProblemSolving.StringManipulate
{
    public class AnagramDemo
    {
        public static bool IsAnagram(string input, string anagram)
        {
            char[] inputChars = input.ToLower().ToCharArray();
            char[] anaChars = anagram.ToLower().ToCharArray();

            Array.Sort(inputChars);
            Array.Sort(anaChars);

            if (input == anagram)
            {
                return true;
            }

            if (input.Length != anagram.Length)
            {
                return false;
            }

            for (int i = 0; i < inputChars.Length; i++)
            {
                if (anaChars[i] != inputChars[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
