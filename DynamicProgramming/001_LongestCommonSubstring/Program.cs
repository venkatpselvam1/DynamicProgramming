using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_LongestCommonSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Given two strings ‘X’ and ‘Y’, find the length of the longest common substring. 
             * 
             * Examples : 
             * 
             * Input : X = “GeeksforGeeks”, y = “GeeksQuiz” 
             * Output : 5 
             * Explanation:
             * The longest common substring is “Geeks” and is of length 5.
             * 
             * Input : X = “abcdxyz”, y = “xyzabcd” 
             * Output : 4 
             * Explanation:
             * The longest common substring is “abcd” and is of length 4.
             * 
             * Input : X = “zxabcdezy”, y = “yzabcdezx” 
             * Output : 6 
             * Explanation:
             * The longest common substring is “abcdez” and is of length 6.
             */
            var sln = new Solution();
            var ans = sln.LongestCommonSubstringLength("abcd", "aajbcd");
            Console.WriteLine(ans);
        }
        public class Solution
        {
            string a, b;
            public int LongestCommonSubstringLength(string a, string b)
            {
                this.a = a;
                this.b = b;
                return LongestCommonSubstringLength(0, 0, new int?[a.Length, b.Length]);
            }
            public int LongestCommonSubstringLength(int i, int j, int?[,] dp)
            {
                if ( i >= a.Length || j >= b.Length)
                {
                    return 0;
                }
                if (dp[i,j].HasValue)
                {
                    return dp[i, j].Value;
                }
                // we have three choice, we can either take char from first or char from second or not from both or take from both.
                var first = LongestCommonSubstringLength(i+1, j, dp);
                var second = LongestCommonSubstringLength(i, j+1, dp);
                var third = LongestCommonSubstringLength(i+1, j+1, dp);
                var original = GetLength(i, j);
                var ans = Math.Max(Math.Max(first, second), Math.Max(third, original));
                dp[i, j] = ans;
                return dp[i, j].Value;
            }

            public int GetLength(int i, int j)
            {
                var ans = 0;
                while (i < a.Length && j < b.Length)
                {
                    if (a[i] == b[j])
                    {
                        ans++;
                    }
                    else
                    {
                        break;
                    }
                    i++;
                    j++;
                }
                return ans;
            }
        }
    }
}
