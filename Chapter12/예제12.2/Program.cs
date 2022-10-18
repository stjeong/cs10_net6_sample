using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 예제12._2
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                int a = 5;
                int b = a;

                a = 6;

                Console.WriteLine(a);
                Console.WriteLine(b);
            }

            {
                int a = 5;
                ref int b = ref a;

                a = 6;

                Console.WriteLine(a);
                Console.WriteLine(b);
            }

            Console.WriteLine();

            {
                IntList intList = new IntList();
                int[] list = intList.GetList();
                list[0] = 5;

                intList.Print();
            }

            {
                IntList intList = new IntList();
                ref int item = ref intList.GetFirstItem();
                item = 5;

                intList.Print();
            }

            {
                MyMatrix matrix = new MyMatrix();
                matrix.Put(0, 0) = 1;

                int result = matrix.Put(0, 0) = 1;
                Console.WriteLine(result);
            }
        }

    }

    class IntList
    {
        int[] list = new int[2] { 1, 2 };

        public int[] GetList()
        {
            return list;
        }

        public ref int GetFirstItem()
        {
            return ref list[0];
        }

        internal void Print()
        {
            Array.ForEach(list, (e) => Console.Write(e + ","));
            Console.WriteLine();
        }

        //public ref int RefReturnOfLocalValue()
        //{
        //    int x = 5;
        //    return ref x;
        //}

        //public void ChangeRefLocalVar()
        //{
        //    int a = 5;
        //    ref int b = ref a;

        //    int c = 10;
        //    b = ref c;
        //    ref b = ref c;
        //}
    }

    class MyMatrix
    {
        int[,] _matrix = new int[100, 100];

        public ref int Put(int column, int row)
        {
            return ref _matrix[column, row];
        }
    }
}
