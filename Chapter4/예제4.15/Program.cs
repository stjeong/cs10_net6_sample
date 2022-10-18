
/* ================= 예제 4.15 this를 이용한 생성자 코드 재사용 ================= */

using System;

class Book
{
    string title;
    decimal isbn13;
    string author;

    public Book(string title) : this(title, 0)
    {
    }

    public Book(string title, decimal isbn13)
        : this(title, isbn13, string.Empty)
    {
    }

    // 초기화 코드를 하나의 생성자에서 처리
    public Book(string title, decimal isbn13, string author)
    {
        this.title = title;
        this.isbn13 = isbn13;
        this.author = author;
    }

    public Book() : this(string.Empty, 0, string.Empty)
    {
    }
}

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Book gulliver = new Book();
        }
    }
}

