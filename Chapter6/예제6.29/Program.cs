
/* ================= 예제 6.29: 동기 방식의 파일 읽기 ================= */

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // HOSTS 파일을 읽어서 내용을 출력한다.
        using (FileStream fs = new FileStream(@"C:\windows\system32\drivers\etc\HOSTS", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            byte[] buf = new byte[fs.Length];
            fs.Read(buf, 0, buf.Length);
            string txt = Encoding.UTF8.GetString(buf);
            Console.WriteLine(txt);
        }
    }
}

