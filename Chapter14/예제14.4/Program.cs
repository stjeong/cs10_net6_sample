class Program
{
    static void Main(string[] args)
    {
        // Matrix matrix = new Matrix();

        Matrix2x2 matrix = new Matrix2x2();
    }
}

ref struct Vector
{
    public int X;
    public int Y;

    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }
}

/*
class Matrix
{
    public Vector Rx = new Vector(1, 2);
    public Vector Ry = new Vector(10, 20);
}
*/

ref struct Matrix2x2
{
    public Vector v1; // ref struct Vector
    public Vector v2;
}
