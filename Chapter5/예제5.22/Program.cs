
/* ================= 예제 5.22: try/finally를 이용한 Dispose 메서드 호출 ================= */

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        FileLogger log = null;

        try
        {
            log = new FileLogger("sample.log");
            log.Write("Start");
            log.Write("End");
        }
        finally
        {
            log.Dispose();
        }

        using (FileLogger log2 = new FileLogger("sample.log"))
        {
            log2.Write("Start");
            log2.Write("End");
        }
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