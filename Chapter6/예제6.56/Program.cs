
/* ================= 예제 6.56: 현재 AppDomain에 로드된 어셈블리 목록 ================= */

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
            Console.WriteLine("   " + asm.FullName);

            foreach (Module module in asm.GetModules())
            {
                Console.WriteLine("       " + module.FullyQualifiedName);

                foreach (Type type in module.GetTypes())
                {
                    Console.WriteLine("         " + type.FullName);
                }
            }
        }
    }
}