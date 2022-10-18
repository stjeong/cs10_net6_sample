
/* ================= 예제 5.7: 실행 시 오류가 발생하는 유형 ================= */

using System;

class Program
{
    static void Main(string[] args)
    {
        int[] nArray = new int[] { 0, 1, 2, 3, 4 };
        nArray[5] = 0; // 예외 발생
    }
}
