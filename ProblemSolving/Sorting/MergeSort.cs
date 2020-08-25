using ProblemSolving.Utilties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProblemSolving.Sorting
{
    /* Divide array into sub array until single element left
     * then compare left array with right array and merge
     * 
     * e.g
     *  0    1   2   3   4    5    6   7
     * [23 | 5 | 2 | 8 | 12 | 7 | 16 | 9 ]
     *  S=0                           E=len-1
     *  
     *  find mid
     *  mid=floor(s+e)/2 => 0+8/2=4
     *  
     *  [23 | 5 | 2 | 8 |] M [| 12 | 7 | 16 | 9 ]
     *   S=0               4 
     *  mid=floor(0+4)/2=2
     *  
     *  [23 | 5 |] M [ 2 | 8 |]
     *   S=0       2 
     *   mid=flooe(0+2)/2 =1
     *  
     *  
     *  left side =(A,s,mid)
     *  right side=(A,mid+1,e)
     */
    public class MergeSort
    {
        public void MergeSortArray(int[] values, int s, int e)
        {

            if (s < e)
            {
                int mid = (int)Math.Floor((decimal)((s + e) / 2));
                values.PrintArray(s, mid, "First ");
                MergeSortArray(values, s, mid);



                Console.WriteLine("Move next step");

                MergeSortArray(values, mid + 1, e);
                values.PrintArray(mid + 1, e, "Second ");

                MergeValue(values, s, mid, e);
                values.PrintArray("After merge ");
            }
        }

        private void MergeValue(int[] values, int s, int m, int e)
        {
            values.PrintArray(s, e, "Sub Array ", ConsoleColor.Green);
            int leftCount = m - s + 1;
            int rightCount = e - m;

            int[] leftTemp = new int[leftCount];
            for (int i = 0; i < leftCount; i++)
            {
                leftTemp[i] = values[s + i];
            }

            int[] rightTemp = new int[rightCount];
            for (int j = 0; j < rightCount; j++)
            {
                rightTemp[j] = values[m + j + 1];
            }

            int l = 0, r = 0;

            for (int k = s; k <= e; k++)
            {
                if ((r >= rightCount) || (l < leftCount && leftTemp[l] <= rightTemp[r]))
                {
                    values[k] = leftTemp[l];
                    l++;
                }
                else
                {
                    values[k] = rightTemp[r];
                    r++;
                }
            }
        }


    }

    public class MergeSortSimulator
    {
        public static void Simulator()
        {
            int[] values = { 23, 5, 2, 8, 12, 7, 16, 9 };
            values.PrintArray("Orginal ");
            MergeSort mergeSort = new MergeSort();
            mergeSort.MergeSortArray(values, 0, values.Length - 1);
            values.PrintArray("Final ");
        }
    }
}
