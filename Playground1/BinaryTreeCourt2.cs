using System;
using System.Collections.Generic;
using BinaryTreeCourt2.DataStructures;
using Playground1.DataStructures;


namespace BinaryTreeCourt2.DataStructures
{
    public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
    
}

namespace Playground1 {
    public class BinaryTreeCourt2 {
        public void Play() {
            var generatedTree = BuildTreeFromPreOrderInOrder(new int[]{3,9,20,15,7}, new int[]{9,3,15,20,7});
            
            var node = new Node(1);
            node.left = new Node(2);
            node.left.left = new Node(4);
            node.left.right = new Node(5);
            node.right = new Node(3);
            node.right.left = new Node(6);
            node.right.right = new Node(7);
            var connectedNode = Connect(node);
        }
        
        public Node Connect(Node root) {
        if(root == null) return null;
        var queue = new Queue<Node>();
        var list = new List<Node>();
        queue.Enqueue(root);
        queue.Enqueue(null);
        while(queue.Count > 0) {
            var curNode = queue.Dequeue();
            list.Add(curNode);
            if(curNode == null) {
                if(queue.Count > 0) {
                    queue.Enqueue(null);
                    continue;
                } else {
                    break;
                }
            }
            if(curNode.left != null)
            queue.Enqueue(curNode.left);
            if(curNode.right != null)
            queue.Enqueue(curNode.right);
        }
        
        for(int i = 0; i < list.Count - 1; i++) {
            if(list[i] == null) continue;
            list[i].next = list[i+1];
        }
        
        return root;
    }
        
        int currentPreOrderTraversalIndex;
        public BinaryTreeNode BuildTreeFromPreOrderInOrder(int[] preorder, int[] inorder) {
            currentPreOrderTraversalIndex = 0;
            var dict = new Dictionary<int, int>();
            
            for(int i =0; i < inorder.Length; i++) {
                dict.Add(inorder[i], i);
            }
            var root = BuildTreeFromPreOrderInOrderHelper(preorder, inorder, dict, 0, inorder.Length - 1);
            
            return root;
        }
        
        private BinaryTreeNode BuildTreeFromPreOrderInOrderHelper(int[] preorder, int[] inorder, Dictionary<int,int> dict, int low, int high) {
            if(low > high) return null;
            var currentRootVal = preorder[currentPreOrderTraversalIndex];
            var mid = dict[currentRootVal];
            var root = new BinaryTreeNode(currentRootVal);
            currentPreOrderTraversalIndex++;
            root.left = BuildTreeFromPreOrderInOrderHelper(preorder, inorder, dict, low, mid - 1);
            root.right = BuildTreeFromPreOrderInOrderHelper(preorder, inorder, dict, mid + 1, high);
            
            return root;
        }
        
        
        
        int currentPOIndex;
         
         public BinaryTreeNode BuildTreeFromInOrderPostOrder(int[] inorder, int[] postorder) {
             Dictionary<int,int> dict = new Dictionary<int, int>();
             for(int i = 0; i < inorder.Length; i++) {
                 dict.Add(inorder[i], i);
             }
             currentPOIndex = postorder.Length - 1;
             
             var tree = BuildTree(inorder, postorder, dict, 0, inorder.Length - 1);
             return tree;
         }
         
         private BinaryTreeNode BuildTree(int[] inorder, int[] postorder, Dictionary<int,int> dict, int low, int high) {
             if (low > high) return null;
             var currentRootVal = postorder[currentPOIndex];
             var root = new BinaryTreeNode(currentRootVal);
             currentPOIndex--;
             var mid = dict[currentRootVal];
             root.right = BuildTree(inorder, postorder, dict, mid + 1, high);
             root.left = BuildTree(inorder, postorder, dict, low, mid - 1);
             
             return root;
         }
         
