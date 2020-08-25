using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

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

        public int MaxInArray(int[] a, int index)
        {
            if (index > 0)
            {
                Console.WriteLine($"{index} : {a[index]} : {index - 1}");
                return Math.Max(a[index], MaxInArray(a, index - 1));
            }
            else
            {
                return a[0];
            }
        }

        public int Pow(int x, int n)
        {
            if (n > 0)
            {
                Console.WriteLine($"{x} : {n - 1}");
                return x * Pow(x, n - 1);
            }
            else
            {
                return 1;
            }
        }

        //equation n!=n(n-1);
        /* 5!=5(5-1)=(5*24)=120
         *   =4(4-1)=(4*6)=24
         *   =3(3-1)=(3*2)=6
         *   =2(2-1)=(2*1)=2
         *   =1(1-1)=(1*1)=1
         *   =0!=1
         */
        public int Factorial(int number)
        {
            if (number > 0)
            {
                return number * Factorial(number - 1);
            }
            else
            {
                return 1;
            }
        }

        //f(n)=f(n-1)+f(n-2);
        public int FibonacciValueAtIndex(int index)
        {
            if (index == 1 || index == 2)
            {
                return 1;
            }
            else if (index == 0)
            {
                return 0;
            }
            else
            {
                return FibonacciValueAtIndex(index - 1) + FibonacciValueAtIndex(index - 2);
            }
        }


        public void PrintFibonacciSeries(int number)
        {
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine(FibonacciValueAtIndex(i));
            }
        }

        //Recursive sum of values in arrays
        public int SumOfArray(int[] values, int index)
        {
            if (index == 0)
            {
                return values[0];
            }
            else
            {
                return values[index] + SumOfArray(values, index - 1);
            }
        }
    }
}
