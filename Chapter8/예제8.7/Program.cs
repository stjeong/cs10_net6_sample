
/* ================= 예제 8.7: Func, Action 델리게이트 ================= */

using System;

class Program
{
    static void Main(string[] args)
    {
        Action<string> logOut =
            (txt) =>
            {
                Console.WriteLine(DateTime.Now + ": " + txt);
            };

        logOut("This is my world!");

        Func<double> pi = () => 3.141592;
        Console.WriteLine(pi());
    }
}
