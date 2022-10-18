using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace 예제13._1
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    // MainAsync();
        //    MainAsync().GetAwaiter().GetResult();
        //}

        //static async Task Main(string [] args)
        //{
        //    WebClient wc = new WebClient();
        //    string text = await wc.DownloadStringTaskAsync("http://www.microsoft.com");
        //    Console.WriteLine(text);
        //}

        static async Task Main(string[] args) => Console.WriteLine(await new WebClient().DownloadStringTaskAsync("http://www.microsoft.com"));

        private static async Task MainAsync()
        {
            WebClient wc = new WebClient();
            string text = await wc.DownloadStringTaskAsync("http://www.microsoft.com");
            Console.WriteLine(text);
        }
    }
}
