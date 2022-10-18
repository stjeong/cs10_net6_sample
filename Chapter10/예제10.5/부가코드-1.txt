
/* ================= 10.2.4 Async 메서드가 아닌 경우의 비동기 처리 ================= */

using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        AwaitFileRead(@"C:\windows\system32\drivers\etc\HOSTS");
        Console.ReadLine();
    }

    static async Task AwaitFileRead(string filePath)
    {
        string fileText = await ReadAllTextAsync(filePath);
        Console.WriteLine(fileText);
    }

    static Task<string> ReadAllTextAsync(string filePath)
    {
        return Task.Factory.StartNew(() =>
        {
            return File.ReadAllText(filePath);
        });
    }
}
