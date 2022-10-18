
/* ================= 예제 5.12: IndexOutOfRangeException 예외가 발생하는 코드 ================= */

using System;

class Program
{
    static void Main(string[] args)
    {
        int[] intArray = new int[10];

        int lastElem = intArray[11];
    }
}