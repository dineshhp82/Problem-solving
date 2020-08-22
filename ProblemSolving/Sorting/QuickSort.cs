using ProblemSolving.Utilties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProblemSolving.Sorting
{
    /*
     
     */
    public class QuickSort
    {
        public void QuickSortArry(int[] values, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(values, start, end);
                values.PrintArray(start, end, $"F start {start} pivot {pivot} end {end}");
                QuickSortArry(values, start, pivot - 1);
                Console.WriteLine("move to next");
                values.PrintArray(start, end, $"L start {start} pivot {pivot} end {end}");
                QuickSortArry(values, pivot + 1, end);
            }
            Console.WriteLine($"Out Block {start} - {end}");
        }

        private int Partition(int[] values, int start, int end)
        {
            int pivot = values[end];
            int i = start;
            //{ 23, 5, 2, 8, 12, 7, 16, 9 };
            values.PrintArray("partition", ConsoleColor.Green);
            for (int j = start; j <= end - 1; j++)
            {
                Console.WriteLine($"value {i} - {j} and pivot {pivot}");
                if (values[j] < pivot)
                {
                    Console.WriteLine($"value swap from {values[i]} to  {values[j]} ");
                    var temp = values[i];
                    values[i] = values[j];
                    values[j] = temp;
                    i++;
                }
            }

            values[end] = values[i];
            values[i] = pivot;
            values.PrintArray("partition end", ConsoleColor.Green);
            Console.WriteLine(" Index return" + i);
            return i;
        }
    }

    public class QuickSortDemo
    {
        public static void Demo()
        {
            int[] values = { 23, 5, 2, 8, 12, 7, 16, 9 };
            QuickSort quick = new QuickSort();
            quick.QuickSortArry(values, 0, values.Length - 1);
            values.PrintArray("Final");
        }
    }
}
