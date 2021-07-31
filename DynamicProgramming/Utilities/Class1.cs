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
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public bool Equals(Point obj)
        {
            return obj.X == this.X && obj.Y == this.Y;
        }
        public Point GetLeft()
        {
            return new Point(this.X - 1, this.Y);
        }
        public Point GetRight()
        {
            return new Point(this.X + 1, this.Y);
        }
        public Point GetTop()
        {
            return new Point(this.X, this.Y + 1);
        }
        public Point GetBottom()
        {
            return new Point(this.X, this.Y - 1);
        }
        public bool isValid(bool[,] arr)
        {
            return this.X >= 0 && this.X < arr.GetLength(0) && this.Y >= 0 && this.Y < arr.GetLength(1);
        }
        public override string ToString()
        {
            return $"X = {this.X}, Y = {this.Y}"; 
        }
    }
}
