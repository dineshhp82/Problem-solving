using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProblemSolving.StringManipulate
{
    public class PrintDuplicateAndCount
    {
        public static void CountDuplicateSimple(string input)
        {
            input = input.ToLower();
            Dictionary<char, int> store = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];
                if (current == ' ')
                {
                    continue;
                }

                if (store.ContainsKey(current))
                {
                    store[current] += 1;
                }
                else
                {
                    store.Add(current, 1);
                }
            }

            foreach (var item in store)
            {
                Console.WriteLine("Char :" + item.Key + "  Occurance :" + item.Value);
            }
        }

        public static void CountDuplicateFast(string input)
        {
            input = input.ToLower();

            int[] freq = new int[26];

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    continue;
                }

                freq[input[i] - 'a']++;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    continue;
                }
                if (freq[input[i] - 'a'] != 0)
                {
                    Console.WriteLine("Char :" + input[i] + "  Occurance :" + freq[input[i] - 'a']);
                    freq[input[i] - 'a'] = 0;
                }
            }

        }
    }
}
