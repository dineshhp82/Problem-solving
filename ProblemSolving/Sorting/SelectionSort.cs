using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProblemSolving.Sorting
{
    public class SelectionSort
    {

        /*  10, 4, 8, 30, 24, 7, 20 
         *  4,7,8,10,20,24,30
         *  
         *  First pass
         *  10,4,8,30,24,7,20
         *  find small which is 4
         *  swap 4,10,8,30,24,7,20 
         *  
         * -First Find the smallest number in remaing item (each pass value are sorted)
         * -swap with supposed values;
         
          */
        public static void SortValues(int[] values)
        {
            for (int i = 0; i < values.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i; j < values.Length; j++)
                {
                    if (values[minIndex] > values[j])
                    {
                        minIndex = j;
                    }
                }

                var temp = values[minIndex];
                values[minIndex] = values[i];
                values[i] = temp;
            }
        }
    }
}
