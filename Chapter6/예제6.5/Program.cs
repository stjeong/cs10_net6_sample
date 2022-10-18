
/* ================= 예제 6.5: 주어진 문자열이 전자 메일 형식인지 확인 ================= */

using System;

class Program
{
    static void Main(string[] args)
    {
        string email = "tester@test.com";
        Console.WriteLine(IsEmail(email)); // 출력 결과: True
    }

    static bool IsEmail(string email)
    {
        string[] parts = email.Split('@');

        if (parts.Length != 2)
        {
            return false;
        }

        if (IsAlphaNumeric(parts[0]) == false)
        {
            return false;
        }

        parts = parts[1].Split('.');

        if (parts.Length == 1)
        {
            return false;
        }

        foreach (string part in parts)
        {
            if (IsAlphaNumeric(part) == false)
            {
                return false;
            }
        }

        return true;
    }

    static bool IsAlphaNumeric(string text)
    {
        foreach (char ch in text)
        {
            if (char.IsLetterOrDigit(ch) == false)
            {
                return false;
            }
        }

        return true;
    }
}
