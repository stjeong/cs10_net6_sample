
/* ================= 예제 4.7 클래스의 인스턴스를 단 하나만 만드는 예제 ================= */

using System;

class Person
{
    static public Person President = new Person("대통령"); // public 정적 필드
    string _name;

    private Person(string name) // private 인스턴스 생성자
    {
        _name = name;
    }

    public void DisplayName() // public 인스턴스 메서드
    {
        Console.WriteLine(_name);
    }

}

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person.President.DisplayName(); // 정적 필드로 단일 인스턴스 접근
            // Person person1 = new Person("홍길동"); // 생성자가 private이므로 오류 발생
        }
    }
}

