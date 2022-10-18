
using System;

class Program
{
    static unsafe void Main(string[] args)
    {
        {
            Span<int> span1 = stackalloc int[5] { 1, 2, 3, 4, 5 };
            Span<int> span2 = stackalloc int[] { 1, 2, 3, 4, 5 };
        }

        {
            int* pArray1 = stackalloc int[3] { 1, 2, 3 };
            int* pArray2 = stackalloc int[] { 1, 2, 3 };
        }
    }
}
