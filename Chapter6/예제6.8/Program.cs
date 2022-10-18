
/* ================= 예제 6.8: MemoryStream 사용 예 ================= */

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // short와 int 데이터를 순서대로 MemoryStream에 직렬화
        byte[] shortBytes = BitConverter.GetBytes((short)32000);
        byte[] intBytes = BitConverter.GetBytes(1652300);
        MemoryStream ms = new MemoryStream();

        ms.Write(shortBytes, 0, shortBytes.Length);
        ms.Write(intBytes, 0, intBytes.Length);
        ms.Position = 0;

        // MemoryStream으로부터 short 데이터를 역직렬화
        byte[] outBytes = new byte[2];
        ms.Read(outBytes, 0, 2);
        int shortResult = BitConverter.ToInt16(outBytes, 0);
        Console.WriteLine(shortResult); // 출력 결과: 32000
        
        // 이어서 int 데이터를 역직렬화
        outBytes = new byte[4];
        ms.Read(outBytes, 0, 4);
        int intRsult = BitConverter.ToInt32(outBytes, 0);
        Console.WriteLine(intRsult); // 출력 결과: 1652300
    }
}
