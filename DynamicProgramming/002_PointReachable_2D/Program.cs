using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_PointReachable_2D
{
    class Program
    {
        static void Main(string[] args)
        {
            // in this programming we will find the min distance b/w the given two points in the 2D array using BFS
            // e.g.
            //.......s.....
            //....e........
            //.............
            //.............
            //.............

            // ans = 4 as the S has to come one down and 3 left
            // S - start, E - end, . - normal point, x-not enter point
            var map = new char[7,7] 
            {
                { '.','.','.','S','.','.','.' },
                { '.','.','.','X','X','.','.' },
                { '.','.','.','.','.','.','.' },
                { '.','.','.','.','.','.','.' },
                { '.','.','.','.','.','.','.' },
                { '.','.','.','X','X','X','X' },
                { '.','.','.','.','.','X','E' },
            };
            var ans = GetMinDist(map);
            Console.WriteLine("Ans is : " + ans);
        }

        private static int GetMinDist(char[,] map)
        {
            int w = map.GetLength(0);
            int h = map.GetLength(1);
            var minDist = new int?[w, h];
            (var start, var end) = GetStartEndPoints(map);
            if (end == null)
            {
                return 0;
            }
            var queue = new Queue<Point>();
            queue.Enqueue(start);
            minDist[start.X, start.Y] = 0;
            while (queue.Count > 0)
            {
                var point = queue.Dequeue();
                var dist = minDist[point.X, point.Y].Value;
                if (point.Equals(end))
                {
                    break;
                }
                TryAddToQueue(w, h, queue, point.GetLeft(), minDist, dist, map);
                TryAddToQueue(w, h, queue, point.GetRigth(), minDist, dist, map);
                TryAddToQueue(w, h, queue, point.GetTop(), minDist, dist, map);
                TryAddToQueue(w, h, queue, point.GetBottom(), minDist, dist, map);
            }

            Console.WriteLine("--------------------------");
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    Console.Write((minDist[i, j] ?? 0)+",");
                }
                Console.WriteLine();
            }
            Console.WriteLine("--------------------------");

            return minDist[end.X, end.Y] ?? 0;
        }

        private static void TryAddToQueue(int w, int h, Queue<Point> queue, Point point, int?[,] minDist, int dist, char[,] map)
        {
            if (point.IsValid(w, h) && !minDist[point.X, point.Y].HasValue && map[point.X, point.Y] != 'X')
            {
                minDist[point.X, point.Y] = dist+1;
                queue.Enqueue(point);
            }
        }

        private static (Point, Point) GetStartEndPoints(char[,] map)
        {
            Point start = new Point(0, 0);
            Point end = null;
            var points = new Point[map.GetLength(0), map.GetLength(1)];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    points[i, j] = new Point(i, j);
                    if (map[i, j] == 'S')
                    {
                        start = points[i, j];
                    }
                    else if (map[i, j] == 'E')
                    {
                        end = points[i, j];
                    }
                }
            }
            return (start, end);
        }

        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
            public Point GetLeft()
            {
                return new Point(this.X-1, this.Y);
            }
            public Point GetRigth()
            {
                return new Point(this.X+1, this.Y);
            }
            public Point GetTop()
            {
                return new Point(this.X, this.Y + 1);
            }
            public Point GetBottom()
            {
                return new Point(this.X, this.Y - 1);
            }
            // override object.Equals
            public bool Equals(Point obj)
            {
                return obj.X == this.X && obj.Y == this.Y;
            }
            public bool IsValid(int w, int h)
            {
                return !(this.X < 0 || this.Y < 0 || this.X >= w || this.Y >= h);
            }
        }
    }
}
