
/* ================= 예제 5.24: 명시적으로 비관리 자원을 해제 ================= */

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            using (UnmanagedMemoryManager m = new UnmanagedMemoryManager())
            {
            }

            Console.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
        }
    }
}

class UnmanagedMemoryManager : IDisposable
{
    IntPtr pBuffer;

    public UnmanagedMemoryManager()
    {
        // AllocCoTaskMem 메서드는 비관리 메모리를 할당한다.
        pBuffer = Marshal.AllocCoTaskMem(4096 * 1024); // 의도적으로 4MB 할당
    }

    public void Dispose()
    {
        Marshal.FreeCoTaskMem(pBuffer);
    }
}