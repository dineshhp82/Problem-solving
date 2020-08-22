using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving.Basic
{
    public class Pyramid
    {
        public static void PrintUpTriangle(int height)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = height - i; j > 0; j--)
                {
                    Console.Write(" ");
                }

                int k = 0;
                while (k <= i)
                {
                    Console.Write(" * ");
                    k++;
                }
                Console.WriteLine("\n");
            }

        }

        public static void PrintDownTriangle(int height)
        {
            for (int i = 0; i < height; i++)
            {
                int p = 0;
                while (p <= i)
                {
                    Console.Write(" ");
                    p++;
                }

                for (int j = height - i; j > 0; j--)
                {
                    Console.Write(" * ");
                }

                int k = 0;
                while (k <= i)
                {
                    Console.Write(" ");
                    k++;
                }

                Console.Write("\n");
            }
        }

        public static void Diamond(int height)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < height - i; j++)
                {
                    Console.Write(" ");
                }

                for (int p = 0; p <= i; p++)
                {
                    Console.Write("* ");
                }

                Console.Write("\n");
            }

            for (int i = 1; i < height; i++)
            {
                for (int p = 0; p <= i; p++)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < height - i; j++)
                {
                    Console.Write("* ");
                }

                Console.Write("\n");
            }
        }
    }
}
