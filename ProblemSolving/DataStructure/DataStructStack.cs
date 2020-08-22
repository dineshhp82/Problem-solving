using ProblemSolving.Utilties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProblemSolving.DataStructure
{
    /* Stack and Queue is (Conceptual) abstract data structure bcasue they implemented with
     * the help of array or linked list.
     * 
     * where as link list real DS 
     *  LIFO Last in First out
     * I  V PUSH(5) I  V PUSH(9) I  V PUSH(11) I V       POP() I V      PEEK  I  V
     * 4  0         4  0         4  0          4 0             4 0            4  0
     * 3  0         3  0         3  0          3 0             3 0            3  0
     * 2  0         2  0         2  0          2 11 top=2      2 0            2  0
     * 1  0         1  0         1  9 top =1   1 9             1 9 top =1     1  9 top=1 
     * 0  0         0  5 top=0   0  5          0 5             0 5            0  5
     * initial => top=-1;
     * 
     * 
     *  
     *  PUSH O(1) => Insert item in stack call PUSH  top++;
     *  POP  O(1)=>Get/take out item from stack call  POP return top element of the stack. top--
     *  
     *  PEEK O(1) =>Read top most value of stack WITHOUT removing it. top
     *  
     *  if top reach  -1 then stack is empty
     */
    public class DataStructStack
    {
        int[] values = null;
        int top = -1;
        public DataStructStack(int numberOfItem)
        {
            values = new int[numberOfItem];
        }
        public void Push(int item)
        {
            if (top == values.Length - 1)
            {
                Console.WriteLine("stack is full");
                return;
            }
            top++;
            values[top] = item;
            values.PrintArray("Push ");

        }
        public void Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("stack is empty");
                return;
            }
            values[top] = 0;
            top--;

            values.PrintArray("Pop ");

        }

        public void Peek()
        {
            values.PrintArray("Peek ");
            if (top == -1)
            {
                Console.WriteLine("stack is empty");
            }
            Console.WriteLine("Current top item" + values[top]);
        }
    }

    public class Simulator
    {
        public static void Simulate()
        {
            DataStructStack stack = new DataStructStack(5);
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);
            stack.Push(50);
            stack.Push(60);

            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();

            stack.Push(60);
            stack.Peek();
            stack.Peek();


        }
    }
}
