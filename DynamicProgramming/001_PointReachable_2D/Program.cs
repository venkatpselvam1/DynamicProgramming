using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace _001_PointReachable_2D
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new bool[5, 5] 
            {
                { true,true,true,true,true},
                { false,false,false,false,true},
                { true,true,true,true,true},
                { false,false,false,false,false},
                { true,true,true,true,true},
            };
            var start = new Point(0, 0);
            var end = new Point(4, 4);
            Console.WriteLine(IsPointReachableDFS3(arr, start, end));
        }
        public static bool IsPointReachableDFS3(bool[,] arr, Point start, Point end)
        {
            var minDist = new int?[arr.GetLength(0), arr.GetLength(0)];
            var queue = new Queue<Point>();
            queue.Enqueue(start);
            minDist[start.X, start.Y] = 0;
            while (queue.Count > 0)
            {
                var point = queue.Dequeue();
                //Console.WriteLine(point);
                var dist = minDist[point.X, point.Y].Value;
                TryAddPoint(queue, arr, point.GetLeft(), minDist, dist);
                TryAddPoint(queue, arr, point.GetRight(), minDist, dist);
                TryAddPoint(queue, arr, point.GetTop(), minDist, dist);
                TryAddPoint(queue, arr, point.GetBottom(), minDist, dist);
            }
            for (int i = 0; i < minDist.GetLength(0); i++)
            {
                for (int j = 0; j < minDist.GetLength(1); j++)
                {
                    Console.Write((minDist[i, j].HasValue ? minDist[i, j] : 0) +", ");
                }
                Console.WriteLine();
            }
            return false;
        }
        public static bool IsPointReachableDFS2(bool[,] arr, Point start, Point end)
        {
            bool[,] isVisited = new bool[arr.GetLength(0), arr.GetLength(0)];
            var queue = new Queue<Point>();
            queue.Enqueue(start);
            isVisited[start.X, start.Y] = true;
            while (queue.Count > 0)
            {
                var point = queue.Dequeue();
                Console.WriteLine(point);
                
                if (point.Equals(end))
                {
                    return true;
                }
                TryAddPoint(queue, arr, point.GetLeft(), isVisited);
                TryAddPoint(queue, arr, point.GetRight(), isVisited);
                TryAddPoint(queue, arr, point.GetTop(), isVisited);
                TryAddPoint(queue, arr, point.GetBottom(), isVisited);
            }
            return false;
        }
        public static bool IsPointReachableDFS(bool[,] arr, Point start, Point end)
        {
            var queue = new Queue<Point>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                var point = queue.Dequeue();
                Console.WriteLine(point);
                if (point.Equals(end))
                {
                    return true;
                }
                //AddPoints(queue, arr, point, start);
            }
            return false;
        }

        //private static void AddPoints(Queue<Point> queue, bool[,] arr, Point point, Point start)
        //{
        //    if (start.Equals(point))
        //    {
        //        TryAddPoint(queue, arr, point.GetLeft());
        //        TryAddPoint(queue, arr, point.GetRight());
        //        TryAddPoint(queue, arr, point.GetTop());
        //        TryAddPoint(queue, arr, point.GetBottom());
        //    }
        //    else if (start.Y == point.Y)
        //    {
        //        TryAddPoint(queue, arr, point.X > start.X ? point.GetRight() : point.GetLeft());
        //        TryAddPoint(queue, arr, point.GetTop());
        //        TryAddPoint(queue, arr, point.GetBottom());
        //    }
        //    else if (start.X == point.X)
        //    {
        //        TryAddPoint(queue, arr, point.GetLeft());
        //        TryAddPoint(queue, arr, point.GetRight());
        //        TryAddPoint(queue, arr, point.Y > start.Y ? point.GetTop() : point.GetBottom());
        //    }
        //    else
        //    {
        //        TryAddPoint(queue, arr, point.X > start.X ? point.GetRight() : point.GetLeft());
        //        TryAddPoint(queue, arr, point.Y > start.Y ? point.GetTop() : point.GetBottom());
        //    }
        //}

        private static void TryAddPoint(Queue<Point> queue, bool[,] arr, Point point, bool[,] isVisited=null)
        {
            if (point.isValid(arr) && !isVisited[point.X, point.Y] && arr[point.X, point.Y])
            {
                isVisited[point.X, point.Y] = true;
                queue.Enqueue(point);
            }
        }
        private static void TryAddPoint(Queue<Point> queue, bool[,] arr, Point point, int?[,] isVisited, int dist)
        {
            if (point.isValid(arr) && !isVisited[point.X, point.Y].HasValue && arr[point.X, point.Y])
            {
                isVisited[point.X, point.Y] = dist + 1;
                queue.Enqueue(point);
            }
        }

        public static bool IsPointReachable(bool[,] arr, Point start, Point end) 
        {
            var arrdp = new bool?[arr.GetLength(0),arr.GetLength(1)];
            return IsPointReachable(arr, start, end, arrdp);
        }
        public static bool IsPointReachable(bool[,] arr, Point start, Point end, bool?[,] arrDp)
        {
            if (!start.isValid(arr))
            {
                return false;
            }
            if (arrDp[start.X, start.Y].HasValue)
            {
                return arrDp[start.X, start.Y].Value;
            }
            arrDp[start.X, start.Y] = false;

            if (start.Equals(end))
            {
                arrDp[start.X, start.Y] = true;
                return arrDp[start.X, start.Y].Value;
            }

            if (!arr[start.X, start.Y])
            {
                arrDp[start.X, start.Y] = false;
                return false;
            }


            if (IsPointReachable(arr, start.GetLeft(), end, arrDp)
                || IsPointReachable(arr, start.GetRight(), end, arrDp)
                || IsPointReachable(arr, start.GetTop(), end, arrDp)
                || IsPointReachable(arr, start.GetBottom(), end, arrDp))
            {
                arrDp[start.X, start.Y] =  true;
                return arrDp[start.X, start.Y].Value;
            }

            arrDp[start.X, start.Y] = false;
            return arrDp[start.X, start.Y].Value;
        }
    }
}
