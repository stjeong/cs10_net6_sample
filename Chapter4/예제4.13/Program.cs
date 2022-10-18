
/* ================= 예제 4.13 참조 형식의 Equals 메서드의 동작 방식 ================= */

using System;

class Book
{
    decimal _isbn;

    public Book(decimal isbn)
    {
        _isbn = isbn;
    }
}

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book(9788998139018);
            Book book2 = new Book(9788998139018);

            Console.WriteLine(book1.Equals(book2)); // 출력 결과: False

            string txt1 = new string(new char[] { 't', 'e', 'x', 't' });
            string txt2 = new string(new char[] { 't', 'e', 'x', 't' });

            Console.WriteLine(txt1.Equals(txt2)); // 출력 결과: True
        }
    }
}

