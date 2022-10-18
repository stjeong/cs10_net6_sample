class Program
{
    static void Main(string[] args)
    {
        int a = 5;
        ref int b = ref a; // ref 로컬 변수 b

        int c = 6;

        // C# 7.2까지 컴파일 오류 - Error CS1073 Unexpected token 'ref'
        b = ref c; // 새롭게 변수 c에 대한 ref를 할당
    }
}
