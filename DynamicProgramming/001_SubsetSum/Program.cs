using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_SubsetSum
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 
             * Given a set of non-negative integers, and a value sum, determine if there is a subset of the given set with sum equal to given sum. 
             * 
             * Example: 
             * 
             * Input: set[] = {3, 34, 4, 12, 5, 2}, sum = 9
             * Output: True  
             * There is a subset (4, 5) with sum 9.
             * 
             * Input: set[] = {3, 34, 4, 12, 5, 2}, sum = 30
             * Output: False
             * There is no subset that add up to 30.
             */
            var sln = new Solution();
            var arr = new int[] { 3, 34, 4, 12, 5, 2 };
            var target = 9;
            var ans = sln.SubSetAvialable(arr, target);
            Console.WriteLine(ans);
        }
        public class Solution
        {
            public bool SubSetAvialable(int[] arr, int target)
            {
                // The idea is either we can choose the current element or not.
                return SubSetAvialable(arr, target, 0, new bool?[arr.Length]);
            }
            public bool SubSetAvialable(int[] arr, int target, int ind, bool?[] dp)
            {
                if (ind >= arr.Length || target < 0)
                {
                    return false;
                }
                if (target == 0)
                {
                    return true;
                }
                if (dp[ind].HasValue)
                {
                    return dp[ind].Value;
                }

                // The idea is either we can choose the current element or not.
                dp[ind] = SubSetAvialable(arr, target - arr[ind], ind + 1, dp) || SubSetAvialable(arr, target, ind + 1, dp);
                return dp[ind].Value;
            }
        }
    }
}
