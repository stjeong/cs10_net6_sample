using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

Console.WriteLine("Hello World!");

[DllImport("User32.dll", CharSet = CharSet.Unicode)]
static extern int MessageBox(IntPtr h, string m, string c, int type);

MessageBox(IntPtr.Zero, "C# 9.0", "Top-level statements", 0);

Log("Hello World!");

[Conditional("DEBUG")]
static void Log(string text)
{
    File.WriteAllText($"test.log", text);
}