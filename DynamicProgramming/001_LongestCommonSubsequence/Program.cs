using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_LongestCommonSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
Problem Description:

Given two strings A and B. Find the longest common sequence ( A sequence which does not need to be contiguous), which is common in both the strings.
You need to return the length of such longest common subsequence.

Problem Constraints
1 <= |A|, |B| <= 1005

Example Input
 A = "abbcdgf"
 B = "bbadcgf"

Example Output
 5

Example Explanation
The longest common subsequence is "bbcgf", which has a length of 5
             */
            var sln = new Solution();
            var ans = sln.solve("abbcdgf", "bbadcgf");
            Console.WriteLine(ans);
        }
        public class Solution
        {
            string a, b;
            public int solve(string A, string B)
            {
                this.a = A;
                this.b = B;
                return Solve(0, 0, new int?[a.Length, b.Length]);
            }
            public int Solve(int i, int j, int?[,] dp)
            {
                if (i >= a.Length || j >= b.Length)
                {
                    return 0;
                }
                if (dp[i,j].HasValue)
                {
                    return dp[i, j].Value;
                }
                var first = 0;
                var x = j;
                while (x < b.Length)
                {
                    if (this.a[i] == this.b[x])
                    {
                        first = 1 + Solve(i+1, x+1, dp);
                        break;
                    }
                    x++;
                }

                var second = Solve(i+1, j, dp);
                dp[i,j] = Math.Max(first, second);
                return dp[i, j].Value;
            }
        }
    }
}
