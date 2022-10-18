using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {

    }
}

public class Base
{
    private protected void PP()
    {
        Console.WriteLine("From Base.PP()");
    }

    internal protected void IP()
    {
        Console.WriteLine("From Base.IP()");
    }
}

public class Another
{
    public void My()
    {
        Base b = new Base();

        // b.PP(); // 컴파일 에러: Another1 타입이 동일한 어셈블리 내에 정의되었지만 Base의 자식 클래스는 아니므로.
        b.IP(); // 컴파일 정상: Another1 타입이 동일한 어셈블리 내에 정의되었으므로.
    }
}

public class Derived : Base
{
    public void My()
    {
        base.PP(); // 컴파일 정상: D1 타입이 동일한 어셈블리 내에 "그리고" 자식 클래스이므로.
        base.IP(); // 컴파일 정상
    }
}
