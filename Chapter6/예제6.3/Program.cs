
/* ================= 예제 6.3: string.Format 사용 예 ================= */

using System;

class Program
{
    static void Main(string[] args)
    {
        string txt = "Hello {0}: {1}";
        string output = string.Format(txt, "World", "Anderson");
        Console.WriteLine(output);
    }
}
