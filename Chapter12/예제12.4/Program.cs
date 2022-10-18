using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 예제12._4
{
    class Rectangle
    {
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }

        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        internal void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }

        internal void Deconstruct(out int x, out int y, out int width, out int height)
        {
            x = X;
            y = Y;
            width = Width;
            height = Height;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(5, 6, 20, 25);
            {
                (int x, int y) = rect;
                Console.WriteLine($"x == {x}, y == {y}");
            }

            {
                (int _, int _) = rect;

                (int _, int y) = rect;
                Console.WriteLine($"y == {y}");
            }

            {
                (int x, int y, int width, int height) = rect;
                Console.WriteLine($"x == {x}, y == {y}, width  = {width}, height = {height}");

                (int _, int _, int _, int _) = rect;

                (int _, int _, int w, int h) = rect;
                Console.WriteLine($"w == {w}, h == {h}");

                (var _, var _, var _, var last) = rect;
                Console.WriteLine($"last == {last}");
            }

        }
    }
}
