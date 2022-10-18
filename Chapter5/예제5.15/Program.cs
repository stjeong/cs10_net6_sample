
/* ================= 예제 5.15: throw를 이용한 예외 발생 ================= */

using System;

class Program
{
    static void Main(string[] args)
    {
        string txt = Console.ReadLine();

        if (txt != "123")
        {
            ApplicationException ex = new ApplicationException("틀린 암호");
            throw ex;
        }

        Console.WriteLine("올바른 암호");
    }
}
