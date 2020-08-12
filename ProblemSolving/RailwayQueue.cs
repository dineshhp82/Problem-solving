using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving
{
    public class RailwayQueue
    {

        public void PerformOperation()
        {

            EnqueueCustomer(10);
            EnqueueCustomer(11);
            EnqueueCustomer(12);
            EnqueueCustomer(13);
            EnqueueCustomer(14);
            EnqueueCustomer(15);
            Display();
            for (int i = 0; i < customerIds.Length; i++)
            {
                DequeueCustomer();
                Console.WriteLine("==============");
                Display();
            }
        }



        //FIFO

        /*  Tail(Rare)=>Head(Front)
         *  [5]->[4]->[3]->[2]->[1]->Counter
         *  [4]->[3]->[2]->[1]->[0]->Index
         *  --------------------------------
         *  Initial both are at same position say T=H=0;
         *  Enqueue mean add element at tail position T++
         *  Deque mean remove element at head positon H++;
         *  
         *  Enqueue  
         *  [1]=>Counter
            [2]->[1]=>Counter
            [3]->[2]->[1]=>Counter

            Dequeue
            [3]->[2]->[1]=>Counter
            [3]->[2]=>Counter
            [3]=>Counter
         */

        int[] customerIds = new int[5];

        int tail = 0; int head = 0;

        public void EnqueueCustomer(int custId)
        {
            if (tail == customerIds.Length)
            {
                Console.WriteLine("Queue is full..");
                return;
            }

            customerIds[tail++] = custId;

        }

        public void DequeueCustomer()
        {
            if (head == customerIds.Length + 1)
            {
                Console.WriteLine("Queue is empty..");
                return;
            }

            var custId = customerIds[head++];
            Console.WriteLine(custId);
        }

        public void Display()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Head<=");
            for (int i = 0; i < customerIds.Length; i++)
            {
                builder.Append(customerIds[i]);
                builder.Append("<=");
            }
            builder.Append("Tail");
            Console.WriteLine(builder.ToString());
        }


    }
}
