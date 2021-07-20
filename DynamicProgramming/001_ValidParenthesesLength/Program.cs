using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_ValidParenthesesLength
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
            Console.WriteLine(ValidParenthesesLength(")()())"));
        }
        public static int ValidParenthesesLength(string str)
        {
            var stack = new Stack<Node>();

            for(int i =0;i < str.Length; i++)
            {
                var ch = str[i];
                if (stack.Count > 0 && ch == ')' && stack.Peek().Ch == '(')
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(new Node() { Ch= ch, Ind = i });
                }
            }

            var ans = 0;
            if (stack.Count == 0)
            {
                return str.Length;
            }
            if (stack.Count == str.Length)
            {
                return 0;
            }
            int prev = str.Length;
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                var length = prev - node.Ind - 1;
                if (length > ans)
                {
                    ans = length;
                }
                prev = node.Ind;
            }
            if (prev > ans)
            {
                ans = prev;
            }
            return ans;
        }
        public class Node
        {
            public char Ch;
            public int Ind;
        }
    }
}
