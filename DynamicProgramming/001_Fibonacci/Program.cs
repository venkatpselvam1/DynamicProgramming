using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Top - down with Memoization #
            //Console.WriteLine(Fibonacci(10));
            //Console.WriteLine(FibonacciWithCache(10));
            //2. Bottom-up with Tabulation #
            Console.WriteLine(FibonacciBottomUp(10));
        }
        public static int Fibonacci(int n)
        {
            if (n <= 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            return Fibonacci(n-1) + Fibonacci(n-2);
        }
        public static int FibonacciWithCache(int n)
        {
            var arr = new int[n+1];
            return Fibonacci(n, arr);
        }
        public static int Fibonacci(int n, int[] arr)
        {
            if (n <= 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            if (arr[n] != 0)
            {
                return arr[n];
            }
            arr[n] = Fibonacci(n - 1, arr) + Fibonacci(n - 2, arr);
            return arr[n];
        }
        public static int FibonacciBottomUp(int n)
        {
            var arr = new int[n+1];
            arr[0] = 0;
            arr[1] = 1;
            arr[2] = 1;
            for (int i = 3; i < n+1; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }

            return arr[n];
        }
    }
}
