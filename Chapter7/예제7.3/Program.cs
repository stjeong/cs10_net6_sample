
/* ================= 예제 7.3: IComparable 인터페이스를 상속받은 타입만 T에 대입 ================= */

using System;

public class Utility
{
    public static T Max<T>(T item1, T item2) where T : IComparable
    {
        if (item1.CompareTo(item2) >= 0)
        {
            return item1;
        }

        return item2;
    }
}

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Utility.Max(5, 6)); // 출력 결과: 6
            Console.WriteLine(Utility.Max("Abc", "def")); // 출력 결과: def
        }
    }
}
