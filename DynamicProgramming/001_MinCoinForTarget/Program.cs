using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_MinCoinForTarget
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
            var arr = new int[] { 4, 1, 1, 1, 3};
            var target = 7;
            var ans = sln.GetMinCoinCount(arr, target);
            Console.WriteLine(ans);
        }

        public class Solution
        {
            public int GetMinCoinCount(int[] nums, int target)
            {
                var val =  GetMinCoinCount(nums, target, 0, new int?[nums.Length, target+1]);
                return val ?? 0;
            }

            /// <summary>
            /// if null indicates that no combination found
            /// </summary>
            /// <param name="num"></param>
            /// <param name="target"></param>
            /// <param name="ind"></param>
            /// <returns></returns>
            public int? GetMinCoinCount(int[] num, int target, int ind, int?[,] dp)
            {
                if (target == 0)
                {
                    return 0;
                }
                if (ind >= num.Length)
                {
                    return null;
                }
                if (dp[ind, target].HasValue)
                {
                    return dp[ind, target];
                }

                // you have to choice, either choose the current index coin or don't choose
                int? first = null;
                if (num[ind] <= target)
                {
                    var a = GetMinCoinCount(num, target - num[ind], ind+1, dp);
                    if (a.HasValue)
                    {
                        first = 1 + a;
                    }
                }
                var second = GetMinCoinCount(num, target, ind+1, dp);


                int? ans = null;
                if (!first.HasValue && !second.HasValue)
                {
                    ans =  null;
                }
                else if (!first.HasValue)
                {
                    ans = second.Value;
                }
                else if (!second.HasValue)
                {
                    ans = first.Value;
                }
                else
                {
                    ans = Math.Min(second.Value, first.Value);
                }
                
                dp[ind, target] = ans;
                return ans;
            }
        }
    }
}
