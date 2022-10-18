
/* ================= 예제 8.9: Where 사용 예 ================= */

using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> list = new List<int> { 3, 1, 4, 5, 2 };

        {
            IEnumerable<int> enumList = list.Where((elem) => elem % 2 == 0);
            Array.ForEach(enumList.ToArray(), (elem) => { Console.WriteLine(elem); });
        }

        Console.WriteLine();

        {
            IEnumerable<int> enumList = list.WhereFunc();
            Array.ForEach(enumList.ToArray(), (elem) => { Console.WriteLine(elem); });
        }
    }
}

static class ExtensionSample
{
    public static IEnumerable<int> WhereFunc(this IEnumerable<int> inst)
    {
        foreach (var item in inst)
        {
            if (item % 2 == 0)
            {
                yield return item;
            }
        }
    }
}

