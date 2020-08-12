using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving
{
    /* --------------Coin(Row) vs Total(Column)-------------
     *       0    1   2   3   4   5
     * -----------------------------------------------------      
     * 0 |   1    0   0   0   0   0
     * ------------------------------
     * 1 |   1    1   1   1   1   1  
     * ------------------------------
     * 2 |   1    1   2   2   3   3 
     * ------------------------------
     * 3 |   1    1   2   3   4   5
     * ------------------------------
     * 4 |   1    1   2   3   5   6
     * ------------------------------
     * 5 |   1    1   2   3   5   7
     * ------------------------------
     * Final Result => 7
     * 
     * Rule :
     * 1) if r(Coin) > c(Total) the copy the value from above cell e.g Make total 2 using coin {0,1,2,3}
     *    here r=>Coin=>3 and c=>Total=>2 so copy value from above cell is "2"
     * 2) Exclude the new coin  (Take previous row number number) e.g Make 5 using Coin {0,1,2,3,4} 
     *    here exclude 4 from this so remaing {0,1,2,3} and its previous row value "5"
     * 3) Include the new coin  (remaing value in same row) e.g in same above case now include new coin 
     *    after include {0,1,2,3,4} trick 4(New Number) + ?(How much add) = 5(Total) so ans is => "1"
     *    scan same row at 1 position where value => "1"
     * 4) Add the number (Exclude+Include) ans => 5(Exclude)+1(Include)=>6
     * 
     * 
     * 
     */
    public class CoinChangeProblem
    {
        public void FindCombination(int totalCoin, int totalAmount)
        {
            var table = new int[totalCoin + 1, totalAmount + 1];
            //base codition
            table[0, 0] = 1;

            for (int coin = 1; coin < totalCoin + 1; coin++)
            {
                for (int total = 0; total < totalAmount + 1; total++)
                {
                    //while coin is greater than total the pick value from previous cell(row) but column same
                    if (coin > total)
                    {
                        table[coin, total] = table[coin - 1, total];
                    }
                    else
                    {
                        table[coin, total] =
                            //Exclude the new coin and pick previous cell(row) but column same
                            table[coin - 1, total] 
                            +
                            //include the new coin and check differenc in same diff value column in same row
                            table[coin, total - coin]; 
                    }
                }
            }
            Console.WriteLine(table[totalCoin, totalAmount]);
        }
    }
}
