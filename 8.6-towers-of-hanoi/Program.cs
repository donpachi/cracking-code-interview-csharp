using System;
using System.Collections;
using System.Collections.Generic;

namespace _8._6_towers_of_hanoi
{
    /*In the classic problem of Towers of Hanoi, you have 3 towers and N disks of different sizes 
    which can slide onto any tower. The puzzle starts with disks sorted in ascending order of size 
    from top to bottom (i.e., each disk sits on top of an even larger one). You have the following
    constraints:
        (1) Only one disk can be moved at a time
        (2) A disk is slid off the top of one tower onto another tower
        (3) A disk cannot be placed on top of a smaller disk.
    Write a program to move the disks from the first tower to the last using Stacks
    
    THOUGHTS:
    Lets make some base cases.  (disk numbers are ascending in size)
    1 disk, move to last tower.
    2 disks, move disk 1 to tower 2, move disk 2 to tower 3, move disk 1 from tower 2 to tower 3.
    3 disks, do what we did for disk 2 case for disk 1 and 2, but to tower 2 and not 3. Move disk 3 to tower 3, move disk 1 and 2 to tower 3 using the 2 disk method
    4 disks, do the same for 3 disk, but to tower 2, move disk 4 to tower 3. Move disk 1, 2, 3, to tower 3 using 3 disk method
    **note how we keep using tower 2 as a sort of cache or buffer to hold our semi-sorted disks before our final move
    Obviously, we see a recursive method evolving:

    Let's write out some pseudocode for the recursion:
    function Hanoi(int n, Stack src, Stack buffer, Stack dst){
        //recursion base case
        if (n <= 0) return;
        //remember tower 2 is the destination here
        Hanoi(n-1, src, dst, buffer);
        move disk from src to dst
        //our origin is where we last put our results, in this case, buffer, and our origin tower is now our buffer
        Hanoi(n-1, buffer, src, dst); 
    }

     */
    class Program
    {
        public Stack<int> Hanoi(int n){
            Stack<int> T1 = new Stack<int>();
            Stack<int> T2 = new Stack<int>();
            Stack<int> T3 = new Stack<int>();
            for(int i = n; i > 0; i--) T1.Push(i);
            Hanoi(n, T1, T3, T2);
            return T3;
        }

        void Hanoi(int n, Stack<int> src, Stack<int> dst, Stack<int> buf){
            if(n <= 0) return;
            Hanoi(n-1, src, buf, dst);  //move from src to buffer using dst as buffer
            dst.Push(src.Pop());
            Hanoi(n-1, buf, dst, src);  //move from buf to dst using src as buffer
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            IEnumerable<int> results = p.Hanoi(4);
            foreach(int n in results){  //should print in order from 1-5
                Console.WriteLine(n);
            }
        }
    }
}
