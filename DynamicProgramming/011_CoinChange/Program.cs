using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _011_CoinChange
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
Given a value N, if we want to make change for N cents, and we have infinite supply of each of S = { S1, S2, .. , Sm}
valued coins, how many ways can we make the change? The order of coins doesn’t matter.

For example, for N = 4 and S = {1,2,3},
there are four solutions: {1,1,1,1},{1,1,2},{2,2},{1,3}. So output should be 4. For N = 10 and S = {2, 5, 3, 6},
there are five solutions: {2,2,2,2,2}, {2,2,3,3}, {2,2,6}, {2,3,5} and {5,5}. So the output should be 5.
             */
            var sln = new Solution();

            // set 1
            //var nums = new int[] { 1, 2, 3 };
            //var value = 4;
            //ans = 4

            // set 2
            var nums = new int[] { 2, 5, 3, 6 };
            var value = 10;
            //ans = 5

            var ans = sln.GetMaxComb(nums, value);
            Console.WriteLine(ans);
        }
        public class Solution
        {
            public int GetMaxComb(int[] nums, int value)
            {
                return GetMaxComb(nums, value, 0, new int?[nums.Length, value + 1]);
            }
            public int GetMaxComb(int[] nums, int value, int i, int?[,] dp)
            {
                if (i >= nums.Length)
                {
                    return 0;
                }
                if (dp[i, value].HasValue)
                {
                    return dp[i, value].Value;
                }
                var ans = 0;
                var count = 0;
                while (nums[i] * count <= value)
                {
                    if (nums[i] * count == value)
                    {
                        ans += 1;
                    }
                    else
                    {
                        ans += GetMaxComb(nums, value - nums[i] * count, i + 1, dp);
                    }
                    count++;
                }
                dp[i, value] = ans;

                return dp[i, value].Value;
            }
        }
    }
}
