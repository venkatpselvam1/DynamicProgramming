using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_ugly_number_dynamic_tabulation
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
            /*
                sequence to three groups as below: 
                 (ind1) 1×2, 2×2, 3×2, 4×2, 5×2, … 
                 (ind2) 1×3, 2×3, 3×3, 4×3, 5×3, … 
                 (ind3) 1×5, 2×5, 3×5, 4×5, 5×5, …

                For the index : 1, 2, 3, 4, 5, 6, 7, ...
                The values   1: 1 - the first number. directly return 1        => 1
                The values   2: Math.Min( ind1 - 1, ind2 -1 , ind3 - 1)ind1++  => 2
                The values   3: Math.Min( ind1 - 2, ind2 -1 , ind3 - 1)ind2++  => 3
                The values   4: Math.Min( ind1 - 2, ind2 -2 , ind3 - 1)ind1++  => 4
                The values   5: 1 - the first number. directly return 1

              */
            for (int i = 1; i < 151; i++)
            {
                var uglyNubmer = GetUglyNumber(i);
                Console.WriteLine(uglyNubmer);
            }
            
        }
        public static int GetUglyNumber(int n)
        {
            var uglys = new int[n];
            uglys[0] = 1;
            int ind1 = 0, ind2 = 0, ind3 = 0;
            for (int i = 1; i < n; i++)
            {
                uglys[i] = Math.Min(Math.Min(uglys[ind1] * 2, uglys[ind2] * 3), uglys[ind3] * 5);
                if (uglys[i] == uglys[ind1] * 2)
                {
                    ind1++;
                }
                if (uglys[i] == uglys[ind2] * 3)
                {
                    ind2++;
                }
                if (uglys[i] == uglys[ind3] * 5)
                {
                    ind3++;
                }
            }
            return uglys[n - 1];
        }
    }
}
