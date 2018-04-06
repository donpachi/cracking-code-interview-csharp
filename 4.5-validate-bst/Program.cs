using System;

namespace _4._5_validate_bst
{
    /*Implement a function to check if a binary tree is a binary search tree
    THOUGHTS: a binary search tree is valid IFF all the nodes in the 
    left subtree have values less than the nodes in the right subtree 
    1. We could leverage in-order traversal since we know that in a BST, it will see values in strictly ascending order
    starting from that, we just need to keep track of the last last seen value, and compare it with the next node to look at.
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
    */
    class Program
    {
        static void Main(string[] args)
        {}
    }
}
