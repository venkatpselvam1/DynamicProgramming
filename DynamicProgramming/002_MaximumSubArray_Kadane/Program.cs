using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_MaximumSubArray_Kadane
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
                var max_here = nums[0];
                var max_so_far = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    max_here = Math.Max(nums[i], nums[i] + max_here);
                    max_so_far = Math.Max(max_here, max_so_far);
                }
                return max_so_far;
            }
        }
    }
}
