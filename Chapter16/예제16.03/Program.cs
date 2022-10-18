using System;

class Program
{
    static void Main(string[] args)
    {
        string txt = "this";

        {
            Console.WriteLine(txt[^1]); // 출력: s
            Console.WriteLine(txt[^2]); // 출력: i
            Console.WriteLine(txt[^3]); // 출력: h

            int i = 4;
            System.Index firstWord = ^i;
            Console.WriteLine(txt[firstWord]); // 출력: t
        }

        Console.WriteLine();

        {
            System.Index firstWord = new Index(0, false); // 두 번째 인자의 의미: fromEnd
            Console.WriteLine(txt[firstWord]); // 출력: t
        }

        Console.WriteLine();

        {
            System.Range full = 0..^0; // == Range.All()
            string copy = txt[full];
            Console.WriteLine(copy); // 출력 this

        }

        Console.WriteLine();

        {
            string copy = txt[..]; // 기본값 범위 == 0..^0
            Console.WriteLine(copy); // 출력 this
            Console.WriteLine(txt[..2]); // 출력 th
            Console.WriteLine(txt[1..]); // 출력 his

        }
    }
}