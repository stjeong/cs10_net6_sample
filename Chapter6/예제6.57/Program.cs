
/* ================= 예제 6.57: 어셈블리에 포함된 모든 타입을 열거 ================= */

using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        AppDomain currentDomain = AppDomain.CurrentDomain;
        Console.WriteLine("Current Domain Name: " + currentDomain.FriendlyName);

        foreach (Assembly asm in currentDomain.GetAssemblies())
        {
            Console.WriteLine("    " + asm.FullName);
            foreach (Type type in asm.GetTypes())
            {
                Console.WriteLine("        " + type.FullName);
            }
        }
    }
}
