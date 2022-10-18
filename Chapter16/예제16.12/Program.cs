using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class Nested<T> where T : unmanaged
{
    public T item;
}

public struct BlittableStruct
{
    public byte Item;
}

public struct BlittableGenericStruct<T>
{
    public T Item;
}


class Program
{
    unsafe static void Main(string[] args)
    {
        // 컴파일 가능
        {
            BlittableStruct inst = new BlittableStruct();
            BlittableStruct* pInst = &inst;
        }

        // BlittableStruct와 동일한 메모리 구조임에도 C# 7.3 이전에는 컴파일 오류
        {
            BlittableGenericStruct<byte> inst = new BlittableGenericStruct<byte>();
            BlittableGenericStruct<byte>* pInst = &inst;
        }

        Nested<byte> inst1 = new Nested<byte>();

        // BlittableGenericStruct<byte> 타입 자체가 unmanaged 조건을 만족하지만

        // C# 7.3 이전에는 컴파일 오류
        Nested<BlittableGenericStruct<byte>> inst2 = new Nested<BlittableGenericStruct<byte>>();

        // C# 7.3 이전에는 컴파일 오류
        CallUnmanaged(new BlittableGenericStruct<byte>());

        // 아래의 코드는 아무리 실행해도 GC가 발생하지 않는다.
        // while (true)
        {
            using (NativeMemory<int> buf = new NativeMemory<int>(1024))
            {
                Span<int> viewBuf = buf.GetView();
                for (int i = 0; i < viewBuf.Length; i++)
                {
                    viewBuf[i] = i;
                }
            }

            using (NativeMemory<byte> buf = new NativeMemory<byte>(1024))
            {
                Span<byte> viewBuf = buf.GetView();
                for (int i = 0; i < viewBuf.Length; i++)
                {
                    viewBuf[i] = (byte)i;
                }
            }
        }
    }

    static unsafe void CallUnmanaged<T>(T inst) where T : unmanaged
    {
        T* pInst = &inst;
    }
}

public unsafe ref struct NativeMemory<T> where T : unmanaged
{
    int _size;
    IntPtr _ptr;

    public NativeMemory(int size)
    {
        _size = size;
        _ptr = Marshal.AllocHGlobal(size * sizeof(T));
    }

    public Span<T> GetView()
    {
        return new Span<T>(_ptr.ToPointer(), _size);
    }

    public void Dispose()
    {
        if (_ptr == IntPtr.Zero)
        {
            return;
        }

        Marshal.FreeHGlobal(_ptr);
        _ptr = IntPtr.Zero;
    }
}