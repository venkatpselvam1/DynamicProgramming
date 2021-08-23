using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_SubsetSum
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
                var dp = new bool[arr.Length, target+1];
                for (int i = 0; i < arr.Length; i++)
                {
                    dp[i, 0] = true;
                }

                for (int i = 1; i <= target; i++)
                {
                    dp[0, i] = (i == arr[0]);
                }

                for (int i = 1; i < arr.Length; i++)
                {
                    for (int j = 1; j <= target; j++)
                    {
                        dp[i, j] = (j - arr[i] >= 0 ?  dp[i-1, j-arr[i]]: false) || dp[i-1, j];
                    }
                }

                for (int i = 0; i <= target; i++)
                {
                    Console.Write(i + " => ");
                    for (int j = 0; j < arr.Length; j++)
                    {
                        Console.Write(dp[j, i] + ", ");
                    }
                    Console.WriteLine();
                }

                return dp[arr.Length - 1, target];
            }
        }
    }
}
