
/* ================= 예제 9.1: 3개의 인자에 대한 메서드 오버로드 정의 ================= */

using System;

namespace ConsoleApplication1
{
    class Person
    {
        public void Output(string name)
        {
            Output(name, 0, "Korea");
        }

        public void Output(string name, int age)
        {
            Output(name, age, "Korea");
        }

        public void Output(string name, int age, string address)
        {
            Console.WriteLine(string.Format("{0}: {1} in {2}", name, age, address));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.Output("Anders");
            p.Output("Winnie", 36);
            p.Output("Tom", 28, "Tibet");
        }
    }
}