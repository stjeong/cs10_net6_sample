using System;
using System.Runtime.CompilerServices;

class Program
{
    [SkipLocalsInit]
    unsafe static void Main(string[] args)
    {
        int i = 5;
        char c;

        Console.WriteLine(i);

        LocalsInitStackAlloc();
    }

    [SkipLocalsInitAttribute]
    unsafe static void LocalsInitStackAlloc()
    {
        var arr = stackalloc int[1000];

        for (int i = 0; i < 1000; i++)
        {
            Console.Write($"{arr[i]},");
        }
    }
}

#if !NET5_0
namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event | AttributeTargets.Interface, Inherited = false)]
    public sealed class SkipLocalsInitAttribute : Attribute
    {
    }
}
#endif