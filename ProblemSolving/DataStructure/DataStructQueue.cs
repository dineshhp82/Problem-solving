using ProblemSolving.Utilties;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving.DataStructure
{
    /*
     *   HEAD ---------------------TAIL
     *   at starting both head and tail is at -1;
     *   
     *   Enqueue => Item add from tail to head => tail ++ (must check max limit reach)
     *   Dequeue => Item remove from head  => head++ and make dequeue element 0/null 
     *   Peek    => Item read from head  => read head value
     *   
     *   what happen for empty space at head after dequeue item?
     *   how to check empty space  abs(head-tail)< max
     *   
     *   0 1 2 3 4 5 6
     *   0 0 0 6 7 9 2
     *         H     T
     *   enqueue item 8
     *   8 0 0 6 7 9 2
     *   T     H
     *   
     *   enqeue item 3
     *   8 3 0 6 7 9 2
     *     T   H
     *   
     *   This is called circular queue.
     * 
     
     */
    public class CircularQueue
    {
        int[] values = null;
        int head = -1;
        int tail = -1;

        int itemInQueue = 0;
        public CircularQueue(int numberOfItem)
        {
            values = new int[numberOfItem];
        }

        public void Enqueue(int item)
        {
            if (itemInQueue == values.Length)
            {
                Console.WriteLine("Queue is full");
                tail = 0;
                return;
            }

            if (head == -1 && tail == -1)
            {
                head = tail = 0;
            }

            values[tail] = item;
            tail++;
            itemInQueue++;
            values.PrintArray("Enqueue ");

        }

        public void Dequeue()
        {
            if (itemInQueue == 0)
            {
                Console.WriteLine("Queue is empty");
                head = 0;
                return;
            }


            if (head == values.Length)
            {
                head = 0; tail = 0;
            }


            values[head] = 0;
            head++;
            itemInQueue--;
            values.PrintArray("Dequeue ");
        }

        public void Peek()
        {
            if (itemInQueue == 0)
            {
                Console.WriteLine("Queue is empty");
                head = 0;
                return;
            }

            Console.WriteLine("Value in Queue " + values[head]);
            values.PrintArray("Peek ");
        }
    }


    public class QueueSimulator
    {
        public static void SimpleQueueSimulate()
        {
            CircularQueue simple = new CircularQueue(5);
            simple.Enqueue(10);
            simple.Enqueue(20);
            simple.Enqueue(30);
            simple.Enqueue(40);
            simple.Enqueue(50);
            simple.Enqueue(60);

            simple.Dequeue();
            simple.Dequeue();
            simple.Dequeue();
            simple.Enqueue(90);
            simple.Dequeue();
            simple.Dequeue();
            simple.Dequeue();

            simple.Enqueue(60);
            simple.Enqueue(70);
            simple.Peek();
        }

    }
}
