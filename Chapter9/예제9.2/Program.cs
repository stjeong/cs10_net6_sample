
/* ================= 예제 9.2: 선택적 매개변수의 사용 예 ================= */

using System;

class Person
{
    public void Output(string name, int age = 0, string address = "Korea")
    {
        Console.WriteLine(string.Format("{0}: {1} in {2}", name, age, address));
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person p = new Person();
        p.Output("Anders");
        p.Output("Winnie", 36);
        p.Output("Tom", 28, "Tibet");

        Console.WriteLine();

        // p.Output("Tom", "Tibet"); // 컴파일 오류 발생! age를 생략하고,
        // address 인자를 전달할 수 없다.

        p.Output("Tom", address: "Tibet"); // address 매개변수를 지정해서 값을 전달

        Console.WriteLine();

        p.Output(address: "Tibet", name: "Tom");
        p.Output(age: 5, name: "Tom", address: "Tibet");
        p.Output(name: "Tom");
    }
}