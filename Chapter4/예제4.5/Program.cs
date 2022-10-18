
/* ================= 예제 4.5: 다중 생성자를 사용 ================= */

using System;

class Book
{
    public string Title;
    public decimal ISBN13;
    public string Author;

    public Book(string title)
    {
        Title = title;
    }

    public Book(string title, decimal isbn13)
    {
        Title = title;
        ISBN13 = isbn13;
    }

    public Book(string title, decimal isbn13, string author)
    {
        Title = title;
        ISBN13 = isbn13;
        Author = author;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Book gulliver = new Book("걸리버 여행기");
        Book huckleberry = new Book("허클베리 핀의 모험", 9788952753403m);
        Book alice = new Book("이상한 나라의 앨리스", 9788992632126, "Lewis Carroll");
    }
}

