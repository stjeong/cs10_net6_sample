using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StaticButInstanceMatchFirst
{
    public static void Do(object obj)
    {
        System.Console.WriteLine("static Do(object)");
    }

    public void Do(string txt)
    {
        System.Console.WriteLine("Do(string)");
    }

    public static void StaticDone()
    {
        // C# 7.2까지 컴파일 오류 - Error CS0120 An object reference is required for the non-static field, method, or property 'StaticButInstanceMatchFirst.Do(string)'
        Do("test");
    }
}

class InstanceButStaticMatchFirst
{
    public static void Do(string txt)
    {
        System.Console.WriteLine("static Do(string)");
    }

    public void Do(object obj)
    {
        System.Console.WriteLine("Do(object)");
    }

    public void InstanceDone()
    {
        Do("test"); // receiver 명시가 없으므로.
    }
}

class C
{
    public static void M(string x)
    {
        System.Console.WriteLine("static M(string)");
    }
    public void M(object s)
    {
        System.Console.WriteLine("M(object)");
    }
}

class A
{
    public static void M(string txt)
    {
        System.Console.WriteLine("static M(string)");
    }

    public void M(object obj)
    {
        System.Console.WriteLine("M(object)");
    }
}

class B
{
    public static void M(object obj)
    {
        System.Console.WriteLine("static M(object)");
    }

    public void M(string txt)
    {
        System.Console.WriteLine("M(string)");
    }
}

class Program
{
    public A A = new A(); // 클래스 명과 필드의 이름이 같음
    public B B = new B(); // 클래스 명과 필드의 이름이 같음

    public void Call()
    {
        A.M("hello");
        B.M("hello");
    }

    static void Main(string[] args)
    {
        {
            // C# 7.2까지 컴파일 에러 - Error CS0120 An object reference is required for the non-static field, method, or property 'StaticButInstanceMatchFirst.Do(string)'
            StaticButInstanceMatchFirst.Do("TEST"); // 우회적으로 (object)"TEST"로 인자를 전달하면 OK
        }

        {
            InstanceButStaticMatchFirst t = new InstanceButStaticMatchFirst();

            // C# 7.2까지 컴파일 에러 - Error CS0176 Member 'InstanceButStaticMatchFirst.Do(string)' cannot be accessed with an instance reference; qualify it with a type name instead
            t.Do("TEST");  // 우회적으로 (object)"TEST"로 인자를 전달하면 OK
        }

        C c = new C();
        c.M("hello");

        Program pg = new Program();
        pg.Call();

    }
}

