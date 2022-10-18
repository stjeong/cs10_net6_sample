
/* ================= 예제 4.4: 매개변수를 갖는 생성자 ================= */

using System;

class Person
{
    string _name;

    public Person(string name)
    {
        _name = name;
    }

    public void WriteName()
    {
        Console.WriteLine("Name: " + _name);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person("영희");
        person.WriteName();
    }
}