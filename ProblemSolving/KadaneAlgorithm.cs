using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProblemSolving
{
    /* Find Max Sum of sub array
     
    */
    public class KadaneAlgorithm
    {
        //int[] array={4,3,-2,2,3,1,-2,-3,4,2,-6,-3,-1,3,1,2}
        public void SolveProblem(int[] array)
        {
            int max_so_far = array[0]; //var replace only value less then current max value
            int max_ending_here = 0; //var is used to store sequence value sum and reset if it's -ve

            int start_index = 0;
            int end_index = 0;
            int s = 0;

            for (int i = 0; i < array.Length; i++)
            {
                max_ending_here = max_ending_here + array[i];

                if (max_so_far < max_ending_here)
                {
                    max_so_far = max_ending_here;

                    start_index = s;
                    end_index = i;
                }

                if (max_ending_here < 0)
                {
                    max_ending_here = 0;
                    s = i + 1;
                }
            }
            Console.WriteLine("Start Index =>" + start_index);
            Console.WriteLine("End Index =>" + end_index);
            Console.WriteLine("max value =>" + max_so_far);
        }

    }
}
