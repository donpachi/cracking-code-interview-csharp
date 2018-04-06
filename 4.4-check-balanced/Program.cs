using System;

namespace _4._4_check_balanced
{
    /* Implement a function to check if a binary tree is balanced. 
    -A balanced tree is such that the heights of the two subtrees of any node never 
    differ by more than one
    THOUGHTS: recurse through the tree; on the return stack, pass the height of the node to 
    its parent, and the parent will check left and right subtree heights and ensure they 
    only differ by at most 1 */
    class Program
    {
        public class TreeNode{
            public TreeNode left;
            public TreeNode right;
        }

        /*At first, I thought using an exception to indicate a nonbalanced tree 
        would be a somewhat elegant method to perpetuate an erro value up the recursion
        tree. After consultation, this is generally bad practice and a general misuse of
        the exception patterns (antipattern). */
        class UnbalancedException : Exception{
            public UnbalancedException(){
            }
            public UnbalancedException(string message)
                : base(message)
            {}
        }

        //Do we need a recursive helper function?? I say so because we need to keep track
        //of heights as we return through the call stack, but we ultimately return a boolean 
        //to indicate if tree is balanced or not. To keep track of non balance, we can use a catch
        public bool IsTreeBalanced(TreeNode root){
            int? heightDiff = CheckBalance(root);
            return (heightDiff == null) ? false : true;
        }

        int? CheckBalance(TreeNode node){
            //base case
            if (node == null) return -1;
            int? left = CheckBalance(node.left);
            if (left == null) return null;
            int? right = CheckBalance(node.right);
            if (right == null) return null;
            int diff = Math.Abs(left.Value - right.Value);
            return (diff > 1) ? null : Math.Max(left.Value, right.Value);
        }

        static void Main(string[] args)
        {
        }
    }
}
