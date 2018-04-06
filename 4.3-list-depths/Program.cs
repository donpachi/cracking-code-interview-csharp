using System;
using System.Collections;
using System.Collections.Generic;

namespace _4._3_list_depths
{
    /* Given a binary tree, design an algorithm which creates a linked list of all the nodes at each depth
     * THOUGHTS: level-by-level (BFS) traversal first comes to mind. We could also traverse post order, making sure to keep track of what level we're at
     * 
     */
    class Program
    {
        public class TreeNode{
            public TreeNode left;
            public TreeNode right;
            public int val;
        }

        /*For each level we're at, add the current node to a linkedlist,
        add the node's children to a separate queue to iterate through later
        once the current nodes have all been iterated through, 
        iterate through the children queue */
        public IList<LinkedList<TreeNode>> BFSTraversal(TreeNode root){
            if(root == null) return null;
            List<LinkedList<TreeNode>> list = new List<LinkedList<TreeNode>>();
            //visit root
            LinkedList<TreeNode> current = new LinkedList<TreeNode>();
            current.AddLast(root);
            while(current.Count > 0){
                list.Add(current);
                LinkedList<TreeNode> children = new LinkedList<TreeNode>();
                foreach (TreeNode n in current){
                    if(n.left != null)
                        children.AddLast(n.left);
                    if(n.right != null)
                        children.AddLast(n.right);
                }
                current = children;
            }
            return list;
        }

        public IList<LinkedList<TreeNode>> PreOrderTraversal(TreeNode root){
            IList<LinkedList<TreeNode>> list = new List<LinkedList<TreeNode>>();    //data structure containing linked list of each level
            PreOrderTraversal(root, list, 0);
            return list;
        }
        
        void PreOrderTraversal(TreeNode node, IList<LinkedList<TreeNode>> list, int level){
            //base case
            if (node == null) return;
            if(list.Count == level){    //first occurence of this level, create a new linked list
                list.Add(new LinkedList<TreeNode>()); //add new instance of linked list to the array 
            }
            list[level].AddLast(node);  //insert this current node into the current level linked list representation
            PreOrderTraversal(node.left, list, level + 1);
            PreOrderTraversal(node.right, list, level + 1);
        }
        static void Main(string[] args)
        {
        }
    }
}
