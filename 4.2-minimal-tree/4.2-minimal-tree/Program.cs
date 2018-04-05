using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._2_minimal_tree
{
    /* Given a sorted (increasing order) array with unique integer elements, 
     * write an algorithm to create a binary search tree with minimal height
     * THOUGHTS: array is sorted in increasing order with **UNIQUE** (this is important), this means the creation is somewhat trivial;
     * the root of a balanced tree(which is also minimum height) will have at best, half the elements in the left subtree and the other half in the right subtree.
     * Partition the array exactly in the middle (index-wise, not value-wise), middle value will be the local root, and then send the other halves of the array
     * down to the left and right children to create themselves.
     */
    class Program
    {
        public class BSTNode
        {
            public BSTNode Left { get; set; }
            public BSTNode Right { get; set; }
            public int Value { get; set; }
            public BSTNode(int v) { Value = v; }
        }

        public BSTNode CreateMinimalBST(int[] arr)
        {
            if (arr.Length == 0) return null;
            return CreateMinimalBST(arr, 0, arr.Length - 1);
        }

        public BSTNode CreateMinimalBST(int[] arr, int start, int end)
        {
            //recursion base case
            if (start > end) return null;
            //get the middle index to create a node with
            int mid = (start + end) / 2;
            BSTNode node = new BSTNode(arr[mid]);
            node.Left = CreateMinimalBST(arr, 0, mid - 1);
            node.Right = CreateMinimalBST(arr, mid + 1, end);
            return node;
        }

        static void Main(string[] args) { }
    }
}
