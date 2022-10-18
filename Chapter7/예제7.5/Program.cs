
/* ================= 예제 7.5: IEnumerable 인터페이스를 이용한 자연수 표현 ================= */

using System;
using System.Collections;
using System.Collections.Generic;

// 물론 이 예제는 int 범위의 자연수만 표현한다.
// 좀더 큰 자연수가 필요하다면 ulong을 쓰거나 BigInteger를 사용한다.
public class NaturalNumber : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator()
    {
        return new NaturalNumberEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new NaturalNumberEnumerator();
    }

    public class NaturalNumberEnumerator : IEnumerator<int>
    {
        int _current;

        public int Current
        {
            get { return _current; }
        }

        object IEnumerator.Current
        {
            get { return _current; }
        }

        public void Dispose() { }

        public bool MoveNext()
        {
            _current++;
            return true;
        }

        public void Reset()
        {
            _current = 0;
        }
    }
}

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            NaturalNumber number = new NaturalNumber();
            foreach (int n in number) // 출력 결과: 1부터 자연수를 무한하게 출력
            {
                Console.WriteLine(n);
            }
        }
    }
}