using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProblemSolving
{
    /* Your task is to sort a given string. Each word in the string will contain a single number.
     * This number is the position the word should have in the result.
       Note: Numbers can be from 1 to 9. So 1 will be the first word (not 0).
       If the input string is empty, return an empty string. 
       The words in the input String will only contain valid consecutive numbers.

       Sample Input
       is2 Thi1s T4est 3an
       Sample Output
       Thi1s is2 3a T4est
     
     */
    public static class SortStringByNumber
    {
        public static void SolveProblem(string value)
        {
            string lowerValue = value.ToLower();

            var dic = new Dictionary<string, int>();

            int number = 0; int indexOfSpace = 0;

            for (int i = 0; i < lowerValue.Length; i++)
            {
                if (char.IsNumber(lowerValue[i]))
                {
                    number = lowerValue[i].ToInt();
                }
                //Break on space and end of length
                if (lowerValue[i] == ' ' || lowerValue.Length == i + 1)
                {
                    int length = lowerValue.Length == i + 1
                        ? lowerValue.Length - indexOfSpace
                        : i - indexOfSpace;

                    var subStringValue = lowerValue.Substring(indexOfSpace, length);

                    dic[subStringValue] = number;
                    number = 0;
                    indexOfSpace = i + 1;
                }
            }

            var sortedDictionary = dic.OrderBy(r => r.Value);
            foreach (var item in sortedDictionary)
            {
                Console.WriteLine(item.Key);
            }
        }

        //but this work only if number are unique in each substring if duplicate then not work
        public static void SolveInAnotherWays(string value)
        {
            var arrayOfValues = value.Split(' ');
            //As per given conditon that number is 1-9
            var reconstructArray = new string[8];

            for (int i = 0; i < arrayOfValues.Length; i++)
            {
                string subString = arrayOfValues[i];
                int number = 0;
                for (int j = 0; j < subString.Length; j++)
                {
                    if(char.IsNumber(subString[j]))
                    {
                        number = subString[j].ToInt();
                        break;
                    }
                }
                //If no number are include in substring then ignore.
                if (number > 0)
                {
                    reconstructArray[number] = subString;
                }
            }

            for (int i = 0; i < reconstructArray.Length; i++)
            {
                if (!string.IsNullOrEmpty(reconstructArray[i]))
                {
                    Console.WriteLine(reconstructArray[i]);
                }
            }
        }

        static int ToInt(this char c)
        {
            return (int)(c - '0');
        }
    }
}
