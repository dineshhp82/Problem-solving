using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace ProblemSolving
{
    /* op
     * 1) Insert
     * 2) Remove
     * 3) Find
     * 4) Travesr
     * 6) length
     * 8) update value
     
         
         */
    public class LinkedList
    {
        public LinkedListNode HeadNode;

        public int Count = 0;

        public LinkedList()
        {
            HeadNode = new LinkedListNode(0);
        }

        /* in order to remove node you must have ref of prev and next node.
         * first step is to find the prev and next node in list
         * [0|Node]=> Head Node
         * [1|Node]->[2|Node]->[3|Null]
         
            1) tail node remove set prev.next =>Null;
            2) head node remove 
               
         */
        public void RemoveNodeByValue(int value)
        {
            var findNode = FindNode(value);
            if (findNode == null)
            {
                Console.WriteLine("No not found...");
                return;
            }


            LinkedListNode current = HeadNode;
            LinkedListNode prev = null;

            Console.WriteLine("Length :" + Count);


            while (current.Value != value)
            {
                prev = current;//Store prev node
                current = current.Next; //store current node
            }

            if (current.Next != null)
            {
                //remove at head node
                //if prev =head node
                // [0|node]=[0|node]
                if (prev.Value == HeadNode.Value)
                {
                    HeadNode.Next = current.Next;
                }
                //in between
                prev.Next = current.Next;
            }
            else
            {
                //remove tail node
                prev.Next = null;
            }
            Count--;
            Console.WriteLine("Length after remove :" + Count);

        }

        /*  head->[0|null] 
         *  temp->[0|null]
         *  [1|null]
            temp.next => new node
            [0|node1]->[1|null]
            temp=[1|null]

            [2|null]
            temp.next=>new node
            [1|node2]->[2|null]
            temp=[2|null]



             */

        public void InsertNodes(int iCount)
        {
            //purpose if temp to retain the next ref otherwise it override existing ref if we do in head node.
            var temp = new LinkedListNode(0);
            temp = HeadNode;

            for (int i = 0; i < iCount; i++)
            {
                var val = Convert.ToInt32(Console.ReadLine());
                var newNode = new LinkedListNode(val);
                temp.Next = newNode;
                temp = temp.Next;
                Count++;
            }
        }

        /*
         *  Head Node=> [4|Next]
         *  now add new node before head node 3
         *  [3|Next]=>[4|Next]
         *  by doing this your 
         *  first create new node
         *  ref this new node to existing head node
         *  head node changed to new node becuase new node is head node
         *  
         */
        public void AddNodeAtTop(int value)
        {
            var newNode = new LinkedListNode(value);
            newNode.Next = HeadNode.Next;
            HeadNode.Next = newNode;
            Count++;
        }

        /*  find last node in linked list that has null ref. 
         *  suppose this is the last node [6|NULL] 
         *  now add new node at [7|NULL]
            
            steps
            create new node with value and null next node
            existing last node update next to new node
         */

        public void AddNodeAtBottom(int value)
        {
            var newNode = new LinkedListNode(value);
            newNode.Next = null;

            GetLastNode().Next = newNode;
            Count++;
        }


        /* suppose [5|Next]=>[7|Next]
         * add node in between 5 and 7 =>[6|Next]
         * find node 5  store in temp node=[5|Next]
         * create new node 6 and null value
         * find the next of temp which is 7 store it any var say nextOftemp
         * temp.Next=newNode; [5|Next=>newNode]
         * newNode.Next=temp.next; [6|Next=>nextOftemp]
         * 
         *             
        */

        public void AddNodeInBetween(int value, int valueAfter)
        {
            var tempNode = FindNode(valueAfter);
            var tempNext = tempNode.Next;

            var newNode = new LinkedListNode(value);
            tempNode.Next = newNode;
            newNode.Next = tempNext;
            Count++;

        }

        public LinkedListNode GetLastNode()
        {
            LinkedListNode current = HeadNode;
            while (current.Next != null)
            {
                current = current.Next;
            }
            return current;
        }


        public LinkedListNode FindNode(int Value)
        {
            LinkedListNode current = HeadNode;
            while (current != null)
            {
                if (current.Value == Value)
                {
                    return current;
                }
                current = current.Next;
            }
            return null;

        }

        public void PrintAllNodes()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Head -> ");
            LinkedListNode curr = HeadNode;
            while (curr.Next != null)
            {
                curr = curr.Next;
                stringBuilder.Append(curr.Value); //If using a reference type (any class/interface), you will need to override ToString for this to work.
                stringBuilder.Append(" -> ");
            }
            stringBuilder.Append("NULL");
            //stringBuilder.AppendLine();
            return stringBuilder.ToString();
        }
    }

    public class LinkedListNode
    {

        public LinkedListNode(int value)
        {
            Value = value;
            Next = null;
        }

        public int Value { get; }

        public LinkedListNode Next { get; set; }


    }

}
