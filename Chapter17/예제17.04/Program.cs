using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading;

#nullable enable

class Program
{
    static void Main(string[] args)
    {
        Log("Main");
        Log(null);

        [Conditional("DEBUG")]
        static void Log([AllowNull] string text)
        {
            string logText = $"[{Thread.CurrentThread.ManagedThreadId}] {text}";
            Console.WriteLine(logText);
        }

        MessageBox(IntPtr.Zero, "message", "title", 0);

        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        static extern int MessageBox(IntPtr h, string m, string c, int type);
    }
}

namespace System.Diagnostics.CodeAnalysis
{
#if !NETCOREAPP
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method
        | AttributeTargets.Parameter | AttributeTargets.Property
        | AttributeTargets.ReturnValue, AllowMultiple = true)]
    public sealed class AllowNullAttribute : Attribute { }
#endif
}