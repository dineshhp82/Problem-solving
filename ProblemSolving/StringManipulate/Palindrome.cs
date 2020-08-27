using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProblemSolving.StringManipulate
{
    //string from reverse is same as original string
    //e.g mam mam
    //e.g civic ,radar,level,minim,refer,radar
    public class Palindrome
    {
        //simple
        public static bool IsPalindrome(string input)
        {
            return string.Join("", input.Reverse()) == input;
        }

        public static bool IsPalindromeWithFor(string input)
        {
            string str = string.Empty;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                str += input[i];
            }
            return str == input;
        }

        public static bool IsPalindromeWithFastWay(string input)
        {
            int mid = input.Length / 2;

            for (int i = 0; i < mid; i++)
            {
                if (input[i] != input[input.Length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
