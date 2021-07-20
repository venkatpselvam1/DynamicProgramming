using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_ValidParenthesesLength
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Input: s = ")()())"
                Output: 4
                Explanation: The longest valid parentheses substring is "()()".
             */
            Console.WriteLine(ValidParenthesesLength("()(())"));
        }
        public static int ValidParenthesesLength(string str)
        {
            var dp = new int[str.Length];
            var ans = 0;
            for (int i = 0; i < str.Length; i++)
            {
                var ch = str[i];
                if (ch == '(')
                {
                    dp[i] = 0;
                }
                else
                {
                    int j = i - 1;
                    if (j >= 0)
                    {
                        if (str[j] == '(')
                        {
                            dp[i] = i - 2 >= 0 ? dp[i - 2] + 2 : 2;
                        }
                        else
                        {
                            int k = i - dp[j]-1;
                            if (k >= 0 && str[k] == '(')
                            {
                                dp[i] = dp[j] + 2;
                                if (k-1 >= 0)
                                {
                                    dp[i] += dp[k-1];
                                }
                            }
                        }
                    }
                }
                ans = dp[i] > ans ? dp[i] : ans;
            }
            return ans;
        }
    }
}
