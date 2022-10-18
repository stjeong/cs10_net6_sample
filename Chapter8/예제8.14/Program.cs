
/* ================= 예제 8.14: LINQ to XML ================= */

using System;
using System.Linq;
using System.Xml.Linq;
using System.IO;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string txt = @"
<people>
<person name='anders' age='47' />
<person name='winnie' age='13' />
</people>
";

            StringReader sr = new StringReader(txt);

            var xml = XElement.Load(sr);

            var query = from person in xml.Elements("person")
                        select person;

            foreach (var item in query)
            {
                Console.WriteLine(item.Attribute("name").Value + ": " + item.Attribute("age").Value);
            }
        }
    }
}