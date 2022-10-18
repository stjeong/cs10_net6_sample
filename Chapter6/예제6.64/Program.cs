

/* ================= 예제 6.64: 레지스트리 값 읽기 ================= */

using System;
using Microsoft.Win32;

class Program
{
    static void Main(string[] args)
    {
        string regPath = @"HARDWARE\DESCRIPTION\System\BIOS";

        using (RegistryKey systemKey = Registry.LocalMachine.OpenSubKey(regPath))
        {
            string biosDate = (string)systemKey.GetValue("BIOSReleaseDate");
            string biosMaker = (string)systemKey.GetValue("BIOSVendor");

            Console.WriteLine("BIOS 날짜: " + biosDate);
            Console.WriteLine("BIOS 제조사: " + biosMaker);
        }

        /*
        // 윈도우 비스트 이상의 사용자 계정 컨트롤(UAC)이 동작하는 환경에서는 예외 발생
        // 관리자 권한의 cmd.exe 창을 띄워 아래의 예제 코드를 실행하거나,
        // Visual Studio 자체를 관리자 권한으로 띄워 예제를 실행하면 오류가 발생하지 않음.
        using (RegistryKey regKey = Registry.LocalMachine.OpenSubKey(regPath, true))
        {
            regKey.SetValue("TestValue1", 5); // REG_DWORD로 기록됨
            regKey.SetValue("TestValue2", "Test"); // REG_SZ로 기록됨
        }
        */
    }
}
