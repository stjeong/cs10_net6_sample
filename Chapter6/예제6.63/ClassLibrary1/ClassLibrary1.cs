using System;
using System.Collections.Generic;

/* ================= 예제 6.63: 확장 모듈 제작 ================= */

namespace ClassLibrary1
{
    [PluginAttribute]
    public class SystemInfo
    {
        bool _is64Bit;

        public SystemInfo()
        {
            _is64Bit = Environment.Is64BitOperatingSystem;
            Console.WriteLine("SystemInfo created.");
        }

        [StartupAttribute]
        public void WriteInfo()
        {
            Console.WriteLine("OS == {0}bits", (_is64Bit == true) ? "64" : "32");
        }
    }

    public class PluginAttribute : Attribute
    {
    }

    public class StartupAttribute : Attribute
    {
    }
}