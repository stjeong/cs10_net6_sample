
/* ================= 예제 5.17: 사용자 정의 예외를 사용 ================= */

using System;

class InvalidPasswordException : Exception
{
    public InvalidPasswordException(string msg)
        : base(msg)
    { }
}

class Program
{
    static void Main(string[] args)
    {
        string txt = Console.ReadLine();

        if (txt != "123")
        {
            InvalidPasswordException ex = new InvalidPasswordException("틀린 암호");
            throw ex;
        }

        Console.WriteLine("올바른 암호");
    }
}
