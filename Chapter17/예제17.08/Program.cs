
using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Run at Main");
    }
}

class Module
{
    [ModuleInitializer]
    internal static void DllMain()
    {
        Console.WriteLine("Run at ModuleInitializer");
    }
}

#if !NET5_0
// .NET 5.0 환경이 아닌 경우 ModuleInitializerAttribute 클래스를 별도로 정의해서 컴파일 가능하게 만듦
namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class ModuleInitializerAttribute : Attribute { }
}
#endif