using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        {
            int result; // 이렇게 변수를 미리 선언
            int.TryParse("5", out result);
        }

        {
            int.TryParse("5", out int result);
            Console.WriteLine(result);
        }

        {
            int.TryParse("5", out int result);
            // int.TryParse("5", out int result); // 컴파일 오류!
        }

        {
            int.TryParse("5", out var result); // int out result로 컴파일러가 대신 처리
        }

        {
            int.TryParse("5", out int _); // 타입명까지 지정해도 컴파일이 잘 됩니다.
            int.TryParse("5", out var _);
        }
    }
}
