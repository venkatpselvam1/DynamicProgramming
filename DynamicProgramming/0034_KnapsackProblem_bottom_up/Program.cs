using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_KnapsackProblem_bottom_up
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Given the weights and profits of ‘N’ items, we are asked to put these items in a knapsack that has a capacity ‘C’. The goal is to get the maximum profit from the items in the knapsack. Each item can only be selected once, as we don’t have multiple quantities of any item.

                Let’s take Merry’s example, who wants to carry some fruits in the knapsack to get maximum profit. Here are the weights and profits of the fruits:

                Items: { Apple, Orange, Banana, Melon }
                Weights: { 2, 3, 1, 4 }
                Profits: { 4, 5, 3, 7 }
                Knapsack capacity: 5

                Let’s try to put different combinations of fruits in the knapsack, such that their total weight is not more than 5:

                Apple + Orange (total weight 5) => 9 profit
                Apple + Banana (total weight 3) => 7 profit
                Orange + Banana (total weight 4) => 8 profit
                Banana + Melon (total weight 5) => 10 profit

                This shows that Banana + Melon is the best combination, as it gives us the maximum profit and the total weight does not exceed the capacity.
             */
            /*
             Knapsack problem solve slution.
                => To find the fact of a no, Fact(n)= n * Fact(n-1)
                => To find the fib of the given index=> Fib(n) = Fib(n-1) + Fib(n-2)
                => to find the maximum profit for the given array of profit, weight
                        => Math.Max(WithThisIndex , WithoutthisIndex)
                        => Math.Max(profit of this index + FindMaxProfit(capacity - weight) , WithoutthisIndex)
             */
            var weight = new int[] { 2, 3, 1, 4 };
            var profit = new int[] { 4, 5, 3, 7 };
            var capacity = 5;
            var ans = knapsackSolution(profit, weight, capacity);
            Console.WriteLine(ans);
        }

        private static int knapsackSolution(int[] profits, int[] weights, int capacity)
        {
            var dp = new int[profits.Length, capacity+1];
            for (int c = 1; c < capacity + 1; c++)
            {
                if (weights[0]<=c)
                {
                    dp[0, c] = profits[0];
                }
            }

            for (int ind = 1; ind < profits.Length; ind++)
            {
                for (int c = 1; c < capacity+1; c++)
                {
                    var profit1 = 0;
                    if (weights[ind] <= c)
                    {
                        profit1 = profits[ind] + dp[ind - 1, c - weights[ind]];
                    }
                    var profit2 = dp[ind-1, c];
                    dp[ind,c]= Math.Max(profit1, profit2);
                }
            }
            return dp[profits.Length-1, capacity];
        }
    }
}
