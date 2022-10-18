
/* ================= 예제 9.3: dynamic 사용 예 ================= */

using System;

class Program
{
    static void Main(string[] args)
    {
        dynamic d = 5;

        int sum = d + 10;
        Console.WriteLine(sum);
    }

    void DynamicSample()
    {
        /*
        var d = 5;
        d = "test"; // 컴파일 오류: d == System.Int32로 결정되기 때문에 문자열을 받을 수 없음

        d.CallFunc(); // 컴파일 오류: System.Int32 타입에는 CallFunc 메서드가 없음
        */

        dynamic d2 = 5;

        d2 = "test"; // d2는 형식이 결정되지 않았기 때문에 다시 문자열로 초기화 가능
        d2.CallFunc(); // 실행 시에 d2 변수의 타입으로 CallFunc을 호출하기 때문에
                       // 컴파일 오류가 발생하지 않음. 하지만 실행 시에는 오류 발생
    }
}