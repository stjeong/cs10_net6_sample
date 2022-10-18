class Program
{
    static void Main(string[] args)
    {
        var tuple = (13, "Kevin");

        // C# 7.2까지 컴파일 오류 - Error CS0019 Operator '==' cannot be applied to operands of type '(int, string)' and '(int, string)'
        bool result1 = tuple == (13, "Winnie");

        // C# 7.2까지 컴파일 오류 - Error CS0019 Operator '!=' cannot be applied to operands of type '(int, string)' and '(int, string)'
        bool result2 = tuple != (13, "Winnie");
    }
}
