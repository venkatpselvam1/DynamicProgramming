using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_TrapWater_3D
{
    class Program
    {
        static void Main(string[] args)
        {
            //var arr = new int[][] { new int[]{ 1, 4, 3, 1, 3, 2 }, new int[] { 3, 2, 1, 3, 2, 4 }, new int[] { 2, 3, 3, 2, 3, 1 } };//4
            //var arr = new int[][] { new int[]{ 3, 3, 3, 3, 3 },
            //    new int[] { 3, 2, 2, 2, 3 },
            //    new int[] { 3, 2, 1, 2, 3 }, 
            //    new int[] { 3, 2, 2, 2, 3 } ,
            //    new int[] { 3, 3, 3, 3, 3 } };//10
            //[[12,13,1,12],[13,4,13,12],[13,8,10,12],[12,13,12,12],[13,13,13,13]]
            var arr = new int[][] { new int[]{ 12,13,1,12},
                new int[] {13,4,13,12},
                new int[] { 13,8,10,12},
                new int[] { 12, 13, 12, 12 } ,
                new int[] { 13, 13, 13, 13 } };//14
            var ans = TrapRainWater(arr);
            Console.WriteLine(ans);
        }
        public  static int TrapRainWater(int[][] heightMap)
        {
            var vol = 0;
            if (heightMap.Length < 3 || heightMap[0].Length < 3)
            {
                return vol;
            }
            var width = heightMap.Length;
            var length = heightMap[0].Length;
            var leftMaxArr = new int[width, length];
            var rightMax = new int[width, length];
            var topMaxArr = new int[width, length];
            var downMaxArr = new int[width, length];
            var topLeftMaxArr = new int[width, length];
            var topRightMaxArr = new int[width, length];
            var bottomLeftMaxArr = new int[width, length];
            var bottomRightMaxArr = new int[width, length];

            // setting left max
            for (int i = 0; i < width; i++)
            {
                leftMaxArr[i, 0] = heightMap[i][0];
                for (int j = 1; j < length; j++)
                {
                    leftMaxArr[i, j] = Math.Max(leftMaxArr[i, j - 1], heightMap[i][j]);
                }
            }

            // setting right max
            for (int i = 0; i < width; i++)
            {
                rightMax[i, length - 1] = heightMap[i][length - 1];
                for (int j = length - 2; j >= 0; j--)
                {
                    rightMax[i, j] = Math.Max(rightMax[i, j + 1], heightMap[i][j]);
                }
            }

            //setting top max
            for (int j = 0; j < length; j++)
            {
                topMaxArr[0, j] = heightMap[0][j];
                for (int i = 1; i < width; i++)
                {
                    topMaxArr[i, j] = Math.Max(topMaxArr[i - 1, j], heightMap[i][j]);
                }
            }

            // setting bottom max
            for (int j = 0; j < length; j++)
            {
                downMaxArr[width - 1, j] = heightMap[width - 1][j];
                for (int i = width - 2; i >= 0; i--)
                {
                    downMaxArr[i, j] = Math.Max(downMaxArr[i + 1, j], heightMap[i][j]);
                }
            }

            for (int i = 0; i < width; i++)
            {
                topLeftMaxArr[i, 0] = heightMap[i][0];
                for (int j = 1; j < length; j++)
                {
                    topLeftMaxArr[i, j] = Math.Max(heightMap[i][j], topLeftMaxArr[i, j-1]);
                }
            }

            for (int i = 0; i < width; i++)
            {
                topRightMaxArr[i, length - 1] = heightMap[i][length - 1];
                for (int j = length - 2; j >0; j--)
                {
                    topRightMaxArr[i, j] = Math.Max(topRightMaxArr[i, j+1], heightMap[i][j]);
                }
            }

            for (int j = 0; j < length; j++)
            {
                bottomLeftMaxArr[0, j] = heightMap[0][j];
                for (int i = 1; i < width; i++)
                {
                    bottomLeftMaxArr[i, j] = Math.Max(bottomLeftMaxArr[i-1, j], heightMap[i][j]);
                }
            }

            for (int j = 0; j < length; j++)
            {
                bottomRightMaxArr[length-1, j] = heightMap[length-1][j];
                for (int i = length - 2; i > 0; i--)
                {
                    bottomRightMaxArr[i, j] = Math.Max(bottomRightMaxArr[i-1, j], heightMap[i][j]);
                }
            }

            // Summing the ans
            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < length - 1; j++)
                {
                    var min1 = FindMin(leftMaxArr[i, j], rightMax[i, j], topMaxArr[i, j], downMaxArr[i, j]);
                    var min2 = FindMin(topLeftMaxArr[i, j], topRightMaxArr[i, j], bottomLeftMaxArr[i, j], bottomRightMaxArr[i, j]);
                    var min = Math.Min(min1, min2);
                    vol += min - heightMap[i][j];
                }
            }
            return vol;
        }
        public static int FindMin(int a, int b, int c, int d)
        {
            return Math.Min(Math.Min(Math.Min(a, b), c), d);
        }
    }
}
