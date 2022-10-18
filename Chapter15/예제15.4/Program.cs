using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BaseType
{
    // 필드 초기화
    private readonly bool _field = int.TryParse("5", out int result);

    // 속성 초기화
    int Number { get; set; } = int.TryParse("5", out int result) ? 0 : -1;
    int Number2 { get; set; } = 5 is int value ? value : 0;

    public BaseType(int number, out bool result)
    {
        Number = number;
        result = _field;
    }
}

public class Derived : BaseType
{
    // 생성자의 초기화
    public Derived(int i) : base(i, out var result)
    {
        Console.WriteLine(result);
    }
}

class Program
{
    static void Main(string[] args)
    {
        string[] strings = new string[] { "test", "is", "good" };

        // LINQ 쿼리 내에 식 사용 가능
        var query = from text in strings
                    where int.TryParse(text, out int result)
                    select text;

        object[] objects = new object[] { 5, "is", true };

        var texts = from text in objects
                    let t = text is string value ? value : ""
                    select t;
    }
}
