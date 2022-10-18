
/* ================= 예제 8.4: 메서드를 이용해 string 타입에 공용 메서드를 추가 ================= */

using System;

// 확장 메서드는 static 클래스에 정의돼야 함
static class ExtensionMethodSample
{
    // 확장 메서드는 반드시 static이어야 하고,
    // 확장하려는 타입의 매개변수를 this 예약어와 함께 명시
    public static int GetWordCount(this string txt)
    {
        return txt.Split(' ').Length;
    }
}

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello, World!";

            // 마치 string 타입의 인스턴스 메서드를 호출하듯이 확장 메서드를 사용
            Console.WriteLine("Count: " + text.GetWordCount()); // 출력 결과: Count: 2

            Console.WriteLine("Count: " + ExtensionMethodSample.GetWordCount(text));
        }
    }
}
