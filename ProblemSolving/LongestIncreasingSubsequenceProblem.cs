using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving
{
    /*problem is to find the max subsequence length and array
     * you have to traverse give array and compare with its previous sub array
     *
     * subarray => current position of element in array
     * 
     * e.g 
     * --------------------------------------------
     * Index => |0 |1  |2 |3 |4 |
     * --------------------------------------------
     * Array => |3 |10 |2 |1 |20|
     * --------------------------------------------
     * Lenght=> |1 |2  |1 |1 |3 |  => Max Length =3
     * --------------------------------------------
     * Subsq=>  |S |0  |0 |0 |1 |  => S =>Start  sub seq => 20 ,Index=1 value in array =10 ,at index =0 point to S where S=3
     * --------------------------------------------
     * Subseq =>3,10,20
     * |
     * --------------------------------------------
     */

    public class LongestIncreasingSubsequenceProblem
    {
        public void SolveProblem(int[] array)
        {
            int[] lengthArray = new int[array.Length];

            for (int i = 0; i < lengthArray.Length; i++)
            {
                lengthArray[i] = 1;
            }

            int[] subSequence = new int[array.Length];

            int MAX_LENGTH = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j] < array[i] && lengthArray[i] < lengthArray[j] + 1)
                    {
                        lengthArray[i] = lengthArray[i] + 1;
                        subSequence[i] = j;
                    }
                }
                if (MAX_LENGTH < lengthArray[i])
                {
                    MAX_LENGTH = lengthArray[i];
                }
            }
            Console.WriteLine(MAX_LENGTH);
        }

        public int SolveProblemRec(int[] array, int startIndex, int endIndex)
        {
            int[] lengthArray = new int[array.Length];

            for (int i = 0; i < lengthArray.Length; i++)
            {
                lengthArray[i] = 1;
            }

            int MAX_LENGTH = 0;

            if (startIndex == endIndex)
            {
                return MAX_LENGTH;
            }

            if(startIndex<endIndex)
            {
                return SolveProblemRec(array, startIndex, endIndex);
            }

            return MAX_LENGTH;
        }
    }
}
