using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_WineHighestProfit
{
    class Program
    {
        static int Length = 1;
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
            var arr = new int[] { 9, 8, 8, 8, 1, 1, 1, 10 };
            var ans = GetMaxProfit(arr);
            Console.WriteLine(ans);
        }
        public static int GetMaxProfit(int[] price)
        {
            Length = price.Length;
            var dp = new int?[price.Length, price.Length];
            var ans =  GetMaxProfit(price, 0, Length - 1, dp);
            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    Console.Write(dp[i, j]+", ");
                }
                Console.WriteLine();
            }
            return ans;
        }
        public static int GetMaxProfit(int[] price, int start, int end, int?[,] dp)
        {
            if (dp[start, end].HasValue)
            {
                return dp[start, end].Value;
            }
            if (start == end)
            {
                dp[start, end] = Length * price[start];
            }
            else
            {
                var yearsOld = Length -(end - start);
                var p1 = yearsOld * price[start] + GetMaxProfit(price, start+1, end, dp);
                var p2 = yearsOld * price[end] + GetMaxProfit(price, start, end -1, dp);
                dp[start, end] = Math.Max(p1, p2);
            }

            return dp[start, end].Value;
        }
    }
}
