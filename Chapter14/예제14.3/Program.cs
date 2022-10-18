class Program
{
    readonly Vector v1 = new Vector();

    static void Main(string[] args)
    {
        Program pg = new Program();
        StructParam(in pg.GetVector());

        Vector v2 = pg.GetVector();

        ref readonly Vector v3 = ref pg.GetVector();
    }

    private static void StructParam(in Vector v)
    {
        v.Increment(1, 1);
    }

    private ref readonly Vector GetVector()
    {
        return ref v1;
    }
}

readonly struct Vector
{
    readonly public int X;
    readonly public int Y;

    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Vector Increment(int x, int y)
    {
        return new Vector(X + x, Y + y);
    }
}
