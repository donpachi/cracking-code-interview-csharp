﻿using System;

namespace _8._3_magic_index
{
    /*a magic index in an array is defined to be an index such that A[i] == i. Given a sorted array of distinct integers find
    a magic index if it exists
    THOUGHTS:
        obvious brute force solution is to iterate through the entire array, searching for an index that satisfies the above condition
        the question says, "given a --sorted-- array". Lets leverage the sort first. First thing that comes to mind is a classic
        binary search. start at the middle of the array, and look at the value of the index vs the value at the index.
            Algorithm
                Binary search array,
                compare middle value with middle index
                    if value < index, search right half
                    if value > index, search left half 
                    if value == index, return index*/
    class Program
    {
        public int FindMagic(int[] sortedArr){
            if (sortedArr.Length == 0) return -1;
            return FindMagic(sortedArr, 0, sortedArr.Length - 1);
        }

        int FindMagic(int[] sortedArr, int left, int right){
            if (right < left) return -1;
            int midIndex = (right + left) / 2;
            int midValue = sortedArr[midIndex];
            if (midIndex == midValue) return midIndex;
            else if (midValue < midIndex) return FindMagic(sortedArr, midIndex + 1, right);
            else return FindMagic(sortedArr, left, midIndex - 1);
        }

        /* **FOLLOW UP** What if values are not distinct???  
        -2,1,1,2,2,3,4 
        We can't rely on the mid value anymore. However, observe that if
        A[i] > i, the value of A[i] is the largest/smallest index that a magic number can occur at
        but we still need to search both sides of the partition. <- Recursion?
        Let's partition search */
        int FindMagicNonDistinct(int[] arr){
            return FindMagicNonDistinct(arr, 0, arr.Length - 1);
        }

        int FindMagicNonDistinct(int[] arr, int left, int right){
            //base case
            if (left > right) return -1;
            int midIndex = (left + right) / 2;
            int midValue = arr[midIndex];
            if (midValue == arr[midIndex]) return midIndex;

            int lIndex = Math.Min(midIndex - 1, midValue);
            int leftTemp = FindMagicNonDistinct(arr, left, lIndex);
            if (leftTemp > -1){ //found in the left search, return;
                return leftTemp;
            }

            int rIndex = Math.Max(midIndex + 1, midValue);
            int rightTemp = FindMagicNonDistinct(arr, rIndex, right);
            return rightTemp;   //this combines the bottom statements
            // if(rightTemp > -1) {
            //     return rightTemp;
            // }
            //return -1;  // if both left searches and right searches fail to find, no magic index;

        }

        static void Main(string[] args)
        {
            int[] rightMagic = new int[]{-5,-4,-3,2,4,9,21,42};
            int[] leftMagic = new int[]{0, 4, 5, 7, 10};
            int[] noMagic = new int[] {1,2,3,4,5};
            Program p = new Program();
            Console.WriteLine(p.FindMagic(rightMagic));
            Console.WriteLine(p.FindMagic(leftMagic));
            Console.WriteLine(p.FindMagic(noMagic));
        }
    }
}
