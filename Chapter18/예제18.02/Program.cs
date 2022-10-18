
Person p1 = new Person();
Console.WriteLine(p1.Name);

Point pt1 = new Point(5, 6);
Console.WriteLine($"{pt1.X}, {pt1.Y}");

Point pt2 = new Point();
Console.WriteLine($"{pt2.X}, {pt2.Y}");

Vector v1 = new Vector();
Console.WriteLine($"{v1.X}, {v1.Y}");

Console.WriteLine("--------------------------------");

TestStruct t = new TestStruct();
Console.WriteLine(t.i); // 출력 결과: 0

CreateTest();

static void CreateTest()
{
    // 구조체: 기본 생성자가 없는 유형임에도 컴파일 성공
    TestStruct valueType = ObjectHelper.CreateNew<TestStruct>();

    // 클래스: 기본 생성자가 없으므로 의도한 바따라 컴파일 실패
    // TestClass refType = ObjectHelper.CreateNew<TestClass>();
}


public struct Person
{
    string name;
    public string Name => name;

    public Person()
    {
        name = "John";
    }
}

public struct Point
{
    int x;
    public int X => x;
    int y;
    public int Y => y;

    public Point(int x, int y) { this.x = x; this.y = y; }
}

record struct Vector(int X, int Y)
{
    // record struct에서의 기본 생성자 정의
    public Vector() : this(-1, -1) { this.X = 5; }
    public Vector(int x) : this(x, -1) { }
}

public struct Language
{
    // C# 9 이전에는 불가능한 필드 초기화
    public string Author = "John";
    public string Name { get; private set; } = "C#";

    public Language(string name)
    {
        this.Name = name;
    }

    public Language()
    {
    }
}

struct TestStruct
{
    public int i = 10;

    public TestStruct(int i) { this.i = i; }
}

class TestClass
{
    public int i;

    public TestClass(int i) { this.i = i; }
}

public class ObjectHelper
{
    public static T CreateNew<T>() where T : new() => new T();
}
