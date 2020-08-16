using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProblemSolving
{

    /*
     B-Tree/Binary Search Tree/Balance Tree:

     Un-Balanced Tree:

     */
    public class BinarySearchTree
    {
        TreeNode rootNode;

        public void InsertNode(int data)
        {
            //no node in root
            if (rootNode == null)
            {
                rootNode = new TreeNode(data);
            }
            else
            {
                rootNode.Insert(data);
            }

        }

        public TreeNode FindNode(int data)
        {
            if (rootNode != null)
            {
                return rootNode.Find(data);
            }

            return null;
        }

        public TreeNode SoftDelete(int data)
        {
            if (rootNode != null)
            {
                return rootNode.SoftDelete(data);
            }
            return null;
        }

        public int Largest => rootNode != null ? rootNode.LargestData() : 0;

        public int Smallest => rootNode != null ? rootNode.SmallestData() : 0;

        /* There are three scenrio for delete
         * -Delete leaf node has no child (null)
         * -Delete node has one child
         * -Delete node has two childern
         * 
         * But this is very complicated so we can use soft delete
         */
        public void DeleteNode(int data)
        {
            TreeNode current = rootNode;
            TreeNode parent = rootNode;

            //keep track the behaviour of tree 
            bool isLeftChild = false;

            //no node in tree
            if (current == null)
            {
                return;
            }

            //find the node in tree
            while (current != null && current.Data != data)
            {
                parent = current;

                if (data < current.Data)
                {
                    current = current.LeftChild;
                    isLeftChild = true;
                }
                else
                {
                    current = current.RightChild;
                    isLeftChild = false;
                }
            }

            //delete
            if (current == null)
            {
                return;
            }

            // CASE -1 => leaf node
            //Leaf node has no right left child
            if (current.LeftChild == null && current.RightChild == null)
            {
                //root node 
                if (current == rootNode)
                {
                    rootNode = null;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.LeftChild = null;
                    }
                    else
                    {
                        parent.RightChild = null;
                    }
                }

            }

            //CASE -2 => only one child either left or right

            //right null mean child in left
            else if (current.RightChild == null)
            {
                if (current == rootNode)
                {
                    rootNode = current.LeftChild;
                }
                else if (isLeftChild)
                {
                    parent.LeftChild = current.LeftChild;
                }
                else
                {
                    parent.RightChild = current.LeftChild;
                }
            }
            //lrft null mean child in right
            else if (current.LeftChild == null)
            {
                if (current == rootNode)
                {
                    rootNode = current.RightChild;
                }
                else if (isLeftChild)
                {
                    parent.LeftChild = current.RightChild;
                }
                else
                {
                    parent.RightChild = current.RightChild;
                }
            }




            //restructure


        }

        public void GetTraverseTree() => rootNode?.TraverseInOrderTree();

        public int TreeHeight => rootNode != null ? rootNode.HeightOfTree() : 0;

        public int TotalLeafNode => rootNode != null ? rootNode.TotalLeafNode() : 0;
    }

    /*   Node contain data,leftchild and rightchild ref.
     *   
     *   Find Node is comparsion recursive operation from root node to travel down.
     */
    public class TreeNode
    {
        public int Data { get; }

        public TreeNode LeftChild { get; set; }

        public TreeNode RightChild { get; set; }

        public bool IsDeleted { get; set; }

        public TreeNode(int data)
        {
            this.Data = data;
        }

        /*             15(node)
         *     < 10(left)   17(right)   >
         * 
         * -this.data==inputData(input) > return this
         * -inputData<this.data && this.Leftchild !=null(leaf node) return leftchild.find(data); rec.
         * -inputData>this.data && this.RightChild !=null(leaf node) return rightchild.find(data); rec.
         * -return null;
         */
        public TreeNode Find(int inputData)
        {
            if (Data == inputData && !IsDeleted)
            {
                return this;
            }

            if (inputData < Data && LeftChild != null)
            {
                return LeftChild.Find(inputData);
            }

            if (inputData > Data && RightChild != null)
            {
                return RightChild.Find(inputData);
            }

            return null;
        }

        public void Insert(int inputData)
        {
            //Right input>= root value 
            if (inputData >= Data)
            {
                if (RightChild == null) //this is termination condition to add node cause its a leaf node
                {
                    RightChild = new TreeNode(inputData);
                }
                else
                {
                    RightChild.Insert(inputData); //Recursive call the insert
                }
            }

            //Left
            if (inputData <= Data)
            {
                if (LeftChild == null) //this is termination condition to add node cause its a leaf node
                {
                    LeftChild = new TreeNode(inputData);
                }
                else
                {
                    LeftChild.Insert(inputData);//Recursive call the insert
                }
            }
        }

        public TreeNode SoftDelete(int inputData)
        {
            TreeNode node = Find(inputData);
            node.IsDeleted = true;
            return node;
        }

        //most left node always smallest value
        public int SmallestData()
        {
            if (LeftChild == null)
            {
                return Data;
            }
            return LeftChild.SmallestData();

        }
        //most right node always largest value
        public int LargestData()
        {
            if (RightChild == null)
            {
                return Data;
            }
            return RightChild.LargestData();
        }

        public void TraverseInOrderTree()
        {
            //Left
            if (LeftChild != null)
            {
                LeftChild.TraverseInOrderTree();
            }
            //Action
            Console.WriteLine(this.Data + " ");
            //Right
            if (RightChild != null)
            {
                RightChild.TraverseInOrderTree();
            }
        }

        //Height mean how many layer.
        // +1 because root node 
        public int HeightOfTree()
        {
            int left = 0;
            int right = 0;
            if (IsLeafNode)
            {
                return 1;
            }

            if (LeftChild != null)
            {
                left = LeftChild.HeightOfTree();
            }

            if (RightChild != null)
            {
                right = RightChild.HeightOfTree();
            }

            return left > right ? left + 1 : right + 1;

        }

        public int TotalLeafNode()
        {
            int leftLeaves = 0;
            int rightLeaves = 0;
            if (IsLeafNode)
            {
                return 1;
            }
            //termination condition on left tree/subtree
            if (LeftChild != null)
            {
                leftLeaves = LeftChild.TotalLeafNode();
            }
            //termination condition on right tree/subtree
            if (RightChild != null)
            {
                rightLeaves = LeftChild.TotalLeafNode();
            }
            return leftLeaves + rightLeaves;
        }

        public bool IsLeafNode => LeftChild == null && RightChild == null;

    }

    public class TreeSimulator
    {
        public static void Simulate()
        {
            BinarySearchTree binarySearchTree = new BinarySearchTree();

            Console.WriteLine("Insert values");
            var values = new int[] { 30, 12, 32, 1, 34, 14, 18, 31 };

            /*       30 
             *   12     32
             * 01  14  31   34  
             *       18       
             *         
             *         
             */
            foreach (var item in values)
            {
                binarySearchTree.InsertNode(item);
                Console.WriteLine(item);
            }
            Console.WriteLine("End Insert");

            binarySearchTree.GetTraverseTree();

            var node = binarySearchTree.FindNode(18);
            if (node != null)
            {
                Console.WriteLine($"Data :{node.Data} IsLeafNode { node.IsLeafNode} IsDeleted {node.IsDeleted}");
            }
            else
            {
                Console.WriteLine("Not Found");
            }

            binarySearchTree.SoftDelete(34);
            var deleteNode = binarySearchTree.FindNode(34);
            if (deleteNode != null)
            {
                Console.WriteLine($"Data :{deleteNode.Data} IsLeafNode { deleteNode.IsLeafNode} IsDeleted {deleteNode.IsDeleted}");
            }
            else
            {
                Console.WriteLine("Not Found");
            }


            Console.WriteLine("Largest :=>" + binarySearchTree.Largest);
            Console.WriteLine("Smallest :=>" + binarySearchTree.Smallest);
            Console.WriteLine("Total Leaf Node :=>" + binarySearchTree.TotalLeafNode);
            Console.WriteLine("Height :=>" + binarySearchTree.TreeHeight);


        }
    }

}
