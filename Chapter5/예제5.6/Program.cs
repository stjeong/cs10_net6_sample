
/* ================= 예제 5.6: appSettings의 값을 읽는 코드 ================= */

using System;
using System.Configuration;

class Program
{
    static void Main(string[] args)
    {
        string txt = ConfigurationSettings.AppSettings["AdminEmailAddress"];
        Console.WriteLine(txt); // 출력결과: admin@sysnet.pe.kr

        txt = ConfigurationSettings.AppSettings["Delay"];
        int delay = int.Parse(txt);
        Console.WriteLine(delay); // 출력결과: 5000


        txt = ConfigurationManager.AppSettings["AdminEmailAddress"];
        txt = ConfigurationManager.AppSettings["Delay"];
    }
}
