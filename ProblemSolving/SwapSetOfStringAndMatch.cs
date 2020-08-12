using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving
{
    /*Given two strings A and B of lowercase letters, return true if and only if we can swap two letters in A so that the result equals B.
     * A = "aaaaaaabc", B = "aaaaaaacb" True
     * A = "aa", B = "aa" True
     * A = "ab", B = "ab" False
     * A = "ab", B = "ba" True
     
         */
    public class SwapSetOfStringAndMatch
    {
        public static bool SolveProblem(string a, string b)
        {
            //a length = b length and to create sub set need 2 item this 
            if (a.Length != b.Length || a.Length % 2 != 0)
            {
                return false;
            }

            bool IsTrue = false;

            string subString = string.Empty;

            for (int i = a.Length - 1; i >= 0; i--)
            {
                subString += a[i];
                if (i % 2 == 0)
                {
                    if (subString == b.Substring(i, 2))
                    {
                        IsTrue = true;
                        subString = string.Empty;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return IsTrue;

        }
    }
}
