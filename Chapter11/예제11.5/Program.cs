
/* ================= 예제 11.5: catch/finally 절에서의 await 호출 ================= */

using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        ProcessFileAsync();
        Console.ReadLine();
    }

    private static async void ProcessFileAsync()
    {
        FileStream fs = null;

        try
        {
            fs = new FileStream("test.txt", FileMode.Open, FileAccess.Read);

            byte[] contents = new byte[1024];
            await fs.ReadAsync(contents, 0, contents.Length);

            Console.WriteLine("ReadAsync Called!");
        }
        catch (Exception e)
        {
            await LogAsync(e); // C# 5.0에서는 불가능했던 호출
        }
        finally
        {
            await CloseAsync(fs); // C# 5.0에서는 불가능했던 호출
        }
    }

    static Task LogAsync(Exception e)
    {
        return Task.Factory.StartNew(
        () =>
        {
            Console.WriteLine("Log Async Called!");
        });
    }

    static Task CloseAsync(FileStream fs)
    {
        return Task.Factory.StartNew(
        () =>
        {
            Console.WriteLine("Close Async Called!");
            if (fs != null)
            {
                fs.Close();
            }
        });
    }
}
