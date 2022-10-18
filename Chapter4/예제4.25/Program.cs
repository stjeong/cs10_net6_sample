
/* ================= 예제 4.25: IEnumerable 인터페이스를 구현한 객체의 요소를 열거하는 방법 ================= */

using System;
using System.Collections;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = new int[] { 1, 2, 3, 4, 5 };

            IEnumerator enumerator = intArray.GetEnumerator();

            while (enumerator.MoveNext()) // 더 이상 열거할 수 없을 때 false를 반환
            {
                Console.Write(enumerator.Current + ", ");
            }

            Console.WriteLine();

            foreach (int elem in intArray)
            {
                Console.Write(elem + ", ");
            }

            Console.WriteLine();

            string name = "Korea";
            foreach (char ch in name)
            {
                Console.Write(ch + ", ");
            }
        }
    }
}


