using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 예제13._4
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLog(DateTime.Now);
            WriteLog(DateTime.UtcNow);
        }

        public static void WriteLog<T>(T item)
        {
            if (item is DateTime time) // C# 7.0의 경우 컴파일 오류 발생
            {
                Console.WriteLine(time.ToString());
            }

            switch (item)
            {
                // C# 7.0의 경우 컴파일 오류 발생
                case DateTime dt when dt.Kind == DateTimeKind.Utc:
                    Console.WriteLine(dt.ToLocalTime());
                    break;

                case DateTime dt when dt.Kind == DateTimeKind.Unspecified:
                    Console.WriteLine("Invalid DateTime Kind");
                    break;

                case DateTime dt:
                    Console.WriteLine(dt);
                    break;
            }
        }
    }
}
