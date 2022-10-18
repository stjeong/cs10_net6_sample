
Console.WriteLine($"ValueType: {typeof(Vector).IsValueType}");
Console.WriteLine($"ValueType: {typeof(Point).IsValueType}");
Console.WriteLine($"ValueType: {typeof(Person).IsValueType}");

// C# 9.0부터 가능했던 참조 형식 record
record Vector(int X, int Y);

// C# 10부터 가능한 값 형식 record
record struct Point(int X, int Y)
{
    public /* sealed */ override string ToString()
    {
        return $"2D({X},{Y})";
    }
}

// C# 10부터 가능한 명시적인 참조 형식 record
record class Person(string Name, int Age);

record Vector2D(float x, float y)
{
    public override string ToString()
    {
        return $"2D({x},{y})";
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    // 컴파일 오류 발생 - 사용자가 정의한 것을 인지하지 못하고 C# 컴파일러가 무조건 Equals 메서드를 생성하므로!
    // error CS0111: Type 'Vector2D' already defines a member called 'Equals' with the same parameter types
    //public override bool Equals(object obj)
    //{
    //    return base.Equals(obj);
    //}
}