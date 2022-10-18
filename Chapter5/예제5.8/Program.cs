
/* ================= 예제 5.8: 최적화 예제 ================= */

using System;

class Program
{
    static void AccessArray(int[] array)
    {
        array[5] = 0;
    }

    static void Main(string[] args)
    {
        int[] nArray = new int[] { 0, 1, 2, 3, 4 };
        AccessArray(nArray);
    }
}