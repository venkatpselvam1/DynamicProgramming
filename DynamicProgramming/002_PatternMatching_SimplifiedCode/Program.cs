using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_PatternMatching_SimplifiedCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(IsMatch("abcd", ".a..d") + " : False");
            //Console.WriteLine(IsMatch("abcd", "a..d") + " : True");
            //Console.WriteLine(IsMatch("aabc", "a*abc") + " : True");
            //Console.WriteLine(IsMatch("mississippi", "mis*is*p*.") + " : False");
            //Console.WriteLine(IsMatch("aa", "a*") + " : True");
            //Console.WriteLine(IsMatch("a", "ab*") + " : True");
            //Console.WriteLine(IsMatch("", "c*") + " : True");
            //Console.WriteLine(IsMatch("a", "a*a") + " : True");
            //Console.WriteLine(IsMatch("bbbba", ".*a*a") + " : True");
            //Console.WriteLine(IsMatch("abcdede", "ab.*de") + " : True");
            Console.WriteLine(IsMatch("ab", ".*c") + " : True");
        }
        public static bool IsMatch(string target, string pattern)
        {
            // The idea here is, if the patter is empty,
            //      => if the target also empty => it is a match
            //      => if the target is not empty it is not a match
            // If the pattern contains * at the second position
            //      => we have two possibility
            //          1. the target and pattern-2(char) is a match(* indicates 0 or more. give precedence to 0 first.)
            //          2. the target-1(char) and the pattern is a match (provided isFirstMatches)
            //      => lets say our target don't have * at the second position
            //          1. Check if the firstMatches and target-1(char) and pattern-1(char) matches
            if (string.IsNullOrEmpty(pattern))
            {
                return string.IsNullOrEmpty(target);
            }
            var isFirstMatch = !string.IsNullOrEmpty(target) && (target[0].Equals(pattern[0]) || pattern[0].Equals('.'));
            if (pattern.Length >= 2 && pattern[1].Equals('*'))
            {
                return IsMatch(target, pattern.Substring(2)) || (isFirstMatch && IsMatch(target.Substring(1), pattern));
            }
            return isFirstMatch && IsMatch(target.Substring(1), pattern.Substring(1));
        }
    }
}
