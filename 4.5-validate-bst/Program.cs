using System;
using System.Collections;
using System.Collections.Generic;

namespace _4._5_validate_bst
{
    /*Implement a function to check if a binary tree is a binary search tree
    THOUGHTS: a binary search tree is valid IFF all the nodes in the 
    left subtree have values less than the nodes in the right subtree 
    1. We could leverage in-order traversal since we know that in a BST, it will see values in strictly ascending order. 
    Based on that, we just need to keep track of the last last seen value, and compare it with the next node to look at.
    if the new node has a value less than the last seen value, it is not a valid BST
                8
              /   \
             3    10
            / \  /  \
           1   4 5   * 
        the above is a binary tree that does not satisfy BST requirements
        in order traversal yields the following output: 
            1, 3, 4, 8, 5, 10
                        ^
                    our prev is 8, yet the next value to look at is less than 8 and thus the check fails

        Another approach is to use a localized search method and use the value of the local root to check for validity in the children
        This approach smells recursive
    */
    class Program
    {
        public TreeNode root;
        public class TreeNode{
            public TreeNode left;
            public TreeNode right;
            public int Value{get; set;}
        }

        public Program(){
            root = null;
        }

        public Program(int val){
            root = new TreeNode();
            root.Value = val;
        }

        public TreeNode Insert(int[] values){
            foreach(int n in values){
                Insert(root, n);
            }
            return root;
        }

        void Insert(TreeNode root, int val){
            if (root == null){
                this.root = new TreeNode();
                this.root.Value = val;
                return;
            }
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            //modified bfs to find empty spot
            while(q.Count > 0){
                root = q.Dequeue();
                if(root.left == null){
                    root.left = new TreeNode();
                    root.left.Value = val;
                    break;
                }
                else{
                    q.Enqueue(root.left);
                }
                if(root.right == null){
                    root.right = new TreeNode();
                    root.right.Value = val;
                    break;
                }
                else{
                    q.Enqueue(root.right);
                }
            }
        }

        public TreeNode GetTree(){return root;} 

        public bool CheckBalance(TreeNode root){
            return IsBalanced(root);
        }

        int? prev = null;
        bool IsBalanced(TreeNode node){
            if(node == null) return true;
            //recurse left
            if(!IsBalanced(node.left)) return false;
            //check current node
            if (prev != null && node.Value < prev) return false;
            prev = node.Value;  //set new previous data to be current node before going up the recursion tree
            //recurse right
            if(!IsBalanced(node.right)) return false;
            //if all checks pass, no false conditions seen, return true as default
            return true;
        }
        static void Main(string[] args)
        {
            Program myProg = new Program();
            TreeNode root = myProg.Insert(new int[]{1,2,7});
            Console.WriteLine(myProg.CheckBalance(root));
        }
    }
}
