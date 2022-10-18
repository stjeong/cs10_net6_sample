
/* ================= 예제 5.26: Dispose를 호출한 경우 소멸자가 불리지 않도록 변경한 객체 ================= */

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            UnmanagedMemoryManager m = new UnmanagedMemoryManager();
            m = null;
            GC.Collect(); // GC로 인해 소멸자가 호출되므로 비관리 메모리도 해제됨.

            Console.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
        }
    }
}

class UnmanagedMemoryManager : IDisposable
{
    IntPtr pBuffer;
    bool _disposed;

    public UnmanagedMemoryManager()
    {
        pBuffer = Marshal.AllocCoTaskMem(4096 * 1024);
    }

    void Dispose(bool disposing)
    {
        if (_disposed == false)
        {
            Marshal.FreeCoTaskMem(pBuffer);
            _disposed = true;
        }
        if (disposing == false)
        {
            // disposing이 false인 경우란 명시적으로 Dispose()를 호출한 경우다.
            // 따라서 종료 큐에서 자신을 제거해 GC의 부담을 줄인다.
            GC.SuppressFinalize(this);
        }
    }

    public void Dispose()
    {
        Dispose(false);
    }

    ~UnmanagedMemoryManager()
    {
        Dispose(true);
    }
}

