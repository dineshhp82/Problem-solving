using ProblemSolving.Utilties;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving.Basic
{
    public class SwapInArray
    {
        /*
         Whenever you doing +1 in index inside the loop then you need to -1 from length other
         wise index error

         Whenever you doing -1 in index inside the loop then you need to remove =0 termination
         condition (>=0 => >0)
         */
        public static void MoveFirstItemToLast(int[] values)
        {
            /* 10 20
             * i   i+1
             * temp=i;
             * i=i+1;
             * i+1=temp;
             
             */
            values.PrintArray("Before ");

            for (int i = 0; i < values.Length - 1; i++)
            {

                int temp = values[i];
                values[i] = values[i + 1];
                values[i + 1] = temp;
            }

            values.PrintArray("After ");
        }

        public static void MoveLastItemToFirst(int[] values)
        {
            values.PrintArray("before ");

            for (int i = values.Length - 1; i > 0; i--)
            {
                int temp = values[i];
                values[i] = values[i - 1];
                values[i - 1] = temp;
            }

            values.PrintArray("after ");
        }
    }
}
