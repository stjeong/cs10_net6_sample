using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 예제12._8
{

    class Person
    {
        public string Name { get; }

        // null 병합 연산자(??)의 표현식에서 throw 사용 가능
        public Person(string name) => Name = name ??
                            throw new ArgumentNullException(nameof(name));

        public string GetFirstName()
        {
            var parts = Name.Split(' ');

            // 조건 연산자(?:)의 표현식에서 사용 가능
            return (parts.Length > 0) ? parts[0] : throw new InvalidOperationException("No name!");
            // return (parts.Length > 0) ? throw new InvalidOperationException() : parts[0];
        }

        // 람다 식으로 정의된 메서드에서 사용 가능
        public string GetLastName() => throw new NotImplementedException();

        public void Assert(bool result) =>
#if DEBUG
            _ = result == true ? result : throw new ApplicationException("ASSERT");
#else
            _ = result;
#endif

        public void Print()
        {
            // 단일 람다 식에서 사용 가능
            Action action = () => throw new Exception();
            action();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
