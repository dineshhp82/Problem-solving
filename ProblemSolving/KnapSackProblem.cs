using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProblemSolving
{
    /* KnapSack problem  is one of Greedy method apporach
     * KnapSack problem : 
     * Given weights and values of n items, 
     * we need to put these items in a knapsack of capacity W to get the maximum total value in the knapsack.
     * 
     * Example :
     * Supposed we have 7 item say x1.....x7 and a bag with max capacity is 15kg and you need to gain
     * max profit.
     * -------------------------------------------------------------------
     * Object |1   |2   |3    |4     |5     |6      |7   | 
     * -------------------------------------------------------------------
     * Profit |10  | 5  |15   |7     |6     |18     |3   |
     * -------------------------------------------------------------------
     * Weight |2   |3   |5    |7     |1     |4      |1   |
     * -------------------------------------------------------------------
     * P/W    |5   |1.6 |3    |1     |6     |4.5    |3   |
     * -------------------------------------------------------------------
     * Rule:
     * Constraint => Bag weight not max then 15kg.
     * Sum of Weight => 15kg
     * Sum of Profile => Max.
     * Possible solution is to first caluclate the Profit by weight then sort by max p/w and apply this
     * 1) in above matrix max p/w value 6 and weight => 1 so 15(max)-1(weight at max p/w)=>14 (remaing)
     * 2) next max pw value 5 and weight =>2 so 14-2=12(remaing)
     * 3) next max pw value 4.5 and weight =>4 so 12-4=8(remaing)
     * 4) next max pw value 3 and weight =>5 so 8-5=3(remaing)
     * 5) next max pw value 3 and weight =>1 so 3-1=2(remaing)
     * 6) next max pw value 1.6 and weight =>3 so 2-3=-1(here value goes -ve so in this case
     *                                            2-2 = 0 but instead calculate pw 5/3 calculate 2/3
     * ----------------------------------------------------------------------------------------------
     * Sum of weight => 1*2+ 2/3*3 +1*5+0*7+1*1+1*4+1*1=>15 kg
     * Sum of Profit => 1*10+2/3*5+1*15+0*7+1*6+1*18+1*3=>54.6
     * 
     * 
     * 
     * 

          */
    public class KnapSackProblem
    {
        //take in decimal becase fraction of value also possible due to pw 
        //if take int the need to convert all value at calc level.
        private readonly decimal MaxWeight = 20;

        private readonly decimal[] Profit = { 10, 5, 15, 7, 6, 18, 3 };

        private readonly decimal[] Weight = { 2, 3, 5, 7, 1, 4, 1 };

        public void SolveProblem()
        {
            //Dictionary store index (key) + pw (value) so that lookup the index of key by value
            var profitWeight = new Dictionary<int, decimal>();

            for (int i = 0; i < Weight.Length; i++)
            {
                decimal pw = Profit[i] / Weight[i]; //(profit per weight value)
                profitWeight[i] = pw;
            }

            //order by max pw value
            var sortedProfitWeight = profitWeight.OrderByDescending(x => x.Value).ToArray();

            var remainWeight = MaxWeight;
            var sumOfProfit = 0m;

            for (int i = 0; i < sortedProfitWeight.Count(); i++)
            {
                //lookup the key index
                var keyIndex = sortedProfitWeight[i].Key;

                if (remainWeight <= MaxWeight || remainWeight == 0)
                {
                    //while remain weight is negtive
                    if (remainWeight - Weight[keyIndex] < 0)
                    {
                        //then calculate pw value on remain weight and break you loop
                        var pw = (remainWeight * Profit[keyIndex]) / Weight[keyIndex];
                        sumOfProfit = sumOfProfit + pw;
                        Console.WriteLine($"Weight used {remainWeight}-{Weight[keyIndex]}={remainWeight} and total profit={sumOfProfit}");
                        break;
                    }
                    //Calculate remain weight (capcity)
                    remainWeight = remainWeight - Weight[keyIndex];
                    //sum the profile earn at this position
                    sumOfProfit = sumOfProfit + (Profit[keyIndex]);
                    Console.WriteLine($"Weight used {remainWeight}-{Weight[keyIndex]}={remainWeight} and profit={sumOfProfit}");
                }
            }
        }
    }
}
