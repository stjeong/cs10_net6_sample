using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace 예제12._10
{
    class Program
    {
        static void Main(string[] args)
        {
            object obj = new List<string>();

            {
                List<string> list = obj as List<string>;
                list?.ForEach((e) => Console.WriteLine(e));
            }

            {
                if (obj is List<string> list)
                {
                    list.ForEach((e) => Console.WriteLine(e));
                }
            }

            object[] objList = new object[] { 100, null, DateTime.Now, new ArrayList() };

            foreach (object item in objList)
            {
                if (item is 100) // 상수 패턴
                {
                    Console.WriteLine(item);
                }
                else if (item is null)
                {
                    Console.WriteLine("null");
                }
                else if (item is DateTime dt) // 타입 패턴(값 형식 가능)
                {
                    Console.WriteLine(dt);
                }
                else if (item is ArrayList arr) // 타입 패턴(참조 형식 가능
                {
                    Console.WriteLine(arr.Count);
                }
                else if (item is var elem)
                {
                    Console.WriteLine(elem);
                }
            }

            foreach (object item in objList)
            {
                switch (item)
                {
                    case 100:
                        break;

                    case null:
                        break;

                    case DateTime dt:
                        break;

                    case ArrayList arr:
                        break;

                    case var elem:
                        break;

                }
            }

            int j = 500;
            if (j > 300)
            {
            }
            else
            {
            }

            switch (j)
            {
                case int i when i > 300:
                    break;

                default:
                    break;
            }

            string text = "카카오";

            switch (text)
            {
                case var item when (ContainsAt(item, "http://www.naver.com")):
                    Console.WriteLine("In Naver");
                    break;

                case var item when (ContainsAt(item, "http://www.daum.net")):
                    Console.WriteLine("In Daum");
                    break;

                default:
                    Console.WriteLine("None");
                    break;
            }

            Action<(int, int)> detectZeroOR = (arg) =>
            {
                switch (arg)
                {
                    case var r when r.Equals((0, 0)):
                    case var r1 when r1.Item1 == 0:
                    case var r2 when r2.Item2 == 0:
                        Console.WriteLine("Zero found.");
                        return;
                }

                Console.WriteLine("Both nonzero.");
            };

            detectZeroOR((0, 0));
            detectZeroOR((1, 0));
            detectZeroOR((0, 10));
            detectZeroOR((10, 15));
        }

        private static bool ContainsAt(string item, string url)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string text = wc.DownloadString(url);

            return text.IndexOf(item) != -1;
        }
    }
}
