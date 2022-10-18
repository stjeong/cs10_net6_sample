
/* ================= 예제 4.26: enum 타입의 사용 ================= */

using System;

enum Days
{
    Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
}

/*
enum Days
{
    Sunday = 5, Monday = 10, Tuesday, Wednesday, Thursday = 15, Friday, Saturday
}
*/

class Program
{
    static void Main(string[] args)
    {
        Days today = Days.Sunday;
        Console.WriteLine(today); // 출력 결과: Sunday



        today = Days.Sunday;
        int n = (int)today; // enum에서 int 형으로 명시적 변환
        short s = (short)today; // enum에서 short 형으로 명시적 변환

        today = (Days)5; // 숫자형에서 enum 형으로 명시적 변환

        Console.WriteLine(today); // 출력 결과: Friday
    }
}
