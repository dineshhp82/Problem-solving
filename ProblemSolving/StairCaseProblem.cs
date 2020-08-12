using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving
{
    //Ladder problem where define max steps to climbs.
    public class StairCaseProblem
    {
        //Recurssive
        public int ReturnWays(int steps)
        {
            if (steps == 1 || steps == 2)
            {
                return 1;
            }
            else
            {
                return ReturnWays(steps - 1) + ReturnWays(steps - 2);
            }
        }

        //Non-Recursive
        public void ReturnWaysSimple(int noOfSteps)
        {
            int firstNumber = 0;
            int secondNumber = 1;
            int nextNumber = firstNumber + secondNumber;

            Console.Write(firstNumber + " " + secondNumber + " ");

            for (int i = 2; nextNumber < noOfSteps; i++)
            {
                Console.WriteLine(nextNumber);
                firstNumber = secondNumber;
                secondNumber = nextNumber;
                nextNumber = firstNumber + secondNumber;
            }
        }
    }
}
