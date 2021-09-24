using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_Kadanes
{
    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            var nums = new int[] { 1, -2, 3, -2 };
            var ans = sln.MaxSubarraySumCircular(nums);
            Console.WriteLine(ans);
        }
        public class Solution
        {
            public int MaxSubarraySumCircular(int[] nums)
            {
                if (nums == null || nums.Length == 1)
                {
                    return 0;
                }
                if (nums.Length == 1)
                {
                    return nums[0];
                }
                var sum = nums.Sum();
                var ans1 = MaxSubarraySum(nums, 0, nums.Length);
                var ans2 = sum - MinSubarraySum(nums, 0, nums.Length-1);
                var ans3 = sum - MinSubarraySum(nums, 1, nums.Length); ;
                Console.WriteLine(ans1 + " :: " + ans3 + " :: " + ans3 + " :: ");
                return Math.Max(ans1, Math.Max(ans2, ans3));
            }
            public int MaxSubarraySum(int[] nums, int start, int end)
            {
                var max_here = nums[start];
                var max_so_far = nums[start];
                for (int i = start+1; i < end; i++)
                {
                    max_here = Math.Max(max_here+nums[i], nums[i]);
                    max_so_far = Math.Max(max_here, max_so_far);
                }
                return max_so_far;
            }

            public int MinSubarraySum(int[] nums, int start, int end)
            {
                var min_here = nums[start];
                var min_so_far = nums[start];
                for (int i = start+1; i < end; i++)
                {
                    min_here = Math.Min(min_here + nums[i], nums[i]);
                    min_so_far = Math.Min(min_here, min_so_far);
                }
                return min_so_far;
            }
        }
    }
}
