using ProblemSolving.Basic;
using ProblemSolving.DataStructure;
using ProblemSolving.DivideConqure;
using ProblemSolving.Sorting;
using ProblemSolving.StringManipulate;
using System;
using System.Threading;

namespace ProblemSolving
{
    /* Dynamic Problem
     * Greedy Approach
     * Divide and Conquire Approach
     * Branch and Bound
     * Parition 
     * All possible combination's
     *///
    class Program
    {
        static void Main(string[] args)
        {
            SuperReducedString.ReducedString("aad");

            //PrintDuplicateAndCount.CountDuplicateSimple("Moon starter");
            //Console.WriteLine("-----");
            //PrintDuplicateAndCount.CountDuplicateFast("Moon starter");
            //var t = AnagramDemo.IsAnagram("Astronomer", "Moon starer");
            //Console.WriteLine(t);
            //var r = Palindrome.IsPalindrome("civic");
            //var r1 = Palindrome.IsPalindromeWithFor("civic");
            //var r2 = Palindrome.IsPalindromeWithFastWay("racecare");
            //Console.WriteLine(r2);
            //Console.WriteLine(r);
            //ReverseString.ReverseByRecursion("dinesh");
            // Recursion r = new Recursion();
            //int c = r.SumOfArray(new[] { 10, 4, 8, 30, 24, 7, 20 }, 6);
            // Console.WriteLine(c);
            //r.PrintFibonacciSeries(10);
            //int d = r.FibonacciValueAtIndex(7);
            //Console.WriteLine(d);
            //DivideArrayInSubPartsAndSum.Demo();
            //Pyramid.PrintUpTriangle(10);
            //Pyramid.Diamond(10);
            //QuickSortDemo.Demo();
            //LinkedListDemo.Demo();
            //MergeSortSimulator.Simulator();
            //QueueSimulator.SimpleQueueSimulate();
            //Simulator.Simulate();
            //ArraySearch.SearchOrderArray(new[] { 10, 4, 8, 30, 24, 7, 20 }, 4);

            //SwapInArray.MoveLastItemToFirst(new[] { 10, 4, 8, 30, 24, 7, 20 });

            //AllLoops.TwoNestedForAnotherLoop();

            /// AllLoops.ForwardForLoop();
            //AllLoops.ReverseForLoop();
            // AllLoops.ForwardWhileLoop();
            // AllLoops.ReverseWhileLoop();

            //var arr = new int[8];
            //arr[0] = 4;
            //arr[1] = 7;
            //arr[2] = 8;
            //arr[3] = 10;
            //arr[4] = 20;
            //arr[5] = 24;
            //arr[6] = 30;
            //ArraySearch.DeleteItemFromSortedArray(arr, 130);
            //ArraySearch.InsertItemInSortedArray(arr, 3);
            // InsertionSort.SortValues(new[] { 10, 4, 8, 30, 24, 7, 20 });
            //TreeSimulator.Simulate();
            //LRUSimulator.Simulate();
            //FindLargestSubsequence.CountLargestSubSequence("abc");
            //RailwayQueue railwayQueue = new RailwayQueue();
            //railwayQueue.PerformOperation();
            //string str = "D@ine$h Sha%ma";
            //var strr = str.Replace('@', ' ')
            //    .Replace('$', ' ')
            //    .Replace('%', ' ');
            //Console.WriteLine(strr);

            //GenericLinkedList.Start();
            //LinkedList linkedList = new LinkedList();
            //linkedList.InsertNodes(3);
            //linkedList.PrintAllNodes();
            //linkedList.RemoveNodeByValue(5);
            //linkedList.RemoveNodeByValue(3);
            //linkedList.RemoveNodeByValue(5);
            //linkedList.PrintAllNodes();
            //linkedList.InsertNodes(5);

            //linkedList.AddNodeAtTop(1);
            //linkedList.AddNodeAtTop(2);
            //linkedList.AddNodeAtTop(3);
            //linkedList.AddNodeAtTop(5);
            //linkedList.AddNodeAtTop(6);
            //linkedList.AddNodeAtBottom(1);
            //linkedList.AddNodeAtBottom(2);
            //linkedList.AddNodeAtBottom(3);

            //linkedList.PrintAllNodes();

            //linkedList.AddNodeInBetween(4, 3);

            //linkedList.PrintAllNodes();
            //AnagramSortedDictionary.GetList();
            //FibonacciSeries();
            // CoinProblem();
            //var den = new DenominationProblem();
            //den.SolveProblem(2543);

            //Knapsack();
            // Kadane();
            //LIS();
            //Factorial();

            // Excel();

            //SubSetSum();

            // DivideAndConqureWithExample example = new DivideAndConqureWithExample();
            //var array = new int[] { 2, 4, 1, 9, 8, 3, 0, 17 };
            // Console.WriteLine(example.SolveProblem(array, 0, array.Length - 1));
            //Console.WriteLine(example.FindMax(array, 0, array.Length - 1));
            //BubbleSort.SortByBubble(array);
            //var arr = new int[] { 10, 9 };
            //FindMinMaxInArray.MinMaxInArray(arr);

            //OccuranceOfCharacterInString.SolveProblem("HelloWorld");
            ////OccuranceOfCharacterInString.SolveProblemUsingArray("HelloWorld");
            //SortStringByNumber.SolveProblem("is2 Thi1s T4est 3an are2");
            //"is2 Thi1s T4est 3an are"
            //"is2 Thi1s T4est 3an"
            //SortStringByNumber.SolveInAnotherWays("is2 Thi1s T4est 3an");



            //Console.WriteLine(SwapSetOfStringAndMatch.SolveProblem("aa", "aa"));
            //MinFrequencyAndCountOfFrequency.SolveProblem("faabcdaabepnp");
            Console.ReadLine();
        }

