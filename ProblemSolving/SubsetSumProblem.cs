using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving
{
    /* you given set of values and check wether it will make the given sum
     * e.g set {1,2,5,7}
     * sum=8
     * True => {1,2,5} 
     * 1 for true n 0 for false
     * -------------------------------------------------
     * i->  |0 |1 |2 |3 |4 |5 |6 |7 |8|
     * -------------------------------------
     * J|0  |T |F |F |F |F |F |F |F |F| ----> Pre -fill data
     *   1  |T |T |
     *   2  |T |
     *   5  |T |
     *   7  |T |
     * -----------------------------------------------
     * 1) each time find value from previous cell + 
     * if(current row value is less the column value or equal the true otherwise false)
     * 
     * 
     * 
     Truth Value=TV by Excluding New Value + TV by Including new value

        see previous row value(true) + check (1<0 r<c) (false) =true

        r=c => true
        if tem[previous] =true 

         
         */
    public class SubsetSumProblem
    {
        //{ 1, 3, 2, 7, 5, 4 }
        public void SolveProblem(int[] array, int sum)
        {
            //declare subset to store memoization matrix
            var subset = new bool[sum + 1, array.Length + 1];

            //pre fill down the row by true
            for (int j = 0; j <= array.Length; j++)
            {
                subset[0, j] = true;
            }

            //pre fill stright the column by false
            for (int i = 0; i <= sum; i++)
            {
                subset[i, 0] = false;
            }
            //------Row(->) * Col(|)
            
            for (int row = 1; row <= sum; row++)
            {
                for (int col = 1; col <= array.Length; col++)
                {
                    //see the prvious value in same column but previous row
                    //<TV by Excluding New Value>
                    subset[row, col] = subset[row, col - 1];

                    //if(current row value is less the column value or equal the true otherwise false)
                    //TV by Including new value
                    if (row >= array[col - 1])
                    {
                        //Truth Value = TV by Excluding New Value +(||) TV by Including new value
                        //+ in bool is  || or operator

                        subset[row, col] = subset[row, col] || subset[row - array[col - 1], col - 1];
                    }
                }
            }

            PrintLogic(subset);
            Console.ReadLine();
        }

        private static void PrintLogic(bool[,] subset)
        {
            for (int i = 0; i < subset.GetLength(0); i++)
            {
                for (int j = 0; j < subset.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0} ", subset[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
    }
}
