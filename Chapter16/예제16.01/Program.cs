#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        var miguel = new Person();
        int length = GetLengthOfName(miguel);
        WriteLine(length);

        var deIcaza = new NullablePerson();
        GetLengthOfName(deIcaza);

        DoesNotReturnTest dnrt = new DoesNotReturnTest();
    }

    static int GetLengthOfName(Person person)
    {
        return person.Name.Length;
    }

    static int GetLengthOfName(NullablePerson person)
    {
        //if (person.Name == null)
        //{
        //    return 0;
        //}

        if (IsNull(person.Name))
        {
            return 0;
        }

        Console.WriteLine(person.Name.Length);

        if (IsNotNull(person.Name))
        {
            return person.Name.Length;
        }

        return 0;
    }

    static bool IsNotNull([NotNullWhen(true)] string? value)
    {
        if (value == null)
        {
            return false;
        }

        return true;
    }

    static bool IsNull([NotNullWhen(false)] string? value)
    {
        if (value == null)
        {
            return true;
        }

        // Console.WriteLine(value.Length);

        return false;
    }
}

public class Person
{
    public string Name { get; set; } = "";

    public Person() { }

    public Person(string name)
    {
        Name = name;
    }
}

public class NullablePerson
{
    public string? Name { get; set; }

    public NullablePerson() { } // null일 수 있으므로 허용

    public NullablePerson(string name)
    {
        Name = name;
    }

    public void Method()
    {
        Name = null; // null일 수 있으므로 허용
    }
}


public class AllowAttrTest
{
    public AllowAttrTest()
    {
        GetLengthOfText(null);
    }

    public int GetLengthOfText([AllowNull] string text)
    {
        return text.Length; // warning CS8602
    }
}

public class DisallowAttrTest
{
    public DisallowAttrTest()
    {
        // GetLengthOfText(null); // warning CS8625
    }

    public int GetLengthOfText([DisallowNull] string? text)
    {
        return text!.Length;
    }
}

public class DoesNotReturnTest
{
    public DoesNotReturnTest()
    {
        string text = Environment.GetEnvironmentVariable("TEST");
        if (text == null)
        {
            LogAndThrowNullArg($"{nameof(text)}");
        }

        Console.WriteLine(text.Length);
    }

    [DoesNotReturn]
    private void LogAndThrowNullArg(string name)
    {
        throw new ArgumentNullException(name);
    }

    [DoesNotReturn]
    public void EnsureNotNull(string? text)
    {
        if (text == null)
        {
            throw new ApplicationException("NULL-REF");
        }

    } // Warning CS8763: A method marked [DoesNotReturn] should not return.
}

public class DoesNotReturnIfTest
{
    public int GetLengthOf(string? text)
    {
        EnsureNotNull(text == null);
        return text.Length;
    }

    // public void EnsureNotNull(/*[DoesNotReturnIf(true)]*/ bool isNull)
    public void EnsureNotNull([DoesNotReturnIf(true)] bool isNull)
    {
        if (isNull == true)
        {
            throw new ApplicationException("NULL-REF");
        }
    }
}

public class MaybeNullTest<T>
{
    public MaybeNullTest()
    {
        string? text = GetText();
    }

    [return: MaybeNull]
    public string GetText()
    {
        string text = "test";
        return text;
    }

    List<T> list = new List<T>();

    [return: MaybeNull]
    public T Get()
    {
        return list.FirstOrDefault<T>();
    }
}

public class MaybeNullWhenTest
{
    public MaybeNullWhenTest()
    {
        if (GetText(out string? text))
        {
            Console.WriteLine(text.Length);
        }
    }

    List<string> list = new List<string>();

    public bool GetText([MaybeNullWhen(false)] out string text)
    {
        text = list.FirstOrDefault();
        return text != null;
    }
}

public class NotNullIfNotNullTest
{
    public NotNullIfNotNullTest()
    {
        string? input = "test";
        string? result = GetText(input);

        if (input == null)
        {
            return;
        }

        Console.WriteLine(result.Length);
    }

    [return: NotNullIfNotNull("text")]
    public string? GetText(string? text)
    {
        return text + "";
    }
}


// #nullable restore