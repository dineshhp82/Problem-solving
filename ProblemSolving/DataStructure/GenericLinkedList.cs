using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ProblemSolving
{
    /* Insert -> At Head,Tail,Between,Appended
     * Remove
     * Traverse
     * Find
     * Upate
     * Count
     */


    public class GenericLinkedList
    {
        public static void Start()
        {
            Console.WriteLine("====No of Coach Add=====");
            int noOfCoachAdd = Convert.ToInt32(Console.ReadLine());
            Train<CoachInfo> train = new Train<CoachInfo>();
            CoachInfo coachInfo = null;
            for (int i = 1; i <= noOfCoachAdd; i++)
            {
                coachInfo = new CoachInfo(i, "A");

                train.AddCoach(coachInfo);
            }

            train.DisplayTrain();

            Console.WriteLine("====Add Coach at Engine====");
            coachInfo = new CoachInfo(0, "B");
            train.AddCoachAtEngine(coachInfo);

            train.DisplayTrain();

            Console.WriteLine("====Add Coach at Last====");
            coachInfo = new CoachInfo(1, "C");
            train.AddCoachAtLast(coachInfo);

            train.DisplayTrain();

            Console.WriteLine("====Add Coach in Between====");
            coachInfo = new CoachInfo(4, "D");
            train.AddCoachInBetween(coachInfo, new CoachInfo(2, "A"));

            train.DisplayTrain();

            Console.WriteLine("====Remove Coach in Last====");
            coachInfo = new CoachInfo(1, "C");
            train.RemoveCoach(coachInfo);

            train.DisplayTrain();
        }


    }


    public class Train<T> where T : class
    {
        Coach<T> Engine;

        StringBuilder builder = null;

        public int TotalNoOfCoach { get; private set; }

        public Train()
        {
            Engine = new Coach<T>(null);

        }

        public void AddCoach(T value)
        {
            var newCoach = new Coach<T>(value);
            var tailNode = TailNode();
            tailNode.Next = newCoach;
            newCoach.Next = null;
            TotalNoOfCoach++;
        }

        public void AddCoachAtEngine(T value)
        {
            var headNext = Engine.Next;

            var newCoach = new Coach<T>(value);

            Engine.Next = newCoach;
            newCoach.Next = headNext;

            TotalNoOfCoach++;

        }

        public void AddCoachAtLast(T value)
        {
            var tailNode = TailNode();

            var newCoach = new Coach<T>(value);
            tailNode.Next = newCoach;
            newCoach.Next = null;

        }

        public void AddCoachInBetween(T value, T valueAfter)
        {
            var newCoach = new Coach<T>(value);

            var findNode = FindNode(valueAfter);
            var nextNode = findNode.Next;

            findNode.Next = newCoach;
            newCoach.Next = nextNode;
        }

        public void RemoveCoach(T value)
        {
            var findNode = FindNode(value);
            if (findNode == null)
            {
                Console.WriteLine("Coach No Found.....");
            }

            Coach<T> current = Engine;
            Coach<T> prev = null;

            while (current != null)
            {
                if (!current.Value.ToString().Equals(value.ToString()))
                {
                    prev = current;
                    current = current.Next;
                }
            }

            if (current.Next != null)
            {
                prev.Next = findNode.Next;
            }
            else
            {
                prev.Next = null;
            }
            TotalNoOfCoach--;
        }

        public void DisplayTrain()
        {
            builder = new StringBuilder();
            builder.Append("ENGINE=>");
            Coach<T> current = Engine;
            while (current.Next != null)
            {
                current = current.Next;
                builder.Append(current.Value);
                builder.Append("=>");

            }
            builder.Append("CLOSE");
            Console.WriteLine(builder.ToString());
        }

        private Coach<T> TailNode()
        {
            Coach<T> current = Engine;
            while (current.Next != null)
            {
                current = current.Next;
            }

            return current;
        }

        private Coach<T> FindNode(T value)
        {
            Coach<T> current = Engine;

            while (current != null)
            {
                if (current.Value == null)
                {
                    current = current.Next;
                    continue;
                }

                if (current.Value.ToString().Equals(value.ToString()))
                {
                    return current;
                }
                current = current.Next;
            }

            return null;
        }
    }


    public class Coach<T>
    {
        public T Value;
        public Coach<T> Next;

        public Coach(T value)
        {
            Value = value ?? default;
            Next = null;
        }
    }

    public class CoachInfo
    {
        public CoachInfo(
            int coachNumber,
            string coachClass)
        {
            CoachNumber = coachNumber;
            CoachClass = coachClass;
        }
        public int CoachNumber { get; }

        public string CoachClass { get; }

        public override string ToString()
        {
            return $"[{CoachNumber}: {CoachClass}]";
        }
    }
}
