using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_TrapWater_BruteForce
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Given n non-negative integers representing an elevation map where the width of each bar is 1,
                compute how much water it can trap after raining.
             */

            /*
                For more info see the image TrapWater.png
                Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
                Output: 6
                Explanation: The above elevation map (black section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1].
                In this case, 6 units of rain water (blue section) are being trapped.
             */
            var arr = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            var ans = FindMaxWaterTrapped(arr);
            Console.WriteLine(ans);
        }
        public static int FindMaxWaterTrapped(int[] arr)
        {
            var area = 0;
            if (arr.Length == 0)
            {
                return area;
            }
            // Brute force method.
            // Find water can be trapped for each index and add that.
            for (int i = 1; i < arr.Length-1; i++)
            {
                var leftMax = 0;
                var rightMax = 0;
                for (int j = i; j > 0; j--)
                {
                    leftMax = Math.Max(leftMax, arr[j]);
                }
                for (int k = i ; k < arr.Length; k++)
                {
                    rightMax = Math.Max(rightMax, arr[k]);
                }
                area += Math.Min(leftMax, rightMax) - arr[i];
            }
            return area;
        }
    }
}
