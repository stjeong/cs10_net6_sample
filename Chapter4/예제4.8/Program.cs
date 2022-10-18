
/* ================= 예제 4.8: 프로퍼티 사용 예제 ================= */

using System;

class Circle
{
    double pi = 3.14;

    public double Pi
    {
        get { return pi; }
        set { pi = value; }
    }

    // ……[생략]……

    /*

    public void set_Pi(double value)
    {
        this.pi = value;
    }

    public double get_Pi()
    {
        return this.pi;
    }

    */
}

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle o = new Circle();
            o.Pi = 3.14159; // 쓰기
            double piValue = o.Pi; // 읽기

            /*
            o.set_Pi(3.14159); // 쓰기
            double piValue = o.get_Pi(); // 읽기
            */
        }
    }
}


