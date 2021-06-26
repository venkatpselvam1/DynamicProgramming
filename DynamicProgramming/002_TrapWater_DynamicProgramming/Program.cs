using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_TrapWater_DynamicProgramming
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
            var length = arr.Length;
            var leftMax = new int[length];
            var rightMax = new int[length];
            leftMax[0] = arr[0];
            for (int i = 1; i < length; i++)
            {
                leftMax[i] = Math.Max(leftMax[i - 1], arr[i]);
            }
            rightMax[length - 1] = arr[length - 1];
            for (int i = length - 2; i > 0; i--)
            {
                rightMax[i] = Math.Max(rightMax[i + 1], arr[i]);
            }
            for (int i = 1; i < length - 1; i++)
            {
                area+= Math.Min(leftMax[i], rightMax[i]) - arr[i];
            }
            return area;
        }
    }
}
