using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_Kadanes
{
    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            var nums = new int[] { 5, -3, 5 };
            var ans = sln.MaxSubarraySumCircular(nums);
            Console.WriteLine(ans);
        }
        public class Solution
        {
            public int MaxSubarraySumCircular(int[] nums)
            {
                if (nums == null || nums.Length == 0)
                {
                    return 0;
                }
                if (nums.Length == 1)
                {
                    return nums[0];
                }

                var len = nums.Length;
                var max_so_far = nums[0];
                var max_near = nums[0];
                for (int i = 1; i < len; i++)
                {
                    max_near = Math.Max(nums[i], nums[i] + max_near);
                    max_so_far = Math.Max(max_so_far, max_near);
                }
                Console.WriteLine("Single interval maximum ans :" + max_so_far);

                // going to double interval
                // [0, i] [j, len-1] => sumof(0 to i) ans Max(sum of len-1 to j)
                var leftSum = new int[len];
                leftSum[0] = nums[0];
                for (int i = 1; i < len; i++)
                {
                    leftSum[i] = leftSum[i - 1] + nums[i];
                }

                // right sum 
                var rightSum = new int[len];
                rightSum[len - 1] = nums[len - 1];
                for (int i = len-2; i >= 0; i--)
                {
                    rightSum[i] = rightSum[i + 1] + nums[i];
                }

                // we are don't want right sum, we want max of right sum for the index i
                var rightSumMax = new int[len];
                rightSumMax[len -1] = rightSum[len - 1];
                for (int i = len-2; i >= 0; i--)
                {
                    rightSumMax[i] = Math.Max(rightSumMax[i + 1], rightSum[i]);
                }

                // get the ans
                for (int i = 0; i < len-1; i++)
                {
                    max_so_far = Math.Max(max_so_far, leftSum[i] + rightSumMax[i+1]);
                }

                return max_so_far;
            }
        }
    }
}
