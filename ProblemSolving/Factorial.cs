using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving
{
    /* 4! =3*2*1
     
         */
    public class Factorial
    {
        public void SolveProblem(int val)
        {
            int fat = 1;
            for (int i = 1; i <= val; i++)
            {
                fat = fat * (i);
            }

            Console.WriteLine(fat);
        }
    }
}
