using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        {
            // string title = "console: ";

            Func<int, string> func = static i =>
            {
                // Error CS8820  A static anonymous function cannot contain a reference to 'title'.
                // return title + i.ToString();

                return i.ToString();
            };

            Console.WriteLine(func(10));
        }

        {
            const string title = "console: ";

            Func<int, string> func = static delegate (int i)
            {
                // const 변수의 경우 참조에 대한 부작용이 없으므로 사용 가능
                return title + i.ToString();
            };

            Console.WriteLine(func(10));
        }

        {
            Func<int, int, int> func1 = (_, _) => 1;
            Func<short, int, int, int> func2 = (_, _, _) => 1;
            Func<bool, int, int, int> func3 = (_, _, _) => 1;
        }

        {
            Func<int, int, int> func1 = delegate (int _, int _) { return 1; };
            Func<short, int, int, int> func2 = delegate (short _, int _, int _) { return 1; };
            Func<bool, int, int, int> func3 = delegate (bool _, int _, int _) { return 1; };
        }

        /*
        int LocalFunc(int _, int _, int _)
        {
            return 5;
        }
        */

        Class1 cl = new Class1();
        cl.M();
        cl.TryParse("test", out _, out _);

        cl.Run((string name, int time) => { return 0; });

        cl.Run((string _, int _) => { return 0; });
        cl.Run((string _, int _) => 5);
        cl.Run((_, _) => 5);
        cl.Run(delegate (string _, int _) { return 0; });
    }
    }

public delegate int RunDelegate(string name, int time);

public class Class1
{
    void M(int _)
    {
}

    public void Run(RunDelegate runnable)
    {
        runnable(nameof(Class1), 1);
    }

    // Error CS0100 The parameter name '_' is a duplicate
    /*
    void M(int _, int _)
    {
    }
    */

    public void M()
    {
        int _;
        _ = 5;
        Console.WriteLine(_);
    }

    void M(string txt)
    {
        int.TryParse(txt, out _);
        IPAddress.TryParse(txt, out _);
    }

    public bool TryParse(string txt, out int n, out IPAddress address)
    {
        n = 0;
        address = IPAddress.Any;

        return true;
    }
}

public class Class2
{
    void _()
    {
    }
}