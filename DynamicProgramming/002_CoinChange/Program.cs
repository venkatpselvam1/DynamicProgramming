using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_CoinChange
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
                var dp = new int[nums.Length, value+1];
                for (int i = 0; i < nums.Length; i++)
                {
                    dp[i, 0] = 0;
                }
                for (int i = 1; i < value+1; i++)
                {
                    dp[0, i] = i%nums[0]==0 ? 1:0;
                }

                for (int i = 1; i < nums.Length; i++)
                {
                    for (int j = 1; j < value+1; j++)
                    {
                        var ans = 0;
                        var count = 0;
                        var newVal = nums[i] * count;
                        while (newVal <= j)
                        {
                            if (newVal == j)
                            {
                                ans += 1;
                            }
                            else
                            {
                                ans += dp[i-1, j- newVal];
                            }
                            count++;
                            newVal = nums[i] * count;
                        }
                        dp[i, j] = ans;
                    }
                }

                for (int i = 0; i < dp.GetLength(0); i++)
                {
                    for (int j = 0; j < dp.GetLength(1); j++)
                    {
                        Console.Write(dp[i,j]+",");
                    }
                    Console.WriteLine();
                }

                return dp[nums.Length-1, value];
            }
        }
    }
}
