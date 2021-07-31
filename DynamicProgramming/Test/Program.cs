using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            //var arr = new int[3][] 
            //{
            //    new int[]{ 1, 0, 0},
            //    new int[]{ 1, 0, 0},
            //    new int[]{ 1, 0, 0},
            //};
            var arr = new int[10][]
            {new int[]{
1,1,0,0,1,0,0,1,1,0},
new int[]{
1,0,0,1,0,1,1,1,1,1},
new int[]{
1,1,1,0,0,1,1,1,1,0},
new int[]{
0,1,1,1,0,1,1,1,1,1},
new int[]{
0,0,1,1,1,1,1,1,1,0},
new int[]{
1,1,1,1,1,1,0,1,1,1},
new int[]{
0,1,1,1,1,1,1,0,0,1},
new int[]{
1,1,1,1,1,0,0,1,1,1},
new int[]{
0,1,0,1,1,0,1,1,1,1},
new int[]{
1,1,1,0,1,0,1,1,1,1}};
            var ans = sln.UpdateMatrix(arr);

            foreach (var item in ans)
            {
                foreach (var num in item)
                {
                    Console.Write(num+", ");
                }
                Console.WriteLine();
            }
        }

        public class Solution1
        {
            public int[][] UpdateMatrix(int[][] mat)
            {
                var w = mat.Length;
                var h = mat[0].Length;
                var ans = new int[w][];
                for (int i = 0; i < w; i++)
                {
                    ans[i] = new int[h];
                }
                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        if (mat[i][j] != 0)
                        {
                            ans[i][j] = GetMinDis(mat, i, j);
                        }

                    }
                }
                return ans;
            }

            public int GetMinDis(int[][] mat, int w, int h)
            {
                var ans = int.MaxValue;
                for (int i = 0; i < mat.Length; i++)
                {
                    for (int j = 0; j < mat[0].Length; j++)
                    {
                        if (mat[i][j] == 0)
                        {
                            var val = Math.Abs(i - w) + Math.Abs(j - h);
                            if (val == 1)
                            {
                                return 1;
                            }
                            if (val < ans)
                            {
                                ans = val;
                            }
                        }
                    }
                }
                return ans;
            }
        }

        public class Solution
        {
            public int[][] UpdateMatrix(int[][] mat)
            {
                var w = mat.Length;
                var h = mat[0].Length;
                var ans = new int[w][];
                for (int i = 0; i < w; i++)
                {
                    ans[i] = new int[h];
                    for (int j = 0; j < h; j++)
                    {
                        ans[i][j] = int.MaxValue;
                    }
                }

                // we will use the BFS here,
                // we first find the cell(node) whose value is zero.
                // for each node, we add all the side nods to queue(if value = int.max) and we update the status
                // for each node, we will update the min value including(already explored nodes too)
                int m = 0, n = 0;
                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        if (mat[i][j] == 0)
                        {
                            m = i;n = j;
                            var queue = new Queue<Node>();
                            var origin = new Node() { x = m, y = n };
                            queue.Enqueue(origin);
                            ans[m][n] = 0;
                            while (queue.Count != 0)
                            {
                                var node = queue.Dequeue();
                                AddAdjacentNodes(w, h, queue, node, origin, mat);
                                var val = ans[node.x][node.y] + 1;
                                if (ValidPoint(node.x + 1, node.y, w, h))
                                {
                                    if (mat[node.x + 1][node.y] == 0)
                                    {
                                        ans[node.x + 1][node.y] = 0;
                                    }
                                    else
                                    {
                                        ans[node.x + 1][node.y] = Math.Min(val, ans[node.x + 1][node.y]);
                                    }
                                }
                                if (ValidPoint(node.x, node.y + 1, w, h))
                                {
                                    if (mat[node.x][node.y + 1] == 0)
                                    {
                                        ans[node.x][node.y + 1] = 0;
                                    }
                                    else
                                    {
                                        ans[node.x][node.y + 1] = Math.Min(val, ans[node.x][node.y + 1]);
                                    }
                                }
                                if (ValidPoint(node.x - 1, node.y, w, h))
                                {
                                    if (mat[node.x - 1][node.y] == 0)
                                    {
                                        ans[node.x - 1][node.y] = 0;
                                    }
                                    else
                                    {
                                        ans[node.x - 1][node.y] = Math.Min(val, ans[node.x - 1][node.y]);
                                    }
                                }
                                if (ValidPoint(node.x, node.y - 1, w, h))
                                {
                                    if (mat[node.x][node.y - 1] == 0)
                                    {
                                        ans[node.x][node.y - 1] = 0;
                                    }
                                    else
                                    {
                                        ans[node.x][node.y - 1] = Math.Min(val, ans[node.x][node.y - 1]);
                                    }
                                }
                            }
                        }
                    }
                }


                return ans;
            }

            private void AddAdjacentNodes(int w, int h, Queue<Node> queue, Node node, Node origin, int[][] mat)
            {
                if (origin.x == node.x && origin.y == node.y)
                {
                    ValidAndAdd(node.x + 1, node.y, w, h, queue, mat);
                    ValidAndAdd(node.x - 1, node.y, w, h, queue, mat);
                    ValidAndAdd(node.x, node.y + 1, w, h, queue, mat);
                    ValidAndAdd(node.x, node.y - 1, w, h, queue, mat);
                    return;
                }
                if (origin.y == node.y)
                {
                    if (origin.x < node.x)
                    {
                        ValidAndAdd(node.x + 1, node.y, w, h, queue, mat);
                    }
                    else
                    {
                        ValidAndAdd(node.x - 1, node.y, w, h, queue, mat);
                    }
                    ValidAndAdd(node.x, node.y + 1, w, h, queue, mat);
                    ValidAndAdd(node.x, node.y - 1, w, h, queue, mat);
                }
                else if (origin.x == node.x)
                {
                    if (origin.y < node.y)
                    {
                        ValidAndAdd(node.x, node.y + 1, w, h, queue, mat);
                    }
                    else
                    {
                        ValidAndAdd(node.x, node.y - 1, w, h, queue, mat);
                    }
                    ValidAndAdd(node.x + 1, node.y, w, h, queue, mat);
                    ValidAndAdd(node.x - 1, node.y, w, h, queue, mat);
                }
                else
                {
                    if (origin.x < node.x)
                    {
                        ValidAndAdd(node.x + 1, node.y, w, h, queue, mat);
                    }
                    else
                    {
                        ValidAndAdd(node.x - 1, node.y, w, h, queue, mat);

                    }

                    if (origin.y < node.y)
                    {
                        ValidAndAdd(node.x, node.y + 1, w, h, queue, mat);

                    }
                    else
                    {
                        ValidAndAdd(node.x, node.y - 1, w, h, queue, mat);
                    }
                }

            }

            public void ValidAndAdd(int x, int y, int m, int n, Queue<Node> queue, int[][] mat)
            {
                if (!ValidPoint(x, y, m, n) || mat[x][y] == 0)
                {
                    return;
                }
                queue.Enqueue(new Node() { x = x, y = y });
            }

            private static bool ValidPoint(int x, int y, int m, int n)
            {
                return !( x < 0 || y < 0 || x >= m || y >= n);
            }

            public class Node
            {
                public int x;
                public int y;
            }
        }
    }
}
