using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving
{
    public class FindLargestSubsequence
    {
        /*  abc => {a,b,c,ab,ac,abc}
         
            [0,1],[1,1],[2,1]
            [0,2],[1,2]
            [0,3]
            

             */
        public static int CountLargestSubSequence(string input)
        {
            List<string> storeSubsequences = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length - i; j++)
                {
                    string substring = input.Substring(j, i + 1);
                    if (!storeSubsequences.Contains(substring))
                    {
                        storeSubsequences.Add(substring);
                    }
                }
            }

            foreach (var item in storeSubsequences)
            {
                Console.WriteLine(item);
            }

            return -1;
        }
    }
}
