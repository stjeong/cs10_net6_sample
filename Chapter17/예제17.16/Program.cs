using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
    }

    // C# 8.0 컴파일 오류
    // Error CS8627 A nullable type parameter must be known to be a value type or non-nullable reference type
    static void CreateArray<T>(int n)
    {
        var t = new T?[n];
    }

    static void CreateValueArray<T>(int n) where T : struct
    {
        var t = new T?[n];
    }

#nullable enable
    static void CreateRefArray<T>(int n) where T : class
    {
        var t = new T?[n];
    }
#nullable restore

    static void M<T>(T? value) where T : struct { }
    static void M<T>(T? value) /* 생략한 경우, where T : class */ { }
}

public class Base
{
    public virtual void M<T>(T? t) where T : struct
    {
        Console.WriteLine("Base.M.struct");
    }

#nullable enable
    public virtual void M<T>(T? t) where T : class
    {
        Console.WriteLine("Base.M.class");
    }
#nullable restore
}

public class Derived : Base
{
    // 아무런 제약 조건을 명시하지 않았으면 "where T : struct"로 연결
    public override void M<T>(T? t)
    {
        Console.WriteLine("Derived.M.struct");
    }

#nullable enable
    public override void M<T>(T? t) where T : class
    {
        Console.WriteLine("Derived.M.class");
    }
#nullable restore
}

public class Base2
{
    public virtual void M<T>(T? t) where T : struct
    {
        Console.WriteLine("Base.M.struct");
    }

    public virtual void M<T>(T? t)
    {
        Console.WriteLine("Base.M.class");
    }
}

public class Derived2 : Base2
{
    public override void M<T>(T? t)
    {
        Console.WriteLine("Derived.M.struct");
    }

    public override void M<T>(T? t) where T : default
    {
        Console.WriteLine("Derived.M.class");
    }
}