
/* ================= 예제 8.13: LINQ 쿼리의 지연 실행 테스트 ================= */

using System;
using System.Linq; // LINQ 쿼리 수행을 위해 반드시 포함해야 하는 네임스페이스
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1} in {2}", Name, Age, Address);
        }
    }

    class MainLanguage
    {
        public string Name { get; set; }
        public string Language { get; set; }
    }

    class Program
    {
        static bool IsEqual(string arg1, string arg2)
        {
            Console.WriteLine("Executed");
            return arg1 == arg2;
        }

        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
                {
                new Person { Name = "Tom", Age = 63, Address = "Korea" },
                new Person { Name = "Winnie", Age = 40, Address = "Tibet" },
                new Person { Name = "Anders", Age = 47, Address = "Sudan" },
                new Person { Name = "Hans", Age = 25, Address = "Tibet" },
                new Person { Name = "Eureka", Age = 32, Address = "Sudan" },
                new Person { Name = "Hawk", Age = 15, Address = "Korea" },
                };

            List<MainLanguage> languages = new List<MainLanguage>
                {
                    new MainLanguage { Name = "Anders", Language = "Delphi" },
                    new MainLanguage { Name = "Anders", Language = "C#" },
                    new MainLanguage { Name = "Tom", Language = "Borland C++" },
                    new MainLanguage { Name = "Hans", Language = "Visual C++" },
                    new MainLanguage { Name = "Winnie", Language = "R" },
                };

            // LINQ 쿼리가 바로 실행됨
            Console.WriteLine("ToList() executed");
            var inKorea = (from person in people where IsEqual(person.Address, "Korea")
                           select person).ToList();

            // 따라서 IsEqual 메서드의 실행으로 인해 화면에는 "Executed" 문자열이 출력됨
            Console.ReadLine();

            Console.WriteLine("IEnumerable<T> Where/Select evaluated");
            // IEnumerable<T>를 반환하므로 LINQ 쿼리가 평가만 되고 실행되지 않음
            var inKorea2 = from person in people
                           where IsEqual(person.Address, "Korea")
                           select person;
            
            // 따라서 IsEqual 메서드가 실행되지 않으므로 화면에는 "Executed" 문자열이 출력되지 않음.
            Console.ReadLine();
            
            // Take 확장 메서드 역시 IEnumerable<T>를 반환하므로 "Executed" 문자열이 출력되지 않음.
            Console.WriteLine("IEnumerable<T> Take evaluated");
            var firstPeople = inKorea2.Take(1);

            Console.ReadLine();
            
            // 열거를 시작했을 때 LINQ 쿼리가 실제로 실행됨.
            // 이때서야 비로소 "Executed" 문자열이 화면에 출력됨
            foreach (var item in firstPeople)
            {
                Console.WriteLine(item);
            }
            
            // 단일 값을 반환하는 Single 메서드의 호출은 곧바로 LINQ 쿼리가 실행되게 만듦
            Console.WriteLine(firstPeople.Single());
        }
    }
}
