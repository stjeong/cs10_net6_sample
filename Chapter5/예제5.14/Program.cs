
/* ================= 예제 5.14: catch 순서가 잘못된 예 ================= */

using System;

class Program
{
    static void Main(string[] args)
    {
        int divisor = 0;
        string txt = null;

        try
        {
            Console.WriteLine(txt.ToUpper()); // System.NullReferenceException 예외 발생
            int quotient = 10 / divisor;
        }
        catch (System.Exception)
        {
            Console.WriteLine("예외가 발생하면 언제나 실행된다.");
        }
        //catch (System.NullReferenceException) // 컴파일 오류 발생
        //{
        //    Console.WriteLine("어떤 예외가 발생해도 실행되지 않는다.");
        //}
        //catch (System.DivideByZeroException) // 컴파일 오류 발생
        //{
        //    Console.WriteLine("어떤 예외가 발생해도 실행되지 않는다.");
        //}
    }
}
