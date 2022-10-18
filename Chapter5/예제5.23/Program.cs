
/* ================= 예제 5.23: 잘못된 비관리 메모리 사용 예 ================= */

// 이 테스트는 반드시 x86 옵션으로 빌드한다.
// 만약 x64/AnyCPU로 빌드하고 64비트로 실행하면 컴퓨터 실행이 한참 동안 느려질 수 있다.

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
            GC.Collect(); // GC를 강제로 수행
                          // 현재 프로세스가 사용하는 메모리 크기 출력

            Console.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
        }
    }
}

class UnmanagedMemoryManager
{
    IntPtr pBuffer;

    public UnmanagedMemoryManager()
    {
        // AllocCoTaskMem 메서드는 비관리 메모리를 할당한다.
        pBuffer = Marshal.AllocCoTaskMem(4096 * 1024); // 의도적으로 4MB 할당
    }
}