         int totalUnivalSubtreeCount = 0;
         public int CountUnivalSubtrees(BinaryTreeNode root) {
             //A tree is a unival tree if both it's left and right children are unival subtrees.
             //We solve this problem with this idea...
             IsUnivalSubtreeHelper(root);
             return totalUnivalSubtreeCount;
         }
         
         public bool IsUnivalSubtreeHelper(BinaryTreeNode root) {
             if (root == null) return true;
             //Check if left is Unival tree with current node
             var isLeftUnivalSubtree = IsUnivalSubtreeHelper(root.left) && (root.val ==  (root.left == null ? root.val : root.left.val));
             //Check if right is Unival tree with current node
             var isRightUnivalSubtree = IsUnivalSubtreeHelper(root.right) && (root.val ==  (root.right == null ? root.val : root.right.val));
             if(isLeftUnivalSubtree && isRightUnivalSubtree) {
                 totalUnivalSubtreeCount++;
                 return true;
             }
             return false;
         }
         
         public IList<IList<int>> LevelOrder(BinaryTreeNode root) {
             //Use a Queue
             var list = new List<IList<int>>();
             if(root == null) return list;
             Queue<BinaryTreeNode> queue = new Queue<BinaryTreeNode>();
             queue.Enqueue(root);
             queue.Enqueue(null);
             var tempList = new List<int>();
             while(queue.Count > 0) {
                 var curNode = queue.Dequeue();
                 if(curNode == null) {
                     //Level is done
                     list.Add(tempList);
                     tempList = new List<int>();
                     if(queue.Count == 0) {
                         break;
                     } else {
                         queue.Enqueue(null);
                         continue;
                     }
                 }
                 tempList.Add(curNode.val);
                 if(curNode.left != null) 
                    queue.Enqueue(curNode.left);
                if(curNode.right != null)
                    queue.Enqueue(curNode.right);
             }
             
             return list;
         }   
        
        //  public BinaryTreeNode InorderSuccessor(BinaryTreeNode root, BinaryTreeNode p) {
        //      List<BinaryTreeNode> list = new List<BinaryTreeNode>();
        //      InOrderSuccessorHelper(root, list);
        //      for(int i = 0; i < list.Count - 1; i++) {
        //          if(list[i].val == p.val) {
        //              return list[i+1];
        //          }
        //      }
             
        //      return null;
        //  }
         
        //  private void InOrderSuccessorHelper(BinaryTreeNode root, List<BinaryTreeNode> list) {
        //      if(root == null) return;
        //      InOrderSuccessorHelper(root.left, list);
        //      list.Add(root);
        //      InOrderSuccessorHelper(root.right, list);
        //  }
        
         public bool IsValidBST(BinaryTreeNode root) {
             var list = new List<int>();
             InorderTraversedListHelper(root, list);
             var prev = Int64.MinValue;
             foreach(var num in list) {
                 if(num <= prev) return false;
                 prev = num;
             }
            return true;
        }
        
        public void InorderTraversedListHelper(BinaryTreeNode root, List<int> list) {
            if(root == null) return;
            InorderTraversedListHelper(root.left, list);
            list.Add(root.val);
            InorderTraversedListHelper(root.right, list);
        }
        
        public int MaxDepth(BinaryTreeNode root) {
            var maxDepth = MaxDepthHelper(root, 0);
            
            return maxDepth;
        }
        
        private int MaxDepthHelper(BinaryTreeNode root, int curDepth) {
            if(root == null) return curDepth;
            var depthOfLeftTree = MaxDepthHelper(root.left, curDepth + 1);
            var depthOfRightTree = MaxDepthHelper(root.right, curDepth + 1);
            
            return Math.Max(depthOfLeftTree, depthOfRightTree);
        }
        
        public BinaryTreeNode SearchBST(BinaryTreeNode root, int val) {
            if(root == null) return null;
            if(root.val == val) return root;
            if (val < root.val) {
                return SearchBST(root.left, val);
            } 
            return SearchBST(root.right, val);
        }
        
