using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving
{
    public class OccuranceOfCharacterInString
    {
        //yourstring => "HelloWorld"
        public static void SolveProblem(string yourString)
        {
            var lowerYourString = yourString.ToLower();
            var dictionaryOfCharAndOccurance = new Dictionary<char, int>();

            for (int i = 0; i < lowerYourString.Length; i++)
            {
                var key = lowerYourString[i];

                dictionaryOfCharAndOccurance[key] = dictionaryOfCharAndOccurance.TryGetValue(key, out int value)
                    ? value + 1 
                    : 1;
            }

            foreach (var item in dictionaryOfCharAndOccurance)
            {
                Console.WriteLine($"Char : {item.Key} occurance : {item.Value}");
            }
        }

        public static void SolveProblemUsingArray(string yourString)
        {
            var lowerYourString = yourString.ToLower();
            var arrayOfoccurance = new string[lowerYourString.Length];

            int[] freq = new int[26];

            //this store the frequency of each char
            for (int i = 0; i < lowerYourString.Length; i++)
            {
                freq[lowerYourString[i]-'a']++;
            }

            // traverse 'str' from left to right 
            for (int i = 0; i < lowerYourString.Length; i++)
            {

                // if frequency of character str.charAt(i) 
                // is not equal to 0 
                if (freq[lowerYourString[i] - 'a'] != 0)
                {

                    // print the character along with its 
                    // frequency 
                    Console.Write(lowerYourString[i]);
                    Console.Write(freq[lowerYourString[i] - 'a'] + " ");

                    // update frequency of str.charAt(i) to 
                    // 0 so that the same character is not 
                    // printed again 
                    freq[lowerYourString[i] - 'a'] = 0;
                }
            }

        }
    }
}
