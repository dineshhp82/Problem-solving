using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProblemSolving.DataStructure
{
    /* Insert
     * Delete
     * Find
     * Print
     * Count
     * Sorted
     */
    public class LinkedListRevise
    {
        private LinkedNode HeadNode;

        //Insert at head complaxity O(1)
        public void Insert(int value)
        {
            LinkedNode linkedNode = new LinkedNode(value);
            linkedNode.Node = HeadNode;
            HeadNode = linkedNode;
        }

        //Delete at head complaxity O(1)
        public void Delete()
        {
            HeadNode = HeadNode.Node;
        }

        public int Length => GetNodes().Count();

        public LinkedNode Find(int data)
        {
            return GetNodes().FirstOrDefault(x => x.Data == data);
        }

        public void Print()
        {
            string str = "[";
            foreach (var node in GetNodes())
            {
                str += node.Data + ",";
            }
            str += "]";
            Console.WriteLine(str);
        }

        public IEnumerable<LinkedNode> GetNodes()
        {
            LinkedNode current = HeadNode;
            while (current != null)
            {
                yield return current;
                current = current.Node;
            }
        }

        public void InsertInSortedLinked(int data)
        {
            LinkedNode newNode = new LinkedNode(data);

            foreach (var node in GetNodes())
            {
                if (node.Node != null && data >= node.Node.Data)
                {
                    LinkedNode currentNodeNext = node.Node;
                    node.Node = newNode;
                    newNode.Node = currentNodeNext;
                    break;
                }
            }
        }

        public class LinkedNode
        {
            public LinkedNode Node { get; set; }

            public int Data { get; }

            public LinkedNode(int data)
            {
                Data = data;
            }
        }
    }

    public class LinkedListDemo
    {
        public static void Demo()
        {
            LinkedListRevise listRevise = new LinkedListRevise();


            listRevise.Insert(10);
            listRevise.Insert(20);
            listRevise.Insert(30);
            listRevise.Insert(50);
            listRevise.Insert(60);

            listRevise.InsertInSortedLinked(40);

            listRevise.Print();

            Console.WriteLine("Length =>" + listRevise.Length);

            listRevise.Delete();
            Console.WriteLine("After delete:");
            listRevise.Print();
            Console.WriteLine("Length after delete =>" + listRevise.Length);

            var node = listRevise.Find(130);
            if (node != null)
            {
                Console.WriteLine("Node Found");
            }
            else
            {
                Console.WriteLine("Node not found");
            }
        }
    }
}
