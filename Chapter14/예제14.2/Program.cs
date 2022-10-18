using System;

class Program
{
    readonly Vector v1 = new Vector();

    static void Main(string[] args)
    {
        Program pg = new Program();

        // pg.v1.X = 5; // 컴파일 오류
        pg.v1.Increment(); // 방어 복사본 생성

        Console.WriteLine(pg.v1.X + ", " + pg.v1.Y);
    }
}

struct Vector
{
    public int X;
    public int Y;

    public void Increment()
    {
        X++;
        Y++;
    }
}

readonly struct ImmutableVector
{
    readonly public int X; // readonly struct 내의 모든 필드는 readonly 필수
    readonly public int Y; // readonly struct 내의 모든 필드는 readonly 필수

    public ImmutableVector(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Increment()
    {
        // X++; // readonly 필드이므로 실수로라도 값을 변경할 수 없음.
        // Y++;
    }

    public ImmutableVector Increment(int x, int y)
    {
        return new ImmutableVector(X + x, Y + y);
    }
}



