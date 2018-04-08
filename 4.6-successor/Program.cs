using System;

namespace _4._6_successor
{
    /*Given a node in a bst, write an algorithm to find its inorder successor
        Assume nodes have links to their parents
    THOUGHTS:
    1. Inorder means to visit the left subtree, current node, then right subtree
    2. What if no left subtree? successor will be the leftmost node in the right subtree
    3. What if no right subtree? successor will be the first node up the tree
        where we're recursing back from the left subtree*/
    class Program
    {
        public class TreeNode{
            public TreeNode left;
            public TreeNode right;
            public TreeNode parent;
            public int Value {get; set;}
        }

        public TreeNode FindInorderSuccessor(TreeNode node){
            if (node == null) return null;
            //if right subtree exists, get leftmost node. (if no immediate left subtree of right child exists, right child is successor)
            if (node.right != null)
                return FindLeftmostChild(node.right);
            else{
                //traverse up while we're on the right subtree of our parents
                TreeNode temp = node;
                TreeNode parent = node.parent;
                //this while loop also handles the case of, if we're at the very end of our inorder traversal, 
                //return the parent of the root which is null
                while(parent != null && temp == parent.right){
                    temp = parent;
                    parent = parent.parent;
                }
                return parent;
            }
        }

        private TreeNode FindLeftmostChild(TreeNode node){
            if(node == null) return null;
            while(node.left != null){
                node = node.left;
            }
            return node;
        }

        static void Main(string[] args)
        {
            Program prog = new Program();
            TreeNode root = new TreeNode();
            root.Value = 3;
            root.right = new TreeNode();
            root.right.Value = 4;
            root.right.parent = root;
            Console.WriteLine(prog.FindInorderSuccessor(root.right).Value);
        }
    }
}
