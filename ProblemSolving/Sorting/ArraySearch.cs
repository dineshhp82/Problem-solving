using ProblemSolving.Utilties;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ProblemSolving.Sorting
{
    public class ArraySearch
    {
        /* But the worst case when item in array are millions and item exist in 
         * last or item does not exist, so in this case you need to travese all elements in array
         * Bad Performance
             */
        public static string SearchUnOrderArray(int[] values, int searchValue)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == searchValue)
                {
                    return $"value found at index {i}";
                }
            }

            return "Not found";
        }

        /* Divide and conquer 
         * while (start<=end)
         *   -mid=start+end/2
         *    if(key<A[mid]) => left => end index change
         *      mid=mid-1;
         *      end=mid;
         *    if(key>A[mid]) => right => start index change
         *       mid=mid+1;
         *       start=mid;
         *    if(key==A[mid])
         *      return found
         * 
         * 
            e.g 
            0   1  2  3   4   5  6
            -----------------------
            4,  7, 8, 10, 20, 24 30
            S          M          E
            search Key=20;
            start =0; 
            end =A.lenght;

            start value always less or equal to end value

            while loop is running untill start <= end

            start value change

            key = A[mid] => found 
            key > A[M]   => move toward right +1 in mid
            key < A[M]   => move toward left  -1 in mid

            mid=start+end/2=(0+6)/2=3;
            if(Key>A[M])
            mid=mid+1;
            mid=start index
            why +1 because you skip value before mid and start one index ahead

            4  5  6
            --------
            20 24 30
            S      E
            again find mid
            mid=(4+6)/2=5
            if(key==A[mid])
             got the index



            e.g 

             0   1  2  3   4   5  6
            -----------------------
            4,  7, 8, 10, 20, 24 30
            S          M          E

            key =4
            
            start=0;
            end =a.lenght =6;
            mid= 0+6/2=3
            if(key<A[3]) 4<10
            mid=mid-1; 2
            mid=end index
            0  1  2
            -------
            4  7  8
            S     E

            mid=0+2/2 =1;

            if(key<A[1]) 4<7
            mid=mid-1; 0
            endindex=mid;

            mid=0+0/2=0;


          */

        public static void SearchOrderArray(int[] values, int searchValue)
        {
            var sortedArray = InsertionSort.SortValues(values);

            int start = 0;
            int end = sortedArray.Length - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (sortedArray[mid] == searchValue)
                {
                    Console.WriteLine("Item found at index =>" + mid);
                    return;
                }
                else if (searchValue < sortedArray[mid])
                {
                    end = mid - 1;
                }
                else if (searchValue > sortedArray[mid])
                {
                    start = mid + 1;
                }
            }

            Console.WriteLine("Item not found");
        }


        /*

              0  1  2  3   4   5  6  7
              -------------------------
              4, 7, 8, 10, 20, 24 30 0
              
              suppose value insert = 21

              0  1  2   3   4   5  6  7
              ---------------------------
              4  7  8  10  20  21 24 30
              -------------------------
              0  1  2   3   4  5, 7-1,8-1
             


             
             */
        public static void InsertItemInSortedArray(int[] values, int insertValue)
        {
            var lastIndex = values.Length - 1;

            //traverse to end of item for wrost case insert item in front of array
            while (lastIndex >= 0)
            {
                //this condition check empty value at the end of array
                if (values[lastIndex] == 0)
                {
                    lastIndex--;
                    continue;
                }

                //traverse until the insert value index not found and move value one step ahead
                if (insertValue < values[lastIndex])
                {
                    values[lastIndex + 1] = values[lastIndex];
                    lastIndex--;

                    continue;
                }
                break;
            }
            //add value to the found index 
            values[lastIndex + 1] = insertValue;

            values.PrintArray("After");
        }

        /* first find the value that want to delete exist in array 
         * if exist the what is the index 
         * set the value 0(int) then move value from find index to one by one so that 0
         * value set at the end
           
            
            
            
            
            
            Before  Array [4 ,7 ,8 ,10 ,20 ,24 ,30 ,0 ]

            10
         */
        public static void DeleteItemFromSortedArray(int[] values, int deleteValue)
        {
            int index = 0;
            bool isFound = false;

            values.PrintArray("Before ");
            while (index < values.Length - 1)
            {
                if (deleteValue == values[index])
                {
                    isFound = true;
                }
                if (isFound)
                {
                    values[index] = values[index + 1];
                    values[index + 1] = 0;
                }

                index++;
            }
            if (isFound == false)
            {
                Console.WriteLine("Item does not exist in array");
            }
            values.PrintArray("After ");
        }
    }
}
