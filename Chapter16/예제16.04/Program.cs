using System;

class Program
{
    static void Main(string[] args)
    {
        using var file = new System.IO.StreamReader("test.txt");
        string txt = file.ReadToEnd();
        Console.WriteLine(txt);

        if (args.Length == 0)
        {
            using var file2 = new System.IO.StreamReader("test.txt");
            string txt2 = file2.ReadToEnd();
            Console.WriteLine(txt2);
        }
    }
}
