using System;
using System.Collections;
using System.Collections.Generic;

namespace _8._4_power_set
{
    /*Write a method to return all subsets of a set
    THOUGHTS:
        Power set is all possible subcombinations of a set
        ie. {1,2,3} -> {}, {1}, {2}, {3}, {1,2}, {1,3}, {2,3}, {1,2,3}
        how did we build this?
        First of all, power set always includes the empty set {}
        secondly, power set P of {1} is {}, {1}
        thirdly, power set P of {1,2} is {}, {1}, {2}, {1,2}
        as we can see, the power set of P{1,2} is the addition 
        of all the subsets contained in P{1,2} with P{1}
        furthermore, we can see that the subsets can actually be 
        constructed by appending a copy of P{1}, and then adding {2} to our P{1},
        {} + {2} = {2}, {1} + {2} = {1,2}
        results in {}, {1}, {2}, {1,2}
     */
    class Program
    {

        public IList<List<int>> PowerSet(IList<int> arr){
            return GetSubsets(arr, 0);
        }

        public List<List<int>> GetSubsets(IList<int> arr, int index){
            List<List<int>> powerSet;
            //base case, if our input array is empty, add the empty set
            if (arr.Count == index) {   
                powerSet = new List<List<int>>();
                powerSet.Add(new List<int>());
            }
            else{
                //get subsets of current array
                powerSet = GetSubsets(arr, index + 1);
                //get current item to merge into our sets
                int val = arr[index];
                //make copy of our current power set
                IList<List<int>> mergeSet = new List<List<int>>();
                foreach(List<int> powerList in powerSet){
                    List<int> mergeList = new List<int>();
                    //deep copy sub array
                    mergeList.AddRange(powerList);
                    //add new item
                    mergeList.Add(val);
                    //add newly appended list to new powerset
                    mergeSet.Add(mergeList);
                }
                //add sets we've just added our value to, to our original set
                powerSet.AddRange(mergeSet);
            }
            return powerSet;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            IEnumerable<IEnumerable<int>> var = p.PowerSet(new int[]{1,2,3});
            foreach(IEnumerable<int> n in var){
                foreach(int i in n){
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
