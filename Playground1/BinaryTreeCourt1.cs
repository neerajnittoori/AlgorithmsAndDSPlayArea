using Playground1.DataStructures;
using BinaryTreeCourt1.HelperClasses;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTreeCourt1.HelperClasses
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
}




namespace Playground1
{
    public class BinaryTreeCourt1
    {
        public void Play()
        {
            // var binaryTreeNode = new BinaryTreeNode(1);
            // binaryTreeNode.left = new BinaryTreeNode(2);
            // binaryTreeNode.left.left = new BinaryTreeNode(4);
            // binaryTreeNode.left.right = new BinaryTreeNode(5);

            // binaryTreeNode.right = new BinaryTreeNode(3);
            // binaryTreeNode.right.left = new BinaryTreeNode(6);
            // binaryTreeNode.right.right = new BinaryTreeNode(7);
            // var listOfBinaryTreeNodes = PrintBinaryTreeNodesInLevelOrder(binaryTreeNode);

            var binaryTreeNode = new Node(1);
            binaryTreeNode.left = new Node(2);
            binaryTreeNode.left.left = new Node(4);
            binaryTreeNode.left.right = new Node(5);

            binaryTreeNode.right = new Node(3);
            binaryTreeNode.right.left = new Node(6);
            binaryTreeNode.right.right = new Node(7);
            var connectedNode = Connect(binaryTreeNode);
        }

        public List<List<int>> PrintBinaryTreeNodesInLevelOrder(BinaryTreeNode root) {
            List<List<int>> list = new List<List<int>>();
            if (root == null) return list;

            Queue<BinaryTreeNode> queue = new Queue<BinaryTreeNode>();
            queue.Enqueue(root);
            queue.Enqueue(null);
            var tempList = new List<int>();
            while(queue.Count > 0) {
                var curNode = queue.Dequeue();
                if (curNode == null) {
                    //Level is done Add tempList to main list
                    list.Add(tempList);
                    if(queue.Count > 0) 
                        queue.Enqueue(null);
                    tempList = new List<int>();
                    continue;
                }
                tempList.Add(curNode.val);
                if(curNode.left != null)
                queue.Enqueue(curNode.left);
                if(curNode.right != null)
                queue.Enqueue(curNode.right);
            }

            return list;
        }

        public Node Connect(Node root)
        {
            if (root == null) return null;
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            queue.Enqueue(null);
            while(queue.Count > 0) {
                var curNode = queue.Dequeue();
                if(curNode == null) {
                    if(queue.Count > 0)
                        queue.Enqueue(null);
                    continue;
                }
                Node nextNode = null;
                if (queue.Count > 0)
                {
                    nextNode = queue.Peek();
                } 
                curNode.next = nextNode;
                if(curNode.left != null)
                queue.Enqueue(curNode.left);
                if(curNode.right != null)
                queue.Enqueue(curNode.right);
            }

            return root;
        }

        public BinaryTreeNode MergeTrees(BinaryTreeNode root1, BinaryTreeNode root2)
        {
            if (root1 == null && root2 == null) return null;
            if (root1 == null) return root2;
            if (root2 == null) return root1;

            var newTree = new BinaryTreeNode();
            newTree.val = root1.val + root2.val;

            newTree.left = MergeTrees(root1.left, root2.left);
            newTree.right = MergeTrees(root1.right, root2.right);

            return newTree;
        }

    }
}