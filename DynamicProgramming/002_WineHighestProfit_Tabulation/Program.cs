using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_WineHighestProfit_Tabulation
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             We have wine rack where the wine bottles are arranged in line.
             You can either take wine from the start of the list or end of the list.
             Each wine bottle have the price `pi` which indicates the price of the wine.
             you are allowed to sell one wine bottle per year. Each year, the wine price will increase by `pi`.

             For e.g.:
                I have wine bottle A and B.
                A costs 5 ans B costs 3.
                After one year, A costs 5*2 and B costs 3*2
                After one more year, A costs 5*3 and B costs 3*3

             To gain the maximum profit, we need to sell the cheaper wine first and costlier wine later.

             If we try to solve the problem by greedy algorithm(Each time take the cheapest of the first and last),
             it will be false.
             
             e.g. 9, 8, 8, 8, 1, 1, 1, 10
             if we use the greedy algorithm ans is : --------179----------
             but the correct ans is : -----------------------235----------
                    => 10 * 1
                    =>  1 * 2
                    =>  1 * 3
                    =>  1 * 4
                    =>  8 * 5
                    =>  8 * 6
                    =>  8 * 7
                    =>  9 * 8
             */
            //var arr = new int[] {1, 2, 3, 4, 5 };
            //var arr = new int[] { 9, 8, 8, 8, 1, 1, 1, 10 };
            var arr = new int[] { 10, 9, 8, 7, 21 };
            var sln = new Solution();
            var ans = sln.GetMaxProfit(arr);
            Console.WriteLine(ans);
        }
        public class Solution
        {
            public int GetMaxProfit(int[] nums)
            {
                var dp = new int[nums.Length, nums.Length];
                for (int i = nums.Length; i > 0; i--)
                {
                    for (int j = 0; j < i; j++)
                    {
                        var k = j + nums.Length - i;
                        if (i == nums.Length)
                        {
                            dp[j, k] = nums[j] * i;
                        }
                        else
                        {
                            var a = dp[j, k-1] + i * nums[k];
                            var b = dp[j+1, k] + i * nums[j];
                            dp[j, k] = Math.Max(a, b);
                        }
                        Console.Write(j+", "+k+" | ");
                    }
                    Console.WriteLine();
                }
                return dp[0, nums.Length-1];
            }
        }
    }
}
