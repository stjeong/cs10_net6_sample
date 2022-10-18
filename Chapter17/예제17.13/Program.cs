using System;

class Program
{
    static void Main(string[] args)
    {
        // nint, nuint 사용에는 unsafe 필요 없음
        // sizeof 연산을 위해서만 unsafe 문맥 필요
        unsafe
        {
            Console.WriteLine(sizeof(nint));
            Console.WriteLine(sizeof(nuint));
        }

        {
            IntPtr value1 = new(5); // Target-typed new
            IntPtr value2 = new(6);

            // Error CS0019 Operator '+' cannot be applied to operands of type 'IntPtr' and 'IntPtr'
            // IntPtr value3 = value1 + value2;
        }

        {
            nint value1 = 5; // IntPtr처럼 new 할 필요가 없음.
            nint value2 = 6;
            nint value3 = value1 + value2;
            nint value4 = value1 - value2;
            nint value5 = value1 / value2;
            nint value6 = value1 * value2;
            nint value7 = value1 % value2;
        }
    }
}
