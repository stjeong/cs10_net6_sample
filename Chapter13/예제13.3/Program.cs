using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 예제13._3
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                int age = 20;
                string name = "Kevin Arnold";

                (int, string) person = (age, name);
                Console.WriteLine($"{person.Item1}, {person.Item2}");
            }

            {
                int age = 20;
                string name = "Kevin Arnold";

                (int age, string name) person = (age, name);
                Console.WriteLine($"{person.age}, {person.name}");
            }

            {
                int age = 20;
                string name = "Kevin Arnold";
                var t = (age, name);
                Console.WriteLine($"{t.age}, {t.name}");
            }

            {
                var person = new { Age = 30, Name = "Winnie Cooper" };

                var t = (person.Age, person.Name);
                Console.WriteLine($"{t.Age}, {t.Name}");
            }


            {
                var person = new { Age = 30, Name = "Winnie Cooper" };

                var t = (30, person.Name);
                Console.WriteLine($"{t.Item1}, {t.Name}");
            }

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

                var dateList = from person in people
                               select (person.Name, DateTime.Now.AddYears(-person.Age).Year);

                foreach (var item in dateList)
                {
                    Console.WriteLine(string.Format("{0} - {1}", item.Name, item.Year));
                }
            }
        }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
        }
    }
}
