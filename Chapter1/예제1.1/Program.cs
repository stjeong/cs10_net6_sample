
/* ================= 예제 1.1: CIL 확인용 예제 ================= */

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int a = 5;
        int b = 6;
        int c = a + b;


    }
}

#if !NET5_0 && !NET6_0
// .NET 5 환경이 아닌 경우 IsExternalInit 클래스를 별도로 정의해서 컴파일 가능하게 만듦
namespace System.Runtime.CompilerServices
{
    public class IsExternalInit
    {
    }
}
#endif
