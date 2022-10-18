using System;

class Program
{
    static unsafe void Main(string[] args)
    {
        Span<int> arr = stackalloc int[] { 0, 1, 2 };

        PrintArray(arr);

        // C# 7.3 이전까지 컴파일 에러: stackalloc은 지역 변수 초기화 구문에만 사용 가능
        PrintArray(stackalloc int[] { 2, 3, 4 });

        {
            int length = (stackalloc int[] { 1, 2, 3 }).Length;
        }

        {
            if (stackalloc int[10] == stackalloc int[10]) { }
        }
    }

    private static void PrintArray(Span<int> arr)
    {
        foreach (int item in arr)
        {
            Console.Write(item + ",");
        }
    }
}
