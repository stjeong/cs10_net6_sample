
/* ================= 예제 9.6: C#에서 파이썬 코드 실행 ================= */

using System;
using IronPython.Hosting;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var scriptEngine = Python.CreateEngine();
            // code 변수에 담긴 문자열은 python 코드임
            string code = @"
print 'Hello Python'
";
            scriptEngine.Execute(code); // 파이썬 코드가 실행되면서 콘솔 화면에는
                                        // 'Hello Python' 문자열 출력
        }
    }
}
