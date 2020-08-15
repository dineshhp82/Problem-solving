using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace ProblemSolving
{
    /* LRU => Least Recent used
     Two data struct are used to implement LRU
        1) Dictionary
        2) Doubly linked List(DLL)
     Why:
     DLL is used becuase fast operation like insert,update and delete with O(1).
     Dictionary has O(1) operations on get and put opertion fast with O(1).

     The use of DLL is for item eviction polices.

     This DLL helps us achieve the LRU eviction strategy, where the objects accessed frequently 
     will be at the tail end and the objects accessed the least will be towards the head of the 
     listThis DLL helps us achieve the LRU eviction strategy, where the objects accessed frequently 
     will be at the tail end and the objects accessed the least will be towards the head of the list.



     Structure:
     Dic=>  |Key|Value   |
           |1  |Node    |
           |2  |Node    |
           |3  |Node    |
     Operation:
     Get : Get Value from dictionary 
                -if not found return "not found"
                -found the return and update the DLL front node
     
     Put : Put value in dictionary
            -Check value exist 
              -if exist the update value and update the front node of DLL
              -if not exist
                  -check capcity is full
                     #full=true
                        #remove rear node (LRU) and remove from dic also
                        #then insert new node in front of DLL and also add key-value in dic.
                     @full=false
                        @then insert new node in front of DLL and also add key-value in dic. 

    Important Point:

     */
    public class LRUCache<K, V>
    {
        public int Capcity { get; }

        Dictionary<K, Node<K, V>> dic { get; }

        DoublyLinkedList<K, V> doublyLinkedList;

        public LRUCache(int capcity)
        {
            Capcity = capcity;
            dic = new Dictionary<K, Node<K, V>>();
            doublyLinkedList = new DoublyLinkedList<K, V>();
        }


        /*Fetch the data from dictionary by key 
         * after fetch we need to update our D-LinkedList to make get node in front of list so that
         * it will denote the recent used node.
         * 
         */
        public Node<K, V> Get(K key)
        {
            var node = dic.TryGetValue(key, out var findNode)
                ? findNode
                : null;

            if (node == null)
            {
                return null;
            }
            doublyLinkedList.MoveNodeToFront(node);

            return dic[key];
        }

        /* Put mean to insert value
         * -first check if value already exist the we update that value
         * -If not exist the update that value
         * 
         * before insert new key we need to check capcity of D-Linked List full or not
         *  -if capcity is full then remove node from rear (mean Least recent used node) & 
         *   also remove this rear key from dictionary otherwise occpy the memeory
         *  
         *  -insert node at the front of d-linkedlist 
         
         */
        public void Put(K key, V value)
        {
            var currentNode = dic.TryGetValue(key, out var findNode)
               ? findNode
               : null;

            //Case when node already exist just update value and make recent used node
            if (currentNode != null)
            {
                currentNode.Value = value;
                doublyLinkedList.MoveNodeToFront(currentNode);

            }

            //when capcity is full  then remove rear item and also remove item from dic 
            if (dic.Count == Capcity)
            {
                var rearKey = doublyLinkedList.GetRearNodeKey();
                doublyLinkedList.RemoveNodeFromRear();
                dic.Remove(rearKey);
            }

            //create new node
            var newNode = new Node<K, V>(key, value);

            //insert new node in front of linked list
            doublyLinkedList.AddNodeInFront(newNode);
            //also add to dic.
            dic.Add(key, newNode);

        }

    }



    /* F<=[]=>R : inital both null
     * 
     * insert 1 front and rear same only single node 
     *  F<-[1]->R
     *  
     *  insert 2  
     *     new node rear is old front
     *     old front is new node
     *  
     *  F<-[2]=[1]->R
     * 
    */
    public class DoublyLinkedList<K, V>
    {
        Node<K, V> front;
        Node<K, V> rear;

        public DoublyLinkedList()
        {
            front = rear = null;
        }

        //if rear is null mean no node in DLL the front and rear both point to new node
        public void AddNodeInFront(Node<K, V> node)
        {
            if (rear == null)
            {
                front = rear = node;
                return;
            }

            node.next = front;
            front.prev = node;
            front = node;

        }

        public void MoveNodeToFront(Node<K, V> node)
        {
            if (front == node)
            {
                return;
            }

            // first detch the node  
            // second move the node front of the DLL
            //  [1]<->[2]<->[3] now detch '2' [1]<->[3] 

            /* 2(node by parma) hold the info of prev and next
             * 
             * so 1 prev need to point 3
             * and 3 next point to 1
             */

            //if current node is rear node 
            if (node == rear)
            {
                rear = rear.prev;
                rear.next = null;
            }
            else
            {
                node.prev.next = node.next; //2 prev node is 1 and 1 now point to node next 3 [1]->[3]
                node.next.prev = node.prev; //2 next node is 3 and now 3 point to 1 which is prev [1]<-[3]
            }

            //now move 2 to front  [2]<->[1]<->[3]
            //(P -> N)
            node.prev = null; //node prev is null becuase now its front and front node has no prev
            node.next = front; //node next is point to the existing front (1)
            front.prev = node; //existing front (1) prev is node
            front = node;//change new node to front

        }

        public void RemoveNodeFromRear()
        {
            // DLL is empty
            if (rear == null)
            {
                return;
            }

            Console.WriteLine("Delete item from rear:" + rear.Key);

            // Front=rear only one element in DLL
            if (front == rear)
            {
                front = rear = null;
            }
            else
            {
                rear = rear.prev;
                rear.next = null;
            }

        }

        public K GetRearNodeKey()
        {
            return rear.Key;
        }
    }

    public class Node<K, V>
    {
        public K Key { get; }
        public V Value { get; set; }

        public Node<K, V> prev, next;

        public Node(K key, V value)
        {
            Key = key;
            Value = value;
            prev = next = null;
        }

    }


    public class LRUSimulator
    {

        public static void Simulate()
        {
            LRUCache<string, int> lRUCache = new LRUCache<string, int>(3);

            lRUCache.Put("A", 10);
            lRUCache.Put("B", 20);
            lRUCache.Put("C", 30);
            lRUCache.Put("D", 20);

            lRUCache.Get("B");

            lRUCache.Put("E", 40);

        }
    }

}
