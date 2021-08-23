using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_MinCost
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 
             * Given a cost matrix cost[][] and a position (m, n) in cost[][],
             * write a function that returns cost of minimum cost path to reach (m, n) from (0, 0).
             * Each cell of the matrix represents a cost to traverse through that cell.
             * The total cost of a path to reach (m, n) is the sum of all the costs on that path (including both source and destination).
             * You can only traverse down, right and diagonally lower cells from a given cell,
             * i.e., from a given cell (i, j), cells (i+1, j), (i, j+1), and (i+1, j+1) can be traversed.
             * 
             * You may assume that all costs are positive integers.
             */
            var sln = new Solution();
            var cost = new int[3][]
                {
                    new int[] { 1, 2, 3},
                    new int[] { 4, 8, 2},
                    new int[] { 1, 5, 3},
                };
            var ans = sln.MinCostFunction(cost, 2, 2);
            Console.WriteLine(ans);
        }
        public class Solution
        {
            int[][] cost;
            int m, n;
            public int MinCostFunction(int[][] cost, int m, int n)
            {
                this.cost = cost;
                this.m = m;
                this.n = n;
                return MinCostFunction(0, 0, new int?[cost.Length, cost[0].Length]);
            }
            public int MinCostFunction(int i, int j, int?[,] dp)
            {
                if (i >= cost.Length || j >= cost[0].Length)
                {
                    return int.MaxValue;
                }
                if (m == i && n == j)
                {
                    return cost[m][n];
                }

                if (dp[i, j].HasValue)
                {
                    return dp[i, j].Value;
                }

                // we have only three ways to move forward
                var first = MinCostFunction(i+1, j, dp);
                var second = MinCostFunction(i+1, j+1, dp);
                var third = MinCostFunction(i, j+1, dp);
                var min = Math.Min(Math.Min(first, second), third);

                dp[i,j] = cost[i][j] + min;
                return dp[i,j].Value;
            }
        }
    }
}
