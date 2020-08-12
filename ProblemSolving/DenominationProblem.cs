using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving
{
    /* Find minimum number of currency notes and values that sum to given amount
     * Given an amount, find the minimum number of notes of different denominations that 
     * sum upto the given amount. Starting from the highest denomination note, 
     * try to accommodate as many notes possible for given amount.
       We may assume that we have infinite supply of notes of values 
       {2000, 500, 200, 100, 50, 20, 10, 5, 1} 

        formula =>
        no's of notes = amount/denomination 
        remianing amount =amount-(No's of notes*denomination)
        then repeat the same logic for next denomination

        e.g amount=510
        Denomination| No's of Note|Remianing amount
        -------------------------------------------
        2000        |0            | 510
        ----------------------------------------
        500         |1            |10
        ---------------------------------------
        200         |0            |10
        ---------------------------------------
        100         |0            |10
        ----------------------------------------
        50          |0            |10
        ---------------------------------------
        20          |0            |10
        ----------------------------------------
        10          |1            |0
        ---------------------------------------
        5           |0            |0
        ---------------------------------------
        2           |0            |0
        ----------------------------------------
        1           |0            |0
        ----------------------------------------

        Rule : if den > remaing amount then continue.
        and remaing is zero then break.
       
        This type of algo is called GREEDY APPROACH
     */
    public class DenominationProblem
    {
        readonly int[] denomination = { 2000, 500, 200, 100, 50, 20, 10, 5, 2, 1 };

        public void SolveProblem(int amount)
        {
            int remainAmount = amount;

            for (int i = 0; i < denomination.Length; i++)
            {
                if (denomination[i] > remainAmount || remainAmount == 0)
                {
                    Console.WriteLine($"Rupees : {denomination[i]} - 0");
                    continue;
                }

                var noOfNotes = remainAmount / denomination[i];
                remainAmount = remainAmount - (noOfNotes * denomination[i]);
                Console.WriteLine($"Rupees : {denomination[i]} - {noOfNotes}");
            }

        }
    }
}
