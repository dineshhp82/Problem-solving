using ProblemSolving.Utilties;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace ProblemSolving.DivideConqure
{
    /* Divide problem into sub problem and then combine
     
     */
    public class DivideArrayInSubPartsAndSum
    {
        int MAXSUM = 0;
        public int DivideSubArrayAndSum(int[] values, int s, int e)
        {
            if (s < e)
            {
                int m = (s + e) / 2;
                DivideSubArrayAndSum(values, s, m);
                DivideSubArrayAndSum(values, m + 1, e);
                int cs = SumSubArray(values, s, m, e);

                if (MAXSUM < cs)
                {
                    MAXSUM = cs;
                }
            }

            return MAXSUM;
        }

        private int SumSubArray(int[] values, int s, int m, int e)
        {
            values.PrintArray(s, m, "Left Sub Array", ConsoleColor.Green);
            values.PrintArray(m + 1, e, "Right Sub Array", ConsoleColor.Red);

            int leftSum = 0;
            for (int i = s; i <= m; i++)
            {
                leftSum += values[i];
            }

            int rightSum = 0;
            for (int i = m + 1; i <= e; i++)
            {
                rightSum += values[i];
            }
            Console.WriteLine($"Left Sum : {leftSum} Right Sum : {rightSum}");
            if (leftSum <= rightSum)
            {
                return rightSum;
            }
            return leftSum;
        }

        public static void Demo()
        {
            DivideArrayInSubPartsAndSum s = new DivideArrayInSubPartsAndSum();
            var array = new[] { 22, 10, 4, 38, 30, 24, 7, -20, 95 };
            array.PrintArray("start");
            int result = s.DivideSubArrayAndSum(array, 0, array.Length - 1);

            Console.WriteLine("MAX=>" + result);
        }
    }
}
