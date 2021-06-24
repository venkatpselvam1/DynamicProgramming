using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_ugly_number_normal
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Ugly numbers are numbers whose only prime factors are 2, 3 or 5.
                The sequence 1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 15, … shows the first 11 ugly numbers.
                By convention, 1 is included. Given a number n, the task is to find n’th Ugly number.
             */

            /*
             Example:
                Input  : n = 7
                Output : 8

                Input  : n = 10
                Output : 12

                Input  : n = 15
                Output : 24

                Input  : n = 150
                Output : 5832
             */
            var uglyNumber = GetUglyNumber(150);
            Console.WriteLine(uglyNumber);
        }
        public static int GetUglyNumber(int n)
        {
            var ans = 1;
            var count = 1;
            while (count < n)
            {
                ans++;
                if (IsUglyNumber(ans))
                {
                    count++;
                }
            }
            return ans;
        }
        public static bool IsUglyNumber(int n)
        {
            n = MaxDivide(n, 2);
            n = MaxDivide(n, 3);
            n = MaxDivide(n, 5);
            return n == 1;
        }
        public static int MaxDivide(int n, int divider)
        {
            while (n%divider == 0)
            {
                n = n / divider;
            }
            return n;
        }
    }
}
