
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Point p = new(5, 6);

        var linePt = new Point[]
        {
            new(5, 6),
            new() { X = 7, Y = 0 },
        };

        var dict = new Dictionary<Point, bool>()
        {
            [new(5, 6)] = true,
            [new(7, 0)] = true,
            [new(7, 3)] = false,
            [new() { X = 3, Y = 2 }] = false,
        };
    }
}

public record Point(int X, int Y)
{
    public Point() : this(0, 0) { }
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