using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_CherryPickup2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Given a rows x cols matrix grid representing a field of cherries. Each cell in grid represents the number of cherries that you can collect.
            
             * You have two robots that can collect cherries for you, Robot #1 is located at the top-left corner (0,0) , 
             * and Robot #2 is    located* at    the    top-   right corner (0, cols-1) of the grid.
             * 
             * Return the maximum number of cherries collection using both robots  by following the rules below:
             * 
             * From a cell (i,j), robots can move to cell (i+1, j-1) , (i+1, j) or (i+1, j+1).
             * When any robot is passing through a cell, It picks it up all cherries, and the cell becomes an empty cell (0).
             * When both robots stay on the same cell, only one of them takes the cherries.
             * Both robots cannot move outside of the grid at any moment.
             * 
             * Both robots should reach the bottom row in the grid.
             */
            var sln = new Solution();
            var grid1 = new int[4][] 
            { 
                new int[]{ 3, 1, 1 }, 
                new int[] { 2, 5, 1 }, 
                new int[] { 1, 5, 5 }, 
                new int[] { 2, 1, 1 }
            };
            var grid2 = new int[5][] 
            {
                new int[]{1,0,0,0,0,0,1},
                new int[]{2,0,0,0,0,3,0},
                new int[]{2,0,9,0,0,0,0},
                new int[]{0,3,0,5,4,0,0},
                new int[]{1,0,2,3,0,0,6}
            };
            var grid3 = new int[4][] {
                new int[]{1,0,0,3},
                new int[]{0,0,0,3},
                new int[]{0,0,3,3},
                new int[]{9,0,3,3}
            };
            var grid4 = new int[2][] {
                new int[]{1,1},
                new int[]{1,1}
            };
            var ans = sln.CherryPickup(grid1);
            Console.WriteLine(ans);
        }

        public class Solution
        {
            int[][] grid;
            int h, w;
            public int CherryPickup(int[][] grid)
            {
                this.grid = grid;
                h = grid.Length;
                w = grid[0].Length;
                return CherryPickupDP(0, 0, w - 1, new int?[h, w, w]);
            }
            public int CherryPickupDP(int r, int a, int b, int?[,,] dp)
            {
                if (r >= h || a < 0 || b < 0 || a >= w || b >= w)
                {
                    return 0;
                }
                if (dp[r, a, b].HasValue)
                {
                    return dp[r, a, b].Value;
                }
                var first = grid[r][a];
                var second = a == b ? 0 : grid[r][b];
                var ans = 0;
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        ans = Math.Max(CherryPickupDP(r + 1, a + i, b + j, dp), ans);
                    }
                }

                dp[r, a, b] = first + second + ans;
                return dp[r, a, b].Value;
            }
        }
    }
}
