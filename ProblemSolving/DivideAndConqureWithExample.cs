using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving
{
    /* We have some problem say P and its large and complex problem so we divide the P is sub problem say
     * p1,p2,p3 ... pk and the solution of sub problem say s1,s2,s3....sk then the last step is to combine all
     * the sub problem to make S.
     * 
     * e.g find min in array by divide and conqure
     * array ={1,5,4,7}
     * algo is just divide the array in half first
     * ----------------------------------
     * array=>|1 |5 |4 |7 |
     * --------------------
     * index=>|1 |2 |3 |4 |
     * ---------------------------
     * 
     * first left=1 and right=4
     * mid= (left+right)/2; => 1+5/2 =2
     * min1 =findmin(array,left,mid) => (a,1,2)
     * min2 =findmin(array,mid+1,right) =>(a,2+1,4)
     * if(min1 < min2) return min1 else min2;
     *
     * 
     * 
     * 
     * 
     */
    public class DivideAndConqureWithExample
    {
        //{ 2, 4, 1, 9, 8, 3, 0, 7 }
        public int SolveProblem(int[] array, int left, int right)
        {
            int mid, minLeft = 0, minRight = 0;
            if (left < right)
            {
                mid = (left + right) / 2;
                Console.WriteLine($"minLeft {minLeft}:minRight {minRight}  mid {mid} left {left} right {right}");
                minLeft = SolveProblem(array, left, mid);
                Console.WriteLine($"right and minleft{minLeft}");
                minRight = SolveProblem(array, mid + 1, right);
                Console.WriteLine($"right and minright{minRight}");
                if (minLeft < minRight)
                {
                    return minLeft;
                }
                else
                {
                    return minRight;
                }
            }
            else
            {
                Console.WriteLine($"left :{left} value : {array[left]}");

                return array[left];
            }
        }

        public int FindMax(int[] array, int low, int high)
        {
            if (low == high - 1)
            {
                return array[low];
            }

            int mid = low + high / 2;
            Console.WriteLine($"{array[mid]} < {array[mid + 1]}");
            if (array[mid] < array[mid + 1])
            {
                return FindMax(array, mid + 1, high); //find from right
            }
            else
            {
                return FindMax(array, low, mid + 1); //find from left
            }
        }
    }
}
