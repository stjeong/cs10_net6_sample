using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 예제12._5
{
    public class Vector
    {
        double x;
        double y;

        public Vector(double x) => this.x = x; // 생성자 정의 가능

        public Vector(double x, double y) // 생성자이지만 2개의 문장이므로 람다 식으로 정의 불가능
        {
            this.x = x;
            this.y = y;
        }

        ~Vector() => Console.WriteLine("~dtor()"); // 소멸자 정의 가능

        public double X
        {
            get => x;
            set => x = value; // 속성의 set 접근자 정의 가능
        }

        public double Y
        {
            get => y;
            set => y = value; // 속성의 set 접근자 정의 가능
        }

        public double this[int index]
        {
            get => (index == 0) ? x : y;
            set => _ = (index == 0) ? x = value : y = value; // 인덱서의 set 접근자 정의 가능
        }

        private EventHandler positionChanged;
        public event EventHandler PositionChanged // 이벤트의 add/remove 접근자 정의 가능
        {
            add => this.positionChanged += value;
            remove => this.positionChanged -= value;
        }

        public Vector Move(double dx, double dy)
        {
            x += dx;
            y += dy;

            positionChanged?.Invoke(this, EventArgs.Empty);

            return this;
        }

        public void PrintIt() => Console.WriteLine(this);

        public override string ToString() => string.Format("x = {0}, y = {1}", x, y);
    }


    class Program
    {
        static void Main(string[] args)
        {
            Vector v = new Vector(10, 20);
            v[0] = 11;
            v[1] = 21;

            Console.WriteLine(v);

            v.PositionChanged += PositionChanged;
            v.Move(100, 100);
        }

        private static void PositionChanged(object sender, EventArgs e)
        {
            if (sender is Vector)
            {
                Console.WriteLine((sender as Vector).ToString());
            }
        }
    }
}
