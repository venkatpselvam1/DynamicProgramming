using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Trap water problem using stacks.
            //var arr = new int[] { 5, 3,2, 4,1,2,1 };//2
            var arr = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1};//2
            var ans = GetTrappedWater(arr);
            Console.WriteLine(ans);
        }
        public static int GetTrappedWater(int[] arr)
        {
            if (arr == null || arr.Length < 3)
            {
                return 0;
            }
            var ans = 0;
            var stack = new Stack<int>();
            var length = arr.Length;
            var leftMax = arr[0];
            stack.Push(leftMax);
            for (int i = 1; i < length; i++)
            {
                var element = arr[i];
                //if less than max, keep pushing
                if (element < leftMax)
                {
                    stack.Push(element);
                }
                //else takeout the elements from the stack
                else
                {
                    while (stack.Count > 0)
                    {
                        var val = stack.Pop();
                        ans += leftMax - val;
                    }
                    leftMax = element;
                }
            }
            if (stack.Count != 0)
            {
                var rightmax = stack.Pop();
                while (stack.Count > 0)
                {
                    var val = stack.Pop();
                    if (val > rightmax)
                    {
                        rightmax = val;
                    }
                    else
                    {
                        ans += rightmax - val;
                    }
                }
            }
            return ans;
        }
    }
}
