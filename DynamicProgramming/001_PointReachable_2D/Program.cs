using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                { true,false,false,false,false},
                { true,true,true,true,true},
            };
            var start = new Point() 
            {
                X = 0, Y=0
            };
            var end = new Point()
            {
                X = 4,
                Y = 4
            };
            Console.WriteLine(IsPointReachable(arr, start, end));
        }
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public bool Equals(Point obj)
            {
                return obj.X == this.X && obj.Y == this.Y;
            }
            public Point GetLeft()
            {
                return new Point() 
                {
                    X = this.X - 1,
                    Y = this.Y
                };
            }
            public Point GetRight()
            {
                return new Point()
                {
                    X = this.X + 1,
                    Y = this.Y
                };
            }
            public Point GetTop()
            {
                return new Point()
                {
                    X = this.X,
                    Y = this.Y + 1
                };
            }
            public Point GetBottom()
            {
                return new Point()
                {
                    X = this.X,
                    Y = this.Y - 1
                };
            }
            public bool isValid(bool[,] arr)
            {
                return this.X >= 0 && this.X < arr.GetLength(0) && this.Y >= 0 && this.Y < arr.GetLength(1);
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
