
using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        {
            object retValue = (args.Length == 0) ? "(empty)" : 1;

            int? result = (args.Length != 0) ? 1 : null;
        }

        Notebook note = new Notebook();
        Desktop desk = new Desktop();

        {
            // C# 8.0 이전: 컴파일 오류, 9.0부터 가능
            // Error CS0173 Type of conditional expression cannot be determined because there is no implicit conversion between 'Book' and 'Headset'
            Computer prd = (note != null) ? note : desk;
        }

        {
            // C# 8.0 이전에는 명시적 형변환을 이용
            Computer prd = (note != null) ? (Computer)note : desk;
        }

        {
            // error CS0019: Operator '??' cannot be applied to operands of type 'Notebook' and 'Desktop'
            // Computer prd = note ?? desk;
        }

        {
            Computer prd = null;

            if (note != null) prd = note;
            else prd = desk;
        }

        M(args.Length == 0 ? 1 : 2);
        M((args.Length == 0) switch { true => 1, false => 2 });
    }

    static void M(short n) { Console.WriteLine("Short"); }
    static void M(long n) { Console.WriteLine("Long"); }

    static void M(short n1, short n2) { Console.WriteLine("Short"); }
    static void M(long n1, long n2) { Console.WriteLine("Long"); }

}

public class Computer
{
}

public class Notebook : Computer
{
}

public class Desktop : Computer
{
}