using System;
using System.Runtime.InteropServices;

class Program
{
    public delegate bool EqualsDelegate(int n1, int n2);

    [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
    static extern IntPtr LoadLibrary(string lpFileName);

    [DllImport("kernel32", CharSet = CharSet.Ansi)]
    static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int SleepExDelegate(int milliseconds, bool bAlertable);


    static void Main(string[] args)
    {
        UnmanagedFunctionPointer();

        ManagedFunctionPointer();
    }

    private static void UnmanagedFunctionPointer()
    {
        IntPtr ptrKernel = LoadLibrary("kernel32.dll");
        IntPtr ptrSleepEx = GetProcAddress(ptrKernel, "SleepEx");

        {
            SleepExDelegate sleepExFunc = Marshal.GetDelegateForFunctionPointer(ptrSleepEx, typeof(SleepExDelegate)) as SleepExDelegate;

            Console.WriteLine(DateTime.Now);
            sleepExFunc(2000, false);
            Console.WriteLine(DateTime.Now);
        }

        unsafe
        {
            delegate* unmanaged[Stdcall]<int, bool, int> sleepExFunc = (delegate* unmanaged[Stdcall]<int, bool, int>)ptrSleepEx;
            Console.WriteLine(DateTime.Now);
            sleepExFunc(2000, false);
            Console.WriteLine(DateTime.Now);
        }

        unsafe
        {
            // System.Runtime.CompilerServices.CallConvStdcall
            delegate* unmanaged[Stdcall]<void> ptr1 = null;

            // System.Runtime.CompilerServices.CallConvCdecl
            delegate* unmanaged[Cdecl]<void> ptr2 = null;

            // System.Runtime.CompilerServices.CallConvFastcall
            delegate* unmanaged[Fastcall]<void> ptr3 = null;

            // System.Runtime.CompilerServices.CallConvThiscall
            delegate* unmanaged[Thiscall]<void> ptr4 = null;
        }
    }

    private static unsafe void ManagedFunctionPointer()
    {
        {
            EqualsDelegate equalsFunc = Program.Equals;
            equalsFunc(1, 2);
        }

        {
            Func<int, int, bool> equalsFunc = Program.Equals;
            equalsFunc(1, 2);
        }

        {
            delegate*<int, int, bool> equalsFunc = &Program.Equals;
            equalsFunc(1, 2);

            delegate* managed<string, void> writeLineFunc = null;

            writeLineFunc = &Program.WriteLine;
            writeLineFunc("1 == 2: " + equalsFunc(1, 2));
        }

        {
            IntPtr pFunc = new IntPtr(1000);
            delegate*<void> unsafeFunc = (delegate*<void>)pFunc;
            // Unhandled Exception: System.AccessViolationException: Attempted to read or write protected memory. This is often an indication that other memory is corrupt.
            // unsafeFunc();
        }

        {
            delegate*<string, void> writeLineFunc = &Program.WriteLine;
            IntPtr ptr = new IntPtr(writeLineFunc);
            delegate*<void> unsafeFunc = (delegate*<void>)ptr;
            // Unhandled Exception: System.AccessViolationException: Attempted to read or write protected memory. This is often an indication that other memory is corrupt.
            // unsafeFunc();
        }
    }

    static void WriteLine(string text)
    {
        Console.WriteLine(text);
    }

    static bool Equals(int n1, int n2)
    {
        return n1 == n2;
    }
}

public class FunctionPointer<T>
{
    public unsafe void Test()
    {
        IntPtr pFunc = new IntPtr(1000);
        delegate*<T> func = (delegate*<T>)pFunc;
    }
}