        public BinaryTreeNode InvertTree(BinaryTreeNode root) {
            InvertTreeHelper(root);
            return root;
        }
        
        public void InvertTreeHelper(BinaryTreeNode root) {
            if(root == null) return;
            var temp = root.left;
            root.left = root.right;
            root.right = temp;
            InvertTreeHelper(root.left);
            InvertTreeHelper(root.right);
        }
        
         public bool HasPathSum(BinaryTreeNode root, int targetSum) {
             var hasPathSum = HasPathSum(root, targetSum, 0);
             return hasPathSum;
         }
         
         public bool HasPathSum(BinaryTreeNode root, int targetSum, int currentSum) {
             if (root == null) return false;
             if(root.left == null && root.right == null) {
                 //leaf
                 if (targetSum == currentSum + root.val) return true;
                 return false;
             }
             currentSum += root.val;
             return HasPathSum(root.left, targetSum, currentSum) || HasPathSum(root.right, targetSum, currentSum);
         }
        
        public bool IsSymmetric(BinaryTreeNode root) {
            if(root == null) return true;
            var isSymmetric = IsSymmetric(root.left, root.right);
            return isSymmetric;
        }
        
        public bool IsSymmetric(BinaryTreeNode left, BinaryTreeNode right) {
            if (left == null && right == null) return true;
            if(left == null || right == null) return false;
            if(left.val != right.val) return false;
            if(IsSymmetric(left.left, right.right) && IsSymmetric(left.right, right.left)) return true;
            return false;
        }
        
        //  public IList<int> PostorderTraversal(BinaryTreeNode root) {
        //      var list = new List<int>();
        //      PostOrderTraversal(root, list);
        //     return list;
        // }
        
         public IList<int> PostorderTraversal(BinaryTreeNode root) {
             var list = new List<int>();
             //Using Iterative Method
             var stack = new Stack<BinaryTreeNode>();
             while(root != null || stack.Count > 0) {
                 while(root != null) {
                     stack.Push(root);
                     root = root.left;
                 }
                 var cur = stack.Pop();
                 list.Add(cur.val);
             }
            return list;
        }
        
        // private void PostOrderTraversal(BinaryTreeNode root, List<int> list) {
        //     if (root == null) return;
        //     PostOrderTraversal(root.left, list);
        //     PostOrderTraversal(root.right, list);
        //     list.Add(root.val);
        // }
        
        public IList<int> PreorderTraversal(BinaryTreeNode root) {
            var list = new List<int>();
            var stack = new Stack<BinaryTreeNode>();
            stack.Push(root);
            while(stack.Count > 0) {
                var cur = stack.Pop();
                list.Add(cur.val);
                if(cur.right != null)
                    stack.Push(cur.right);
                if(cur.left != null)
                    stack.Push(cur.left);
            }
            return list;
        }
        
        
        
        //  public IList<int> InorderTraversal(BinaryTreeNode root) {
        //     var list = new List<int>(); 
        //     InorderTraversal(root, list);
            
        //     return list;   
        // }
        
        public IList<int> InorderTraversal(BinaryTreeNode root) {
            var list = new List<int>(); 
            //In order travsersal Using Stack
            var stack = new Stack<BinaryTreeNode>();
            while(stack.Count > 0 || root != null) {
                while(root != null) {
                    stack.Push(root);
                    root = root.left;
                }
                var cur = stack.Pop();
                list.Add(cur.val);
                root = cur.right;
            }
            
            return list;   
        }
        
         public void InorderTraversal(BinaryTreeNode root, List<int> list) {
            if (root == null) return;
            InorderTraversal(root.left, list);
            list.Add(root.val);
            InorderTraversal(root.right, list);
        }
        
        //  public void InorderTraversal(BinaryTreeNode root, List<int> list) {
        //     if (root == null) return;
        //     InorderTraversal(root.left, list);
        //     list.Add(root.val);
        //     InorderTraversal(root.right, list);
        // }
    }    
}