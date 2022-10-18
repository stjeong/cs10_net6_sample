
/* ================= 예제 6.18: Move의 덮어쓰기 구현 ================= */

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        PrepareSample();

        string target = "c:\\temp\\test.dat";

        if (File.Exists(target) == true)
        {
            File.Delete(target);
        }

        File.Move("test.log", target);
    }

    private static void PrepareSample()
    {
        // 예제를 위한 사전 작업
        using (FileStream fs = new FileStream("test.log", FileMode.Create))
        {
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write("Hello World" + Environment.NewLine);
            bw.Flush();
        }

        File.Delete("c:\\temp\\test.dat");
    }
}


