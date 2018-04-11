using System;

namespace _8._1_triple_step
{
    /*A child is running up a staircase with n steps and can hop either 1 step, 2 steps, or 3 steps at a time.
    Implement a method to count how mnay possible ways the child can run up the stairs
    THOUGHTS: Subproblems galore, obvious DP solution available (similar to knapsack/money change problem)
    Start with a bottom up approach with an obvious base case. There are 3 cases here so all we need to do is establish
    the base cases, and then each subsequent calculation with the summation of the 3 indices before
    4 -> 1-1-1-1    1-1-2   2-1-1   1-2-1   2-2    3-1    1-3  -> 7 ways
    5 -> 1-1-1-1-1, 1-1-1-2, 1-1-2-1, 1-2-1-1, 2-1-1-1, 3-1-1, 1-3-1, 1-1-3, 2-1-2, 1-2-2, 2-2-1, 2-3, 3-2  ->  13 ways*/
    class Program
    {
        public int CountSteps(int steps){
            int[] memo = new int[steps + 1];
            Array.Fill(memo, -1);
            return CountSteps(memo, steps);
        }

        int CountSteps(int[] memo, int steps){
            if (steps < 0) return 0;    //null case
            else if (steps == 1) return 1;  //base case
            else if (steps == 2) return 2;
            else if (steps == 3) return 3;
            else if (memo[steps] > -1) return memo[steps];  //found precompuatation
            else{
                memo[steps] = CountSteps(memo, steps - 1) + CountSteps(memo, steps - 2) + CountSteps(memo, steps - 3) + 1;  //summate all the ways to get to 1 move before current steps, then add 1
            }
            return memo[steps];
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine(p.CountSteps(4));
        }
    }
}
