using System;
using System.IO;
using static System.Console;

#if NET_CORE
public interface ILog
{
    void Log(string txt) => WriteConsole(txt);

    static void WriteConsole(string txt)
    {
        Console.WriteLine(txt);
    }

    void WriteFile(string txt)
    {
        File.WriteAllText(LogFilePath, txt);
    }

    string LogFilePath
    {
        get
        {
            return Path.Combine(DefaultPath, DefaultFileName);
        }
    }

    static string DefaultPath = @"C:\temp";
    static string DefaultFileName = "app.log";
}

public class ConsoleLogger : ILog
{
}

// 인터페이스이므로 일부 메서드를 재정의하는 것도 가능
public class FileLogger : ILog
{
    string _filePath;

    public string LogFilePath
    {
        get { return _filePath; }
    }

    public FileLogger(String filePath)
    {
        _filePath = filePath;
    }

    public void Log(String txt)
    {
        (this as ILog).WriteFile(txt);
    }
}
#endif

public class Program
{
    static void Main()
    {
#if NET_CORE
        {
            ConsoleLogger x = new ConsoleLogger();
            // ConsoleLogger 클래스에서 Log 메서드를 구현한 것은 아니고,
            // ILog 인터페이스에만 있으므로.
            (x as ILog).Log("test");
        }

        {
            ILog x = new ConsoleLogger();
            x.Log("test");
        }

        {
            var x = new FileLogger(@"c:\tmp\my.log");
            // FileLogger 클래스에 Log 메서드를 구현했으므로.
            x.Log("test");
        }

        {
            C c = new C();
            // c.M(); // 이렇게 호출하는 것은 허용되지 않고,

            // 인터페이스를 명시함으로써 다중 상속으로 인한 모호한 호출 문제가 없음.
            (c as IA).M();
            (c as IB1).M();
            (c as IB2).M();
        }

        {
            C c = new C();
            c.M(); // 이제는 클래스 C에서 구현했으므로 인터페이스 형변환이 필요 없음.
        }
#else
        Console.WriteLine("AsyncStreams not supported in .NET Framework.");
#endif
    }
}

#if NET_CORE
interface IA
{
    void M() { WriteLine("IA.M"); }
}

interface IB1 : IA
{
    new void M() { WriteLine("IB1.M"); }
}

interface IB2 : IA
{
    new void M() { WriteLine("IB2.M"); }
}

class C : IA, IB1, IB2
{
    public void M()
    {
        (this as IB1).M(); // 다중 상속이지만 인터페이스를 명시함으로써 모호함 해결
    }
}
#endif