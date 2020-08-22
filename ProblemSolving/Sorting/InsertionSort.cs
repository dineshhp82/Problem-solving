using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving.Sorting
{
    public class InsertionSort
    {
        //10, 4, 8, 30, 24, 7, 20
        public static int[] SortValues(int[] values)
        {

            for (int i = 0; i < values.Length; i++)
            {
                int current = values[i];
                // Console.WriteLine(current);
                int j = i - 1;

                //reached at the end of loop and value[j] is greater the current
                while (j >= 0 && values[j] > current)
                {
                    values[j + 1] = values[j];//shift element one by one
                    j--;
                }
                values[j + 1] = current;
            }

            string str = "Array [";
            for (int i = 0; i < values.Length; i++)
            {
                str += $"{values[i]} ,";
            }
            str = str.Trim(',') + "]";

            Console.WriteLine(str);

            return values;
        }
    }
}
