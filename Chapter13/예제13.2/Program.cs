using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace 예제13._2
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericTest<int> t = new GenericTest<int>();
            Console.WriteLine(t.GetDefaultValue());

            int intValue = default;
            BigInteger bigIntValue = default;

            Console.WriteLine(intValue);        // 출력 결과: 0
            Console.WriteLine(bigIntValue);     // 출력 결과: 0

            string txt = default;
            Console.WriteLine(txt ?? "(null)"); // 출력 결과: (null)
        }
    }

    class GenericTest<T>
    {
        public T GetDefaultValue()
        {
            return default;
        }
    }
}
