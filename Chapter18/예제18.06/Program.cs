using System.Diagnostics;

{
    var list = new List<string> { "Anders", "Kevin" };

    // 람다 식에 특성 허용
    list.ForEach([MyMethod()] (elem) => Console.WriteLine(elem));
    // 컴파일 오류: 특성을 지정한 경우 매개 변수가 하나라도 반드시 괄호를 사용해야 함
    // list.ForEach([MyMethod()] elem => Console.WriteLine(elem));

    // 리턴 값에도 특성 허용
    Func<int> f1 = [return: MyReturn] () => 1;

    // 매개 변수에도 특성 허용
    Action<string> action = static ([MyParameter] elem) => Console.WriteLine(elem);

    // AttributeTargets.Method 유형의 특성을 모두 지원하지만,
    // 유일하게 Conditional 특성만 오류 처리
    // error CS0577: The Conditional attribute is not valid on 'lambda expression' because it is a constructor, destructor, operator, lambda expression, or explicit interface implementation

    // var f = [Conditional("DEBUG")] () => 1;
    // Action action2 = [Conditional("DEBUG")] () => Console.WriteLine();
}

{
    Func<int, short> f1 = short (x) => 1;
    MethodRefDelegate f2 = ref int (ref int x) => ref x;
    Action<int> f3 = static void (_) => { };
}

{
    Func<int, short> f1 = (x) => 1;
    MethodRefDelegate f2 = (ref int x) => ref x;
    Action<int> f3 = static (_) => { };
}


{
    // 컴파일 오류 - error CS8917: The delegate type could not be inferred.
    // var f1 = (x) => { }; // 매개 변수 타입의 모호
    // var f2 = () => default; // 반환 타입의 모호
    // var f3 = x => x; // 반환 및 매개 변수 타입의 모호
}


{
    var f1 = (int x) => { }; // 매개 변수 지정
    Console.WriteLine(f1.GetType().FullName);
    var f2 = int () => default; // 반환 타입 명시
    var f3 = int (int x) => x; // 반환 및 매개 변수 타입 명시

    var f4 = new[] { (string s) => s.Length, (string s) => int.Parse(s) }; // Func<string, int>[]
}

public delegate ref int MethodRefDelegate(ref int arg);

public class MyType<T>
{
    public void Print()
    {
        Func<T?> f = T? () => default;
        Func<T?> f2 = () => default;

        Console.WriteLine($"T Result: {f()}");
    }
}


[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class MyMethodAttribute : Attribute
{
}


[AttributeUsage(AttributeTargets.ReturnValue, AllowMultiple = true)]
public class MyReturnAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class MyParameterAttribute : Attribute
{
}