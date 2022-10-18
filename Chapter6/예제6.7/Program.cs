
/* ================= 예제 6.7: 바이트 배열을 16진수로 출력 ================= */

using System;

class Program
{
    static void Main(string[] args)
    {
        // 기본 타입을 바이트 배열로 변환
        byte[] boolBytes = BitConverter.GetBytes(true);
        byte[] shortBytes = BitConverter.GetBytes((short)32000);
        byte[] intBytes = BitConverter.GetBytes(1652300);

        Console.WriteLine(BitConverter.ToString(boolBytes));
        Console.WriteLine(BitConverter.ToString(shortBytes));
        Console.WriteLine(BitConverter.ToString(intBytes));
    }
}

