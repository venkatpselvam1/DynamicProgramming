using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_DistinctSubsequences
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Given two strings s and t, return the number of distinct subsequences of s which equals t.

             * A string's subsequence is a new string formed from the original string by deleting some (can be none) of the characters without disturbing the remaining characters' relative positions.
             * (i.e., "ACE" is a subsequence of "ABCDE" while "AEC" is not).

             * It is guaranteed the answer fits on a 32-bit signed integer.
             */

            /*
             * Input: s = "rabbbit", t = "rabbit"
             * Output: 3
             * Explanation:
             * 
             * Input: s = "rab(1)b(2)b(3)it", t = "rabbit"
             * rab(1)b(2)it
             * rab(1)b(3)it
             * rab(2)b(3)it
             */

            var sln = new Solution();
            var a = "rabbbit";
            var b = "rabbit";
            var ans = sln.NumDistinct(a, b);
            Console.WriteLine(ans);
        }
        public class Solution
        {
            string s, t;
            public int NumDistinct(string s, string t)
            {
                this.s = s;
                this.t = t;
                return NumDistinctDp(0, 0, new int?[s.Length+1, t.Length+1]);
            }

            public int NumDistinctDp(int n, int m, int?[,] dp)
            {
                if (m >= t.Length)
                {
                    return 1;
                }
                if (n >= s.Length)
                {
                    return 0;
                }

                if (dp[n, m].HasValue)
                {
                    return dp[n, m].Value;
                }

                var first = 0;
                if (s[n] == t[m])
                {
                    first = NumDistinctDp(n+1, m+1, dp);
                }

                var second = NumDistinctDp(n + 1, m, dp);
                dp[n, m] = first + second;
                return dp[n, m].Value;
            }
        }
    }
}
