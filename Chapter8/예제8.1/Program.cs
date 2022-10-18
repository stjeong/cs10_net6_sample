
/* ================= 예제 8.1: 생성자를 이용한 상태 변수 초기화 ================= */

using System;

class Person
{
    string _name;
    int _age;

    public Person() // 기본 생성자
        : this(string.Empty, 0)
    {
    }

    public Person(string name) // name만 초깃값을 전달받는 생성자
        : this(name, 0)
    {
    }

    public Person(string name, int age) // name, age 모두 초깃값을 전달받는 생성자
    {
        _age = age;
        _name = name;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person p = new Person("Anders", 10);
    }
}
