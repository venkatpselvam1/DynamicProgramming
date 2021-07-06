using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
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
}
