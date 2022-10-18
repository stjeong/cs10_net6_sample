
/* ================= 예제 4.27: 다중 값을 포함하는 enum 인스턴스 ================= */

using System;

enum Days
{
    Sunday = 1, Monday = 2, Tuesday = 4,
    Wednesday = 8, Thursday = 16, Friday = 32, Saturday = 64
}

class Program
{
    static void Main(string[] args)
    {
        Days workingDays = Days.Monday | Days.Tuesday | Days.Wednesday | Days.Thursday | Days.Friday;

        Console.WriteLine(workingDays.HasFlag(Days.Sunday)); // Sunday를 포함하고 있는가?

        Days today = Days.Friday;

        Console.WriteLine(workingDays.HasFlag(today)); // today를 포함하고 있는가?
        Console.WriteLine(workingDays);
    }
}