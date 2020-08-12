using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving
{
    public class BubbleSort
    {
        public static void SortByBubble(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    //descending order
                    if (array[j] > array[j + 1])//Ascending order to change > sign
                    {
                        var temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
