using System;

class Program
{
    static void Main(string[] args)
    {
        Program pg = new Program();
        pg.WriteLog("test");
    }

    private void WriteLog(string txt)
    {
        int length = txt.Length;
        WriteConsole(txt, length);

        static void WriteConsole(string txt, int length)
        {
            Console.WriteLine($"# of chars('{txt}'): {length}");
        }
    }
}

