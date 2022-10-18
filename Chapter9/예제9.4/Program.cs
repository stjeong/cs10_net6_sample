
/* ================= 예제 9.4: C# 컴파일러가 dynamic 예약어를 위해 자동 생성하는 코드 ================= */

using System;
using System.Runtime.CompilerServices;
using Microsoft.CSharp.RuntimeBinder;

namespace ConsoleApplication1
{
    class Program
    {
        public static CallSite<Action<CallSite, object>> p__Site1;

        // dynamic 예약어를 쓰기 싫다면 다음과 같이 직접 코딩해도 동작한다.
        // 하지만 dynamic 예약어를 쓰는 것이 코드 가독성 측면에서 낫다.
        static void Main(string[] args)
        {
            object d = 5;

            if (p__Site1 == null)
            {
                p__Site1 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded,
                    "CallTest", null, typeof(Program),
                    new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
            }

            p__Site1.Target(p__Site1, d);
        }
    }
}

