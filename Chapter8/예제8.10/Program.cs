
/* ================= 예제 8.10: Expression 타입으로 직접 구성한 식 트리 ================= */

using System;
using System.Linq.Expressions;

class Program
{

    static void Main(string[] args)
    {
        ParameterExpression leftExp = Expression.Parameter(typeof(int), "a");
        ParameterExpression rightExp = Expression.Parameter(typeof(int), "b");

        BinaryExpression addExp = Expression.Add(leftExp, rightExp);

        Expression<Func<int, int, int>> addLambda =
                Expression<Func<int, int, int>>.Lambda<Func<int, int, int>>(addExp, new ParameterExpression[] { leftExp, rightExp });

        Console.WriteLine(addLambda.ToString()); // 출력 결과: (a, b) => (a + b)

        Func<int, int, int> addFunc = addLambda.Compile();
        Console.WriteLine(addFunc(10, 2)); // 출력 결과: 12
    }
}
