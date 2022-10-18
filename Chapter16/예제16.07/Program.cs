using System;

class Point
{
    public int X;
    public int Y;

    public override string ToString() => $"({X}, {Y})";

    public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
}

class Program
{
    static void Main(string[] args)
    {
        {
            Console.WriteLine(Even(1));
            Console.WriteLine(Even(2));
        }

        Console.WriteLine();

        {
            Func<Point, bool> detectZeroOR = (pt) =>
            {
                switch (pt)
                {
                    case { X: 0, Y: 0 }:
                    case { X: 0 }:
                    case { Y: 0 }:
                        return true;
                }

                return false;
            };

            Point pt = new Point { X = 10, Y = 20 };
            Console.WriteLine(detectZeroOR(pt));

            if (pt is { X: 500 })
            {
                Console.WriteLine(pt.X + " == 500");
            }

            if (pt is { X: 10, Y: 0 })
            {
                Console.WriteLine(pt.X + " == 10");
            }
        }

        Console.WriteLine();

        {
            Func<(int, int), bool> detectZeroOR = (arg) =>
                (arg) switch
                {
                    { Item1: 0, Item2: 0 } => true,
                    { Item1: 0 } => true,
                    { Item2: 0 } => true,
                    _ => false,
                };

            Console.WriteLine(detectZeroOR((10, 0)));
        }

        Console.WriteLine();

        {
            Func<(int, int), bool> detectZeroOR = (arg) =>
                (arg) switch
                {
                    (0, 0) => true,
                    (0, _) => true,
                    (_, 0) => true,
                    _ => false,
                };

            Console.WriteLine(detectZeroOR((0, 10)));
        }

        Console.WriteLine();

        {
            Func<(int, int), bool> detectZeroOR = (arg) =>
                arg switch
                {
                    (var X, var Y) when (X == 0 && Y == 0) || X == 0 || Y == 0 => true,
                    _ => false,
                };

            Console.WriteLine(detectZeroOR((0, 0)));
        }

        Console.WriteLine();

        {
            Func<Point, bool> detectZeroOR = (pt) =>
                (pt.X, pt.Y) switch
                {
                    (0, 0) => true,
                    (0, _) => true,
                    (_, 0) => true,
                    _ => false,
                };

            Point pt = new Point { X = 0, Y = 20 };
            Console.WriteLine(detectZeroOR(pt));
        }

        Console.WriteLine();

        {
            Func<Point, bool> detectZeroOR = (pt) =>
                pt switch
                {
                    (0, 0) => true,
                    (0, _) => true,
                    (_, 0) => true,
                    _ => false,
                };

            Point pt = new Point { X = 20, Y = 20 };
            Console.WriteLine(detectZeroOR(pt));

            bool zeroDetected = (pt is (0, 0) || pt is (0, _) || pt is (_, 0));
            Console.WriteLine(zeroDetected);
        }

        Console.WriteLine();

        {
            Matrix2x2 mat = new Matrix2x2 { V1 = new Vector(0, 0), V2 = new Vector(0, 0) };

            if (mat is ((0, 0), (0, 0)))
            {
                Console.WriteLine("Zero");
            }
        }
    }

    public static bool Even(int n) =>
        n switch
        {
            var x when (x % 2) == 1 => false,
            _ => true
        };

    /* 또는
    public static bool Even(int n) =>
        (n % 2) switch
        {
            1 => false,
            _ => true
        }; */

    readonly struct Vector
    {
        readonly public int X;
        readonly public int Y;

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
    }

    struct Matrix2x2
    {
        public Vector V1;
        public Vector V2;

        public void Deconstruct(out Vector v1, out Vector v2) => (v1, v2) = (V1, V2);
    }

    enum MatrixType
    {
        Any, Zero, Identity, Row1Zero,
    }

    static MatrixType GetMatrixType(Matrix2x2 mat)
    {
        switch (mat)
        {
            case ((0, 0), (0, 0)):
                return MatrixType.Zero;

            case ((1, 0), (0, 1)):
                return MatrixType.Identity;

            case ((0, 0), _):
                return MatrixType.Row1Zero;

            default: return MatrixType.Any;

        }
    }

    static MatrixType GetMatrixType2(Matrix2x2 mat) =>
        mat switch
        {
            ((0, 0), (0, 0)) => MatrixType.Zero,
            ((1, 0), (0, 1)) => MatrixType.Identity,
            ((0, 0), _) => MatrixType.Row1Zero,
            _ => MatrixType.Any
        };


}
