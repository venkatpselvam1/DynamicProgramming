using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_PatternMatching
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
            Console.WriteLine(IsMatch("abcdede", "ab.*de") + " : True");
        }
        public static bool IsMatch(string target, string pattern)
        {
            if (target.Equals(pattern) || pattern.Equals(".*"))
            {
                return true;
            }
            if (pattern.Equals(string.Empty) || (target.Equals(string.Empty) && !(pattern.Length >= 2 && pattern[1].Equals('*'))))
            {
                return false;
            }
            if (pattern.Length == 2 && pattern[1].Equals('*'))
            {
                return GetStr(pattern[0].ToString(), target.Length).Equals(target);
            }
            if (pattern.Length >= 2 && pattern[1].Equals('*'))
            {
                var count = 0;
                var length = target.Length;
                while (count <= length)
                {
                    var firstPart = target.Substring(0, count);
                    var secondPart = target.Substring(count);
                    if (IsMatch(firstPart, pattern.Substring(0, 2)) && IsMatch(secondPart, pattern.Substring(2)))
                    {
                        return true;
                    }
                    count++;
                }
                return false;
            }
            if (target[0].Equals(pattern[0]) || pattern[0].Equals('.'))
            {
                return IsMatch(target.Substring(1), pattern.Substring(1));
            }

            return false;
        }
        public static string GetStr(string a, int count)
        {
            var b = string.Empty;
            for (int i = 0; i < count; i++)
            {
                b += a;
            }
            return b;
        }
    }
}