        private static void SubSetSum()
        {
            SubsetSumProblem subsetSum = new SubsetSumProblem();
            subsetSum.SolveProblem(new[] { 0, 1, 2, 5, 7 }, 8);
        }

        private static void Excel()
        {
            ExcelColumnNameFind excel = new ExcelColumnNameFind();
            excel.SolveProblem(78);
        }

        private static void Factorial()
        {
            Factorial factorial = new Factorial();
            factorial.SolveProblem(10);
        }

        private static void LIS()
        {
            LongestIncreasingSubsequenceProblem longest = new LongestIncreasingSubsequenceProblem();
            //longest.SolveProblem(new[] { 3, 10, 2, 1, 20 });
            longest.SolveProblem(new[] { 0, 4, 12, 2, 10, 6, 9, 13, 3, 11, 7, 15 });
            //longest.SolveProblem(new[] { 50, 3, 10, 7, 40, 80 });
        }

        private static void Kadane()
        {
            var kadane = new KadaneAlgorithm();
            kadane.SolveProblem(new[] { 4, 3, -2, 2, 3, 1, -2, -3, 4, 2, -6, -3, -1, 3, 1, 2 });
        }

        private static void Knapsack()
        {
            var knapsack = new KnapSackProblem();
            knapsack.SolveProblem();
            Console.ReadLine();
        }

        private static void CoinProblem()
        {
            var coin = new CoinChangeProblem();
            coin.FindCombination(2, 5);
        }

        private static void FibonacciSeries()
        {
            Console.Write("Enter the nth number of the Fibonacci Series: ");
            int number = Convert.ToInt32(Console.ReadLine());
            //number = number + 1;
            //We have to increment the length because the series starts with 0
            StairCaseProblem stairCaseProblem = new StairCaseProblem();
            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine(stairCaseProblem.ReturnWays(i));
            }
            //stairCaseProblem.ReturnWaysSimple(number);
        }
    }
}
