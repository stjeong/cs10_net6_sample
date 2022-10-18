
/* ================= 예제 4.6 인스턴스 필드의 한계 ================= */

using System;

class Person
{
    public int CountOfInstance;

    public string _name;

    public Person(string name)
    {
        CountOfInstance++; // 생성자에서 필드 값 증가
        _name = name;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // 인스턴스인 경우,
        Person person1 = new Person("홍길동");
        Console.WriteLine(person1.CountOfInstance); // 출력 결과: 1

        Person person2 = new Person("홍길순");
        Console.WriteLine(person2.CountOfInstance); // 출력 결과: 1
    }
}

