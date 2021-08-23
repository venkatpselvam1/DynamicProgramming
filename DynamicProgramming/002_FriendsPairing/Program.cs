using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_FriendsPairing
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Input  : n = 3
                Output : 4
                Explanation:
                {1}, {2}, {3} : all single
                {1}, {2, 3} : 2 and 3 paired but 1 is single.
                {1, 2}, {3} : 1 and 2 are paired but 3 is single.
                {1, 3}, {2} : 1 and 3 are paired but 2 is single.
                Note that {1, 2} and {2, 1} are considered same.
             */

            /*
             * f(n) = ways n people can remain single or pair up.
                * 
                * For n-th person there are two choices:
                * 1) n-th person remains single, we recur 
                *    for f(n - 1)
                * 2) n-th person pairs up with any of the 
                *    remaining n - 1 persons. We get (n - 1) * f(n - 2)
                * 
                * Therefore we can recursively write f(n) as:
                * f(n) = f(n - 1) + (n - 1) * f(n - 2)
             */
            var sln = new Solution();
            var ans = sln.GetFriendsPairing(4);
            Console.WriteLine(ans);
        }
        public class Solution
        {
            public int GetFriendsPairing(int n)
            {
                var dp = new int[n+1];
                dp[0] = 0;
                dp[1] = 1;
                dp[2] = 2;
                for (int i = 3; i <= n; i++)
                {
                    dp[i] = dp[i-1] + (i-1) * dp[i-2];
                }

                for (int i = 0; i < n+1; i++)
                {
                    Console.Write(dp[i]+", ");
                }
                Console.WriteLine();
                return dp[n];
            }
            
        }
    }
}
