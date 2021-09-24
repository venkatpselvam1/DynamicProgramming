using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_Kadanes
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
                return 0;
            }
        }
    }
}
