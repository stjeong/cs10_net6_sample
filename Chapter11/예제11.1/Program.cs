
/* ================= 예제 11.1: 람다 식을 이용한 메서드 본문 구현 ================= */

using System;

namespace ConsoleApplication1
{
    public class Vector
    {
        double x;
        double y;

        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector Move(double dx, double dy) => new Vector(x + dx, y + dy);

        public void PrintIt() => Console.WriteLine(this);

        public override string ToString() => string.Format("x = {0}, y = {1}", x, y);

        public double Angle => Math.Atan2(y, x); // get만 자동 정의되고 set 기능은 제공되지 않는다.

        // 인덱서의 get 접근자를 람다 식으로 정의
        // 복잡해도 결국 단일 문이기만 하면 람다 식 적용 가능
        public double this[string angleType] =>
            angleType == "radian" ? this.Angle :
            angleType == "degree" ? RadianToDegree(this.Angle) : double.NaN;

        static double RadianToDegree(double angle) => angle * (180.0 / Math.PI);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(10, 20);

            Console.WriteLine(v1.Angle);
            Console.WriteLine(v1["radian"]);
            Console.WriteLine(v1["degree"]);
            Console.WriteLine(v1);
        }
    }
}



