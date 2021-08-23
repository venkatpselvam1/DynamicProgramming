using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_FriendsPairing
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
                return GetFriendsPairing(n, new int[n+1]);
            }
            public int GetFriendsPairing(int n, int[] dp)
            {
                if (dp[n] != 0)
                {
                    return dp[n];
                }
                if (n <= 2)
                {
                    return n;
                }

                dp[n] = GetFriendsPairing(n - 1, dp) + (n - 1) * GetFriendsPairing(n - 2, dp);
                return dp[n];
            }
        }
    }
}
