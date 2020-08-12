using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving
{
    public class AnagramSortedDictionary
    {
        public static List<string> GetList()
        {
            var inputs = new string[] { "cat", "dog", "act", "god", "fish" };

            var list = new List<string>();

            for (int i = 0; i < inputs.Length; i++)
            {
                for (int j = 0; j < inputs.Length; j++)
                {
                    if (inputs[i] == inputs[j] || list.Contains(inputs[j]))
                    {
                        continue;
                    }
                    if (IsAnagram(inputs[i], inputs[j]))
                    {
                        Console.WriteLine(inputs[i]);
                        Console.WriteLine(inputs[j]);
                        list.Add(inputs[i]);
                        list.Add(inputs[j]);
                    }
                }
            }

            return list;
        }


        private static bool IsAnagram(string first, string second)
        {
            if (first == second)
            {
                return true;
            }

            if (first.Length != second.Length)
            {
                return false;
            }

            Dictionary<char, int> pool = new Dictionary<char, int>();
            foreach (char element in first.ToCharArray()) //fill the dictionary with that available chars and count them up
            {
                if (pool.ContainsKey(element))
                    pool[element]++;
                else
                    pool.Add(element, 1);
            }
            foreach (char element in second.ToCharArray()) //take them out again
            {
                if (!pool.ContainsKey(element)) //if a char isn't there at all; we're out
                    return false;
                if (--pool[element] == 0) //if a count is less than zero after decrement; we're out
                    pool.Remove(element);
            }
            return pool.Count == 0;

        }
    }
}
