
/* ================= 예제 6.15: Stack 사용 예 ================= */

using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        Stack st = new Stack();

        st.Push(1);
        st.Push(5);
        st.Push(3);

        int last = (int)st.Pop();
        st.Push(7);

        while (st.Count > 0)
        {
            Console.Write(st.Pop() + ", ");
        } // 스택을 Pop 과정 없이 비우고 싶다면 st.Clear() 메서드를 호출해도 된다.
    }
}

