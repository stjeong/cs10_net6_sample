
/* ================= 예제 8.12: Max와 LINQ 쿼리의 조합 ================= */

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

            // 방법 1
            {
                var all = from person in people
                          where person.Address == "Korea"
                          select person;

                // 주소가 Korea인 사람 가운데 가장 높은 연령을 추출
                var oldestAge = all.Max((elem) => elem.Age);

                Console.WriteLine(oldestAge); // 출력 결과: 63
            }

            Console.WriteLine();

            // 방법 2
            {
                var oldestAge = people.Where((elem) => elem.Address == "Korea").Max((elem) => elem.Age);
                Console.WriteLine(oldestAge); // 출력 결과: 63
            }
        }
    }
}
