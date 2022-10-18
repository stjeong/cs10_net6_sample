using System;

class Program
{
    static void Main(string[] args)
    {
        {
            int number1 = 0x1_000;
            int number2 = 0x_1000; // C# 7.1 이전에는 컴파일 오류: Error CS1013 Invalid number

            int number3 = 0b1_000;
            int number4 = 0b_1000; // C# 7.1 이전에는 컴파일 오류: Error CS1013 Invalid number
        }

        {
            Person p = new Person();
            p.Output(name: "Tom", 16, address: "Tibet"); // C# 7.1 이전에는 컴파일 오류
                                                         // 첫 번째 인자에 이름을 지정했으므로 두 번째 인자도 이름을 지정해야 함
        }
    }

    class Person
    {
        public void Output(string name, int age = 0, string address = "Korea")
        {
            Console.WriteLine(string.Format("{0}: {1} in {2}", name, age, address));
        }
    }
}
