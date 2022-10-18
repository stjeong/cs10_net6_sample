using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 예제12._3
{
    public class IntResult
    {
        public bool Parsed { get; set; }
        public int Number { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Program pg = new Program();
            IntResult result = pg.ParseInteger("10");

            Console.WriteLine(result.Parsed);
            Console.WriteLine(result.Number);

            dynamic result2 = pg.ParseInteger2("20");
            Console.WriteLine(result2.Parsed);
            Console.WriteLine(result2.Number);

            Tuple<bool, int> result3 = pg.ParseInteger3("40");
            Console.WriteLine(result3.Item1);
            Console.WriteLine(result3.Item2);

            (bool, int) result4 = pg.ParseInteger4("50");
            Console.WriteLine(result4.Item1);
            Console.WriteLine(result4.Item2);

            (bool success, int n) result5 = pg.ParseInteger4("60");
            Console.WriteLine(result5.success);
            Console.WriteLine(result5.n);

            (var r1, var r2) = pg.ParseInteger4("60");
            Console.WriteLine(r1);
            Console.WriteLine(r2);

            (var _, var _) = pg.ParseInteger4("70");
            (var _, var n) = pg.ParseInteger4("70");
            Console.WriteLine(n);

            System.ValueTuple<bool, int> result6 = pg.ParseInteger4("80");
            Console.WriteLine(result6.Item1);
            Console.WriteLine(result6.Item2);

            var result7 = pg.ParseInteger5("90");
            Console.WriteLine(result7.Parsed);
            Console.WriteLine(result7.Number);


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
                    Console.WriteLine(string.Format("{0} - {1}", item.Item1, item.Item2));
                }

                var dateList2 = from person in people
                                select (Name: person.Name, Year: DateTime.Now.AddYears(-person.Age).Year);

                foreach (var item in dateList2)
                {
                    Console.WriteLine(string.Format("{0} - {1}", item.Name, item.Year));
                }
            }
        }

        IntResult ParseInteger(string text)
        {
            IntResult result = new IntResult();

            try
            {
                result.Number = Int32.Parse(text);
                result.Parsed = true;
            }
            catch
            {
                result.Parsed = false;
            }

            return result;
        }

        dynamic ParseInteger2(string text)
        {
            int number = 0;

            try
            {
                number = Int32.Parse(text);
                return new { Number = number, Parsed = true };
            }
            catch
            {
                return new { Number = number, Parsed = false };
            }
        }

        Tuple<bool, int> ParseInteger3(string text)
        {
            int number = 0;
            bool result = false;

            try
            {
                number = Int32.Parse(text);
                result = true;
            }
            catch
            {
            }

            return Tuple.Create(result, number);
        }

        (bool, int) ParseInteger4(string text)
        {
            int number = 0;
            bool result = false;

            try
            {
                number = Int32.Parse(text);
                result = true;
            }
            catch
            {
            }

            return (result, number);
        }

        (bool Parsed, int Number) ParseInteger5(string text)
        {
            int number = 0;
            bool result = false;

            try
            {
                number = Int32.Parse(text);
                result = true;
            }
            catch
            {
            }

            return (Parsed: result, Number: number);
        }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
        }
    }
}
