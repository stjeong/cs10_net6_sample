
/* ================= 예제 5.21: IDisposable을 상속받는 FileLogger 타입 ================= */

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        FileLogger log = new FileLogger("sample.log");
        log.Write("Start");
        log.Write("End");
        log.Dispose();
    }
}

class FileLogger : IDisposable
{
    FileStream _fs;

    public FileLogger(string fileName)
    {
        _fs = new FileStream(fileName, FileMode.Create);
    }

    public void Write(string txt)
    {
        byte[] contents = Encoding.Default.GetBytes(txt);
        _fs.Write(contents, 0, contents.Length);
    }

    public void Dispose()
    {
        _fs.Close();
    }
}