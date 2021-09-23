using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_MaximumSubArray
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.

             * A subarray is a contiguous part of an array.
             */


            /*
             * Example 1:

             * Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
             * Output: 6
             * Explanation: [4,-1,2,1] has the largest sum = 6.
             */

            /*
             * Example 2:

             * Input: nums = [1]
             * Output: 1
             */

            /*
             * Example 3:

             * Input: nums = [5,4,-1,7,8]
             * Output: 23
             */
            var sln = new Solution();
            var arr = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            var ans = sln.MaxSubArray(arr);
            Console.WriteLine(ans);
        }

        public class Solution
        {
            public int MaxSubArray(int[] nums)
            {
                if (nums == null || nums.Length == 0)
                {
                    return 0;
                }
                var len = nums.Length;
                var dp = new int[len];
                dp[0] = nums[0];
                for (int i = 1; i < len; i++)
                {
                    dp[i] = Math.Max(nums[i] + dp[i-1], nums[i]);
                }

                return dp.Max();
            }
        }
    }
}
