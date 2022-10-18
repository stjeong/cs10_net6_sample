
/* ================= 예제 10.2: async/await이 적용된 비동기 호출 ================= */

using System;
using System.IO;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            AwaitRead();
            Console.ReadLine();
        }

        private static async void AwaitRead()
        {
            using (FileStream fs = new FileStream(@"C:\windows\system32\drivers\etc\HOSTS", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                byte[] buf = new byte[fs.Length];

                Console.WriteLine("Before ReadAsync: " + Thread.CurrentThread.ManagedThreadId);
                await fs.ReadAsync(buf, 0, buf.Length);
                Console.WriteLine("After ReadAsync: " + Thread.CurrentThread.ManagedThreadId);

                // 아래의 두 라인은 C# 컴파일러가 분리해, ReadAsync 비동기 호출이 완료된 후 호출
                string txt = Encoding.UTF8.GetString(buf);
                Console.WriteLine(txt);
            }
        }
    }
}