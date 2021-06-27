using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_TrapWater_UsingStack
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
            //var arr = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            var arr = new int[] { 4, 2, 3 };
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
            var stack = new Stack<int>();
            var leftMax = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (stack.Count > 0)
                {
                    if (leftMax <= arr[i])
                    {
                        while (stack.Count > 0)
                        {
                            var val = stack.Pop();
                            area += leftMax - val;
                        }
                        stack.Push(arr[i]);
                        leftMax = arr[i];
                    }
                    else
                    {
                        stack.Push(arr[i]);
                    }
                }
                else
                {
                    stack.Push(arr[i]);
                    leftMax = arr[i];
                }
            }
            if (stack.Count > 0)
            {
                var rightMax = stack.Pop();
                while (stack.Count > 0)
                {
                    var val = stack.Pop();
                    if (val < rightMax)
                    {
                        area += rightMax - val;
                    }
                    else if (stack.Count > 0)
                    {
                        rightMax = val;
                    }
                }
            }
            
            return area;
        }
    }
}
