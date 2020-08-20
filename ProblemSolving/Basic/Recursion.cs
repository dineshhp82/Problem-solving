using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving.Basic
{
    /*
     Must have some breaking condition
     Recursion use stack to store computed value

     if no breaking condition then stack overflow occure
     if depath of recusrion is very deep then may stack overflow occure.

    Stack Frame  this is call head recrsion
     -Push the expression
     -Pop and evaluevated the expression

    To mitigation the stack overflow use tail recursion
     -

     
    */
    public class Recursion
    {
        public int GCD(int a, int b)
        {
            //Breaking condition
            if (b == 0)
            {
                return a;
            }
            //recursive call
            return GCD(b, a % b);
        }

        //5! =5*4*3*2*1;
        //n!=n*(n-1)*(n-2)...
        //n!=n*Fac(n-1);
        // Head Recursion


        public int HeadRecursionFactorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return HeadRecursionFactorial(n - 1) * n;
        }

        //Result => is called Accumulator
        //no need to required stack framework
        public int TailRecursionFactorial(int n, int result)
        {
            if (n == 0)
            {
                return result;
            }

            return TailRecursionFactorial(n - 1, n * result);
        }
    }
}
