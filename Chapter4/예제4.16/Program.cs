
/* ================= 예제 4.16 상속받는 경우 생성자로 인한 오류 ================= */

using System;

class Book
{
    decimal isbn13;
    public Book(decimal isbn13)
    {
        this.isbn13 = isbn13;
    }
}

/*
class EBook : Book
{
    public EBook() // 에러 발생
    {
    }
}
*/

class EBook : Book
{
    public EBook() : base(0)
    {
    }

    public EBook(decimal isbn) // 또는 이렇게 값을 연계하는 것도 가능하다.
        : base(isbn)
    {
    }
}

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
