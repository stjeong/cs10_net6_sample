using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        {
            var arr = new byte[] { 0, 1, 2, 3, 4, 5, 6 };

            Span<byte> view = arr;
            // Span<byte> view = new Span<byte>(arr);

            Console.WriteLine(view[5]); // 출력 결과 5

            view[5] = 7;
            Console.WriteLine(arr[5]); // 출력 결과 7

            arr[5] = 5;
            Console.WriteLine(view[5]); // 출력 결과 5

        }

        {
            var arr = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 };

            var arrLeft = arr.Take(4).ToArray();
            var arrRight = arr.Skip(4).ToArray();

            Print(arrLeft);
            Print(arrRight);
        }

        {
            var arr = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            Span<byte> view = arr;

            var arrLeft = view.Slice(0, 4);
            var arrRight = view.Slice(4);

            Print(arrLeft);
            Print(arrRight);
        }

        {
            string input = "100,200";
            int pos = input.IndexOf(',');

            string v1 = input.Substring(0, pos);
            string v2 = input.Substring(pos + 1);

            {
                Console.WriteLine(int.Parse(v1));
                Console.WriteLine(int.Parse(v2));
            }
        }

        {
            string input = "100,200";
            int pos = input.IndexOf(',');
            ReadOnlySpan<char> view = input.AsSpan();

            ReadOnlySpan<char> v1 = view.Slice(0, pos);
            ReadOnlySpan<char> v2 = view.Slice(pos + 1);

            {
                Console.WriteLine(int.Parse(v1.ToString()));
                Console.WriteLine(int.Parse(v2.ToString()));

                // .NET Core 2.1 이후에는 다음의 코드가 가능
                // Console.WriteLine(int.Parse(v1));
                // Console.WriteLine(int.Parse(v2));
            }
        }

        {
            Span<byte> bytes = stackalloc byte[10];
            bytes[0] = 100;
            Print(bytes);
        }

        unsafe
        {
            int size = 10;
            IntPtr ptr = Marshal.AllocCoTaskMem(size);

            try
            {
                Span<byte> bytes = new Span<byte>(ptr.ToPointer(), size);
                bytes[9] = 100; // bytes[10] = 100;

                Print(bytes);
            }
            finally
            {
                Marshal.FreeCoTaskMem(ptr);
            }
        }

    }

    private static void Print(Span<byte> view)
    {
        foreach (byte elem in view)
        {
            Console.Write(elem + ",");
        }

        Console.WriteLine();
    }
}
