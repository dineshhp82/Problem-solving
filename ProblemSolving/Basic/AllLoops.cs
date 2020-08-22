using ProblemSolving.Utilties;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving.Basic
{
    public class AllLoops
    {

        static int[] values = { 1, 6, 10, 3, 50, 60, 2, 100 };

        public static void ForwardForLoop()
        {
            values.PrintArray("Forward For");

            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine(values[i]);
            }
        }

        public static void ReverseForLoop()
        {
            values.PrintArray("Reverse For");
            for (int i = values.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(values[i]);
            }
        }

        public static void ForwardWhileLoop()
        {
            values.PrintArray("Forward While");

            int i = 0;
            while (i <= values.Length - 1)
            {
                Console.WriteLine(values[i]);
                i++;
            }
        }

        public static void ReverseWhileLoop()
        {
            values.PrintArray("Reverse While");

            int i = values.Length - 1;
            while (i >= 0)
            {
                Console.WriteLine(values[i]);
                i--;
            }
        }

        /* left item from left side
         *   ######
         *   #####
         *   ####
         *   ###
         *   ##
         *   #
         * 1 2 3 4 5 6
         * 
         * O->1
         * I->1 2 3 4 5 6
         * 
         * O->2
         * I->2 3 4 5 6
         * 
         * O->3
         * I->3 4 5 6
         * 
         * O->4
         * I->4 5 6
         * 
         * O->5
         * I->5 6
         * 
         * O->6
         * I->6
         *
         
         */

        public static void TwoNestedForLoop()
        {
            values.PrintArray("Before ");
            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine("Current Index : " + i);
                for (int j = i; j < values.Length; j++)
                {
                    Console.WriteLine("....." + values[j] + ",");
                }
            }
        }

        /* left items from right side
            1 2 3 4 5 6

            1
            1 2 3 4 5 6

            2
            1 2 3 4 5

            3
            1 2 3 4

            4
            1 2 3

            5
            1 2

            6
            1
         */
        public static void TwoNestedForAnotherLoop()
        {
            values.PrintArray("Before ");
            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine("Current Index : " + i);
                for (int j = 0; j < values.Length - i; j++)
                {
                    Console.WriteLine("....." + values[j] + ",");
                }
            }
        }
    }
}
