
using System;
using System.Collections.Generic;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        {
            Point pt1 = new(5, 6);
            Point pt2 = new(5, 6);

            Dictionary<Point, bool> dict = new Dictionary<Point, bool>();

            dict[pt1] = true;
            Console.WriteLine(dict[pt1]);

            dict[pt2] = false;
            Console.WriteLine(dict[pt1]);

            (int x, int y) = pt1;
        }

        {
            PointF pt1 = new() { X = 5, Y = 6 };
            PointF pt2 = new() { X = 5, Y = 6 };

            Dictionary<PointF, bool> dict = new Dictionary<PointF, bool>();

            dict[pt1] = true;
            Console.WriteLine(dict[pt1]);

            dict[pt2] = false;
            Console.WriteLine(dict[pt1]);
        }

        {
            Vector vt1 = new Vector(3.0f, 5.0f);
            Vector vt2 = new Vector() { X = 3.0f, Y = 5.0f };
        }

        {
            PointF pt = new PointF() { X = 3.0f, Y = 5.0f };

            // 전통적인 방식으로 불변 개체의 값을 변경
            PointF pt1 = new PointF() { X = pt.X + 2.0f, Y = pt.Y + 2.0f };

            // 새로운 방식으로 불변 개체의 값을 변경
            PointF pt2 = pt with { X = pt.X + 2.0f };
            PointF pt3 = pt with { Y = pt.Y + 3.0f };
            PointF pt4 = pt with { X = pt.X + 2.0f, Y = pt.Y + 3.0f };
        }

        {
            Point3D pt1 = new Point3D(5.0f, 6.0f, 3.5f);
            (float x, float y, float z) = pt1;

            Point3D pt2 = pt1 with { Y = 3.5f };
        }

        {
            Point3D pt1 = new Point3D() { X = 5.0f, Y = 6.0f, Z = 7.0f };
            (float x, float y, float z) = pt1;

            Point3D pt2 = pt1 with { Y = 3.5f };
        }
    }
}

public record PointF
{
    public float X { get; init; }
    public float Y { get; init; }
}


public record Point3D(float X, float Y, float Z)
{
    public Point3D() : this(0.0f, 0.0f, 0.0f) { }
}

public class Vector
{
    public float X { get; init; }
    public float Y { get; init; }

    public Vector() { }

    public Vector(float x, float y)
    {
        X = x;
        Y = y;
    }

    public void Increment(float x, float y)
    {
        // 컴파일 오류
        // Error CS8852 Init - only property or indexer 'Vector.X' can only be assigned in an object initializer, or on 'this' or 'base' in an instance constructor or an 'init' accessor.
        // this.X += x;
        // this.Y += y;
    }
}

public class Point
{
    // get / private set 조합으로 정의
    public int X { get; }
    public int Y { get; }

    /* 또는, 다음과 같이 정의
    readonly int _x;
    readonly int _y;

    public int X => _x;
    public int Y => _y;
    */

    public void Deconstruct(out int x, out int y)
    {
        x = X;
        y = Y;
    }

    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public Point Move(int x, int y)
    {
        return new Point(this.X + x, this.Y + y);
    }

    public override int GetHashCode()
    {
        return X ^ Y;
    }

    public override bool Equals(object obj)
    {
        return this.Equals(obj as Point);
    }

    public virtual bool Equals(Point other)
    {
        if (object.ReferenceEquals(other, null))
        {
            return false;
        }

        return (this.X == other.X && this.Y == other.Y);
    }

    public static bool operator ==(Point r1, Point r2)
    {
        if (object.ReferenceEquals(r1, null))
        {
            if (object.ReferenceEquals(r2, null))
            {
                return true;
            }

            return false;
        }

        return r1.Equals(r2);
    }

    public static bool operator !=(Point r1, Point r2)
    {
        return !r1.Equals(r2);
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} {{ X = {X}, Y = {Y} }}";
    }
}

#if !NET5_0
// .NET 5.0 환경이 아닌 경우 IsExternalInit 클래스를 별도로 정의해서 컴파일 가능하게 만듦
namespace System.Runtime.CompilerServices
{
    public class IsExternalInit
    {
    }
}
#endif