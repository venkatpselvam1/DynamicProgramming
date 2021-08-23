using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_MaximumWeightPath
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Given a matrix of integers where every element represents weight of the cell. Find the path having the maximum weight in matrix [N X N]. Path Traversal Rules are: 
             *  
             * It should begin from top left element.
             * The path can end at any element of last row.
             * We can move to following two cells from a cell (i, j). 
             * Down Move : (i+1, j)
             * Diagonal Move : (i+1, j+1)
             * Examples: 
             *  
             * 
             * Input : N = 5
             *         mat[5][5] = {{ 4, 2 ,3 ,4 ,1 },
             *                      { 2 , 9 ,1 ,10 ,5 },
             *                      {15, 1 ,3 , 0 ,20 },
             *                      {16 ,92, 41, 44 ,1},
             *                      {8, 142, 6, 4, 8} };
             * Output : 255
             * Path with max weight : 4 + 2 +15 + 92 + 142 = 255                 
             */
            var sln = new Solution();
            var cost = new int[5][]
                {
                    new int[]{ 4, 2 ,3 ,4 ,1 },
                    new int[]{ 2 , 9 ,1 ,10 ,5 },
                    new int[]{15, 1 ,3 , 0 ,20 },
                    new int[]{16 ,92, 41, 44 ,1},
                    new int[]{8, 142, 6, 4, 8}
                };
            var ans = sln.MaxWeightPath(cost);
            Console.WriteLine(ans);
        }

        public class Solution
        {
            int[][] cost;
            public int MaxWeightPath(int[][] cost)
            {
                this.cost = cost;
                return MaxWeightPath(0, 0, new int?[cost.Length, cost[0].Length]);
            }
            public int MaxWeightPath(int i, int j, int?[,] dp)
            {
                if (i >= cost.Length || j >= cost[0].Length)
                {
                    return 0;
                }
                if (dp[i, j].HasValue)
                {
                    return dp[i, j].Value;
                }

                var first = MaxWeightPath(i+1, j, dp);
                var second = MaxWeightPath(i + 1, j+1, dp);
                var max = Math.Max(first, second);
                dp[i, j] = cost[i][j] + max;

                return dp[i, j].Value;
            }
        }
    }
}
