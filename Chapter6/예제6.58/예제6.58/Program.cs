
/* ================= 예제 6.58: 별도의 AppDomain에 로드되는 어셈블리 ================= */

using System;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
#if NET_CORE
            Console.WriteLine("AppDomain.CreateDomain is not supported in .NET Core");
            return;
#else

            AppDomain newAppDomain = AppDomain.CreateDomain("MyAppDomain");
            string dllPath = GetClassLibaryPath();

            System.Runtime.Remoting.ObjectHandle objHandle
                = newAppDomain.CreateInstanceFrom(dllPath, "ClassLibrary1.Class1");

            Console.WriteLine("엔터키를 치기 전까지 ClassLibrary1.dll 파일을 지울 수 없습니다.");

            Console.ReadLine();
            AppDomain.Unload(newAppDomain); // AppDomain을 해제시킨다.
            Console.WriteLine("이젠 ClassLibrary1.dll 파일을 지울 수 있습니다.");
            Console.ReadLine();
#endif
        }

        private static string GetClassLibaryPath()
        {
            string path = Path.GetDirectoryName(typeof(Program).Assembly.Location);
            string libPath = Path.Combine(path, "..", "..", "..", "ClassLibrary1", "bin", "Debug", "ClassLibrary1.dll");

            return libPath;
        }
    }
}


