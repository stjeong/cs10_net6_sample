
/* ================= 예제 8.8: 짝수로 구성된 List<T>를 반환하는 코드 ================= */

using System;
using System.Collections.Generic;

class Program
{
    delegate int MyAdd(int a, int b);

    static void Main(string[] args)
    {
        List<int> list = new List<int> { 3, 1, 4, 5, 2 };

        // 방법 1
        {
            List<int> evenList = new List<int>();

            foreach (var item in list)
            {
                if (item % 2 == 0) // 짝수인지 판정해서 evenList에 추가한다.
                {
                    evenList.Add(item);
                }
            }

            foreach (var item in evenList)
            {
                Console.Write(item + ","); // 출력 결과: 4, 2,
            }
        }

        Console.WriteLine();
        Console.WriteLine();

        // 방법 2
        {
            List<int> evenList = list.FindAll((elem) => elem % 2 == 0);
            evenList.ForEach((elem) => { Console.Write(elem + ","); }); // 출력 결과: 4, 2,
        }
    }
}

