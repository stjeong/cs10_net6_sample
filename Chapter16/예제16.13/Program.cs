using System;

public struct Vector2
{
    public float x;
    public float y;

    public readonly (float x, float y) ToTuple()
    {
        return (x, y);
    }

    // 속성
    public readonly float LengthSquared
    {
        get
        {
            return (x * x) + (y * y);
        }
    }

    // 자동 구현 속성의 경우 get에 대해서만 readonly 적용 가능
    public float Z { readonly get; set; }

    // 람다 식의 메서드에도 적용 가능
    public readonly float GetLength() => (x * x) + (y * y);
}

public class Point2
{
    public int x;
    public int y;

    /*
    // class의 메서드에는 readonly를 적용할 수 없다.
    public readonly (int x, int y) ToTuple()
    {
        return (x, y);
    }
    */
}

class Program
{
    static void Main(string[] args)
    {
        Vector2 v = new Vector2 { x = 5, y = 6 };
        OutputInfo(v);
    }

    static void OutputInfo(in Vector2 v2)
    {
        (float x, float y) = v2.ToTuple();
        Console.WriteLine($"({x},{y}, Length = {v2.LengthSquared}({v2.GetLength()}, Z = {v2.Z})");
    }
}
