using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_PatternMatching_DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(IsMatch("abcd", ".a..d") + " : False");
            //Console.WriteLine(IsMatch("abcd", "a..d") + " : True");
            Console.WriteLine(IsMatch("aabc", "a*abc") + " : True");
            //Console.WriteLine(IsMatch("mississippi", "mis*is*p*.") + " : False");
            //Console.WriteLine(IsMatch("aa", "a*") + " : True");
            //Console.WriteLine(IsMatch("a", "ab*") + " : True");
            //Console.WriteLine(IsMatch("", "c*") + " : True");
            //Console.WriteLine(IsMatch("a", "a*a") + " : True");
            //Console.WriteLine(IsMatch("bbbba", ".*a*a") + " : True");
            //Console.WriteLine(IsMatch("abcdede", "ab.*de") + " : True");
            //Console.WriteLine(IsMatch("ab", ".*c") + " : False");
        }
        public static bool IsMatch(string target, string pattern)
        {
            var dp = new bool?[target.Length+1, pattern.Length+1];
            return IsMatch(target, pattern, dp, target.Length, pattern.Length);
        }
        public static bool IsMatch(string target, string pattern, bool?[,] dp, int i, int j)
        {
            if (dp[i, j].HasValue)
            {
                return dp[i, j].Value;
            }
            var ans = false;
            if (j == 0)
            {
                ans = i == 0;
            }
            else
            {
                var isFirstMatches = i != 0 && (target[0].Equals(pattern[0]) || pattern[0].Equals('.'));
                if (pattern.Length >= 2 && pattern[0].Equals('*'))
                {
                    ans = IsMatch(target, pattern.Substring(2), dp, i, j - 2);
                    if (!ans)
                    {
                        ans = isFirstMatches && IsMatch(target.Substring(1), pattern, dp, i - 1, j);
                    }
                }
                else
                {
                    ans = isFirstMatches && IsMatch(target.Substring(1), pattern.Substring(1), dp, i - 1, j - 1);
                }
            }
            dp[i, j] = ans;
            return dp[i, j].Value;
        }
        //public static bool IsMatch(string target, string pattern, bool?[,] dp, int i, int j)
        //{
        //    if (dp[i, j].HasValue)
        //    {
        //        return dp[i, j].Value;
        //    }
        //    var ans = false;
        //    if (string.IsNullOrEmpty(pattern))
        //    {
        //        ans = string.IsNullOrEmpty(target);
        //    }
        //    else
        //    {
        //        var isFirstMatch = !string.IsNullOrEmpty(target) && ( target[0].Equals(pattern[0]) || pattern[0].Equals('.'));
        //        if (pattern.Length >= 2 && pattern[1].Equals('*'))
        //        {
        //            ans = IsMatch(target, pattern.Substring(2), dp, i, j-2);
        //            if (!ans)
        //            {
        //                ans = isFirstMatch && IsMatch(target.Substring(1), pattern, dp, i-1, j);
        //            }
        //        }
        //        else
        //        {
        //            ans = isFirstMatch && IsMatch(target.Substring(1), pattern.Substring(1), dp, i-1, j-1);
        //        }
        //    }

        //    dp[i, j] = ans;
        //    return dp[i,j].Value;
        //}
    }
}
