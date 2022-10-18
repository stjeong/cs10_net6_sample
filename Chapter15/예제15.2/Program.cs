using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        unsafe
        {
            Point pt = new Point { X = 5, Y = 6 };

            fixed (int* pX = &pt.X)
            fixed (int* pY = &pt.Y)
            {
                Console.WriteLine($"{*pX}, {*pY}");
            }

            fixed (int* pPoint = pt)
            {
                Console.WriteLine(*pPoint);
            }
        }

        FixedSpan();
    }

    private unsafe static void FixedSpan()
    {
        {
            // (fixed될 필요가 없는) 스택을 기반으로 하든,
            Span<int> span = stackalloc int[500];

            fixed (int* pSpan = span)
            {
                Console.WriteLine(*(pSpan + 1));
            }
        }

        {
            // 관리 힙을 기반으로 하든,
            Span<int> span = new int[500];

            fixed (int* pSpan = span)
            {
                Console.WriteLine(*(pSpan + 1));
            }
        }

        {
            // (fixed될 필요가 없는) 비관리 힙을 기반으로 하든지에 상관없이 일관성 있는 fixed 구문을 제공
            int elemLen = 500;
            int allocLen = sizeof(int) * elemLen;
            Span<int> span = new Span<int>((void*)Marshal.AllocCoTaskMem(allocLen), elemLen);

            fixed (int* pSpan = span)
            {
                Console.WriteLine(*(pSpan + 1));
            }
        }
    }
}

public class Point
{
    public int X;
    public int Y;

    public ref int GetPinnableReference()
    {
        return ref X;
    }
}
