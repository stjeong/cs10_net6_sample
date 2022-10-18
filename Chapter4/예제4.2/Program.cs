
/* ================= 예제 4.2: Book 타입 정의 및 사용 ================= */

using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Book gulliver = new Book();
        }
    }

    class Book
    {
        string Title;
        decimal ISBN13;
        string Contents;
        string Author;
        int PageCount;
    }
}


