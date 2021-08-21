using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_MinCoinForTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Your are given an array of coin value and a target.
             * you need to find the minimum no of coins to achieve the target. If no combination is found return 0.
             */
            var sln = new Solution();
            var arr = new int[] { 4, 1, 1, 1, 3, 2 };
            var target = 7;
            var ans = sln.GetMinCoinCount(arr, target);
            Console.WriteLine(ans);
        }

        public class Solution
        {
            public int GetMinCoinCount(int[] nums, int target)
            {
                var dp = new int?[nums.Length, target+1];

                for (int i = 0; i < nums.Length; i++)
                {
                    dp[i, 0] = 0;
                }
                if (nums[0] <= target)
                {
                    dp[0, nums[0]] = 1;
                }

                for (int i = 1; i < nums.Length; i++)
                {
                    for (int j = 1; j <= target; j++)
                    {
                        // we have two choice, whatever we have before without considering the current coin
                        // (or) with considering current coin.
                        int? first = dp[i - 1, j];                        
                        int? second = null;
                        var newT = j - nums[i];
                        if (newT <= target && newT >= 0)
                        {
                            second = 1 + dp[i - 1, j - nums[i]];
                        }

                        if (!first.HasValue)
                        {
                            if (second.HasValue)
                            {
                                dp[i, j] = second;
                            }
                        }
                        else
                        {
                            if (second.HasValue)
                            {
                                dp[i, j] = Math.Min(first.Value, second.Value);
                            }
                            else{
                                dp[i, j] = first;
                            }
                        }
                    }
                }

                return dp[nums.Length-1, target] ?? 0;
            }
        }
    }
}
