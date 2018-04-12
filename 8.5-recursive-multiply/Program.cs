using System;

namespace _8._5_recursive_multiply
{
    /*Write a recursive function to multiply two positive integers,
    without using the * operator (or / operator). You can use addition,
    subtraction, and bit shifting, but you should minimize the number of
    such operations.
    THOUGHTS:
        What does it mean to multiply something? Means to take a certain "something"
        and add it n-1 times.
        Solution 1: We could loop n-1 times and keep adding the number to itself
        Solution 2: solve subproblems of bigger number * half of smaller number until we hit base cases
        and then return that result added to itself to get bigger number * smaller number (RECURSIVE) 
        Optimization tip, lets find the bigger number of the two, and use the smaller number to shorten the number of operations
        what if the multiplier is odd? we can just decompose it to odd * num = (odd - 1) * num + num
                    recursion tree
                    (5,5)  ^ returns 10 + 10 + 5 = 25             
     sends s/2 == 2   |    |
                    (5,2)  | s % 2 == 0, returns 5 + 5
     sends 2/2 == 1   |    |
                    (5,1)  | s == 1, returns b = 5           
         */
    class Program
    {

        public int Multiply(int n1, int n2){
            int smaller = n1 <= n2 ? n1 : n2;
            int bigger = n2 >= n1 ? n2 : n1;
            return MultiplyHelper(bigger, smaller);
        }

        int MultiplyHelper(int b, int s){
            //base cases
            if (s == 0) return 0; //anything multiplied by 0 is 0
            if (s == 1) return b; // big * 1 = big
            
            int num = s >> 1;   //divide multiplier by 2
            //recurse, and get the product of half of the smaller number and our bigger number
            int halfProduct = MultiplyHelper(num, b);   
            //at this point, 2 * our halves will equal the product of our current operands
            //if the multiplier is even
            if (s % 2 == 0){
                return halfProduct << 1;
            }
            //if the smaller operand is odd, we need to return 2 * the half product, and then append a single count of our bigger number
            //ie. 5*8 = 2*8 + 2*8 + 8; 
            else{
                return (halfProduct << 1) + b;
            }

        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.Write(p.Multiply(5,5));
        }
    }
}
