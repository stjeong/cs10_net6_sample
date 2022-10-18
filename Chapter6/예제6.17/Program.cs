
/* ================= 예제 6.17: FileStream에 텍스트를 쓰는 예제 ================= */

using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        using (FileStream fs = new FileStream("test.log", FileMode.Create))
        {
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.WriteLine("Hello World");
            sw.WriteLine("Anderson");
            sw.Write(32000);
            sw.Flush();
        }
    }
}
