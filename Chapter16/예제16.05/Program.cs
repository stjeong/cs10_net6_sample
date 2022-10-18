using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        using (UnmanagedVector v1 = new UnmanagedVector(500.0f, 600.0f))
        {
            Console.WriteLine(v1.X);
            Console.WriteLine(v1.Y);
        }

        // compile error
        // 'StructTest': type used in a using statement must be implicitly convertible to 'System.IDisposable' or implement a suitable 'Dispose' method.
        // using (StructTest st = new StructTest())
        {
        }
    }
}

struct StructTest
{
    public void Dispose() { }
}

ref struct UnmanagedVector
{
    IntPtr _alloc;

    public UnmanagedVector(float x, float y)
    {
        _alloc = Marshal.AllocCoTaskMem(sizeof(float) * 2);

        this.X = x;
        this.Y = y;
    }

    public unsafe float X
    {
        get
        {
            return *((float*)_alloc.ToPointer());
        }
        set
        {
            *((float*)_alloc.ToPointer()) = value;
        }
    }

    public unsafe float Y
    {
        get
        {
            return *((float*)_alloc.ToPointer() + 1);
        }
        set
        {
            *((float*)_alloc.ToPointer() + 1) = value;
        }
    }

    public void Dispose()
    {
        if (_alloc == IntPtr.Zero)
        {
            return;
        }

        Marshal.FreeCoTaskMem(_alloc);
        _alloc = IntPtr.Zero;
    }

}
