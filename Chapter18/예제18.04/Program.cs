using System;
using System.Diagnostics;

namespace ConsoleApp;

[DebuggerDisplay("class" + nameof(ConsoleApp) + "." + nameof(Program))]
[DebuggerDisplay($"class {nameof(ConsoleApp)}.{nameof(Program)}")]
internal class Program
{
    static void Main(string[] args)
    {
        const string Author = "Anders";

        // C# 9 이하에서는 컴파일 오류 - error CS0133: The expression being assigned to 'text' must be constant
        const string text = $"C#: {Author}";
        Console.WriteLine(text);

        // 컴파일 에러: 문자열 상수 이외에는 보간식 내에 사용할 수 없음
        // const float PI = 3.14f;
        // const string output = $"nameof{PI} == {PI}";
    }
}
