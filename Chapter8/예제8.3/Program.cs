
/* ================= 예제 8.3: 부분 메서드를 구현 ================= */

using System;

/*
class MyTest
{
    public int Add(int a, int b)
    {
        return a + b;
    }
}
*/

partial class MyTest
{
    // Log 메서드의 시그니처만 정의
    partial void Log(object obj);

    public void WriteTest()
    {
        // 시그니처만 정의됐지만 구현부의 존재에 상관없이 메서드 사용이 가능
        this.Log("call test!");
    }
}

// 다른 파일로 분리돼 있어도 되지만 반드시 동일한 프로젝트에 있어야 함
partial class MyTest
{
    // Log 메서드의 구현부 정의
    partial void Log(object obj)
    {
        Console.WriteLine(obj.ToString());
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyTest t = new MyTest();
        t.WriteTest(); // 출력 결과: call test!
    }
}

