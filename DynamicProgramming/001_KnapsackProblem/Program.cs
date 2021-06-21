using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_KnapsackProblem
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
            //Print("ABCD");
            //Console.WriteLine(Swap("ABCD", 2, 3));
            var weight = new int[] { 2, 3, 1, 4 };
            var profit = new int[] { 4, 5, 3, 7 };
            var capacity = 5;
            var ans = solveKnapsack(profit, weight, capacity);
            Console.WriteLine(ans);
        }
        public static int solveKnapsack(int[] profits, int[] weights, int capacity, int ind = 0)
        {
            // TODO: Write your code here
            for (int i = ind; i < profits.Length; i++)
            {
                Swap(profits, weights, i, ind);
                //Console.WriteLine("For index ind = " + ind);
                var oriCapcity = 0;
                var oriProfit = 0;
                for (int k = 0; k <= ind; k++)
                {
                    oriCapcity += weights[k];
                    oriProfit += profits[k];
                }
                if (!(oriCapcity > capacity))
                {
                    Console.Write(oriCapcity + " : " + oriProfit+" (");
                    for (int k = 0; k <= ind; k++)
                    {
                        Console.Write(profits[k] + ", ");
                    }
                    Console.Write(") (");
                    for (int k = 0; k <= ind; k++)
                    {
                        Console.Write(weights[k] + ", ");
                    }
                    Console.WriteLine(")");
                }

                solveKnapsack(profits, weights, capacity, ind+1);
                
                Swap(profits, weights, i, ind);
            }
            return -1;
        }
        public static void Swap(int[] arr, int[] arr2, int i, int j)
        {
            if (i == j)
            {
                return;
            }
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            temp = arr2[i];
            arr2[i] = arr2[j];
            arr2[j] = temp;
        }
        public static void Print(string s, int ind = 0)
        {
            for (int i = ind; i < s.Length; i++)
            {
                var newStr = Swap(s, i, ind);
                Print(newStr, ind+1);
                if (ind == s.Length - 1)
                {
                    Console.WriteLine(newStr);
                }
            }
        }
        public static string Swap(string str, int i, int j)
        {
            if (i == j)
            {
                return str;
            }
            var ans = string.Empty;
            for (int k = 0; k < str.Length; k++)
            {
                if (k == i)
                {
                    ans += str[j];
                }
                else if(k == j)
                {
                    ans += str[i];
                }
                else
                {
                    ans += str[k];
                }
            }
            return ans;
        }
    }
}
