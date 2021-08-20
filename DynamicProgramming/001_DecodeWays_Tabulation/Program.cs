using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_DecodeWays_Tabulation
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
A message containing letters from A-Z can be encoded into numbers using the following mapping:

'A' -> "1"
'B' -> "2"
...
'Z' -> "26"
To decode an encoded message, all the digits must be grouped then mapped back into letters using the reverse of the mapping above (there may be multiple ways). For example, "11106" can be mapped into:

"AAJF" with the grouping (1 1 10 6)
"KJF" with the grouping (11 10 6)
Note that the grouping (1 11 06) is invalid because "06" cannot be mapped into 'F' since "6" is different from "06".

Given a string s containing only digits, return the number of ways to decode it.

The answer is guaranteed to fit in a 32-bit integer.

// https://leetcode.com/problems/decode-ways/
             */
            var sln = new Solution();
            var ans = sln.NumDecodings("123");
            Console.WriteLine(ans);
        }
        public class Solution
        {
            public int NumDecodings(string s)
            {
                var dp = new int[s.Length+2];
                dp[1] = 1;
                for (int i = 0; i < s.Length; i++)
                {
                    var j = i + 2;
                    if (s[i] != '0')
                    {
                        dp[j] = dp[j-1];
                    }
                    if (i-1 >= 0)
                    {
                        if (s[i-1] == '1' || (s[i-1] == '2' && Convert.ToInt32(s[i].ToString()) < 7))
                        {
                            dp[j] += dp[j - 2];
                        }
                    }
                    
                }

                return dp[s.Length+1];
            }
        }
    }
}
