using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving
{
    public class FindMinMaxInArray
    {
        public static void MinMaxInArray(int[] arr)
        {
            //10,5,6,8,2,11
            int max = arr[0];
            int min = arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }

                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }

            Console.WriteLine($"Max: {max} Min: {min}");
        }
    }
}
