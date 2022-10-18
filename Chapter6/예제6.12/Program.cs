
/* ================= 예제 6.12: BinaryFormatter 사용 예 ================= */

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
        Person person = new Person(36, "Anderson");

        BinaryFormatter bf = new BinaryFormatter();

        // MemoryStream에 person 객체를 직렬화
        MemoryStream ms = new MemoryStream();
        bf.Serialize(ms, person);
        ms.Position = 0;

        // MemoryStream으로부터 역직렬화해서 복원
        Person clone = bf.Deserialize(ms) as Person;

        Console.WriteLine(clone); // 출력 결과: 36 Anderson
    }
}


