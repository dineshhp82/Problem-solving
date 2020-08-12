using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving
{
    /*Maximum length prefix such that frequency of 
      each character is atmost number of characters with minimum frequency
      Input: S = ‘aaabc’
      Output: aa
      Explanation:
      Frequency of characters in the given string –
      {a: 3, b: 1, c: 1}
      Minimum frequency in 1 and the count of minimum frequency is 2,
      So frequency of each character in the prefix can be at most 2.     
     */
    public class MinFrequencyAndCountOfFrequency
    {
        public static void SolveProblem(string input)
        {
            var dic = new Dictionary<char, int>();

            foreach (var c in input)
            {

                if (dic.ContainsKey(c))
                {
                    dic[c] += 1;
                }
                else
                {
                    dic.Add(c, 1);
                }
            }

            int min = 100; int frequency = 1;string str = "";
            foreach (var item in dic)
            {
                if (item.Value == min)
                {
                    frequency++;
                    str += item.Key;
                }
                if (item.Value < min)
                {
                    min = item.Value;
                }   
            }

            Console.WriteLine(min);
            Console.WriteLine(frequency);
            Console.WriteLine(str);
        }
    }
}
