
/* ================= 예제 6.11: 직렬화 예제 클래스 – Person ================= */

using System;

[Serializable]
class Person
{
    public int Age;
    public string Name;

    public Person(int age, string name)
    {
        this.Age = age;
        this.Name = name;
    }

    public override string ToString()
    {
        return string.Format("{0} {1}", this.Age, this.Name);
    }
}

class Program
{
    static void Main(string[] args)
    {
    }
}

