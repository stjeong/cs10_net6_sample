class Program
{
    static void Main(string[] args)
    {
        Program pg = new Program();

        Vector v1 = new Vector();
        pg.StructParam(in v1);

        // pg.ClassParam(in pg);
    }

    void StructParam(in /* ref + readonly */ Vector v)
    {
        // v.X = 5; // CS8332 Cannot assign to a member of variable 'in Vector' because it is a readonly variable
    }

    /*
    void StructParam(ref Vector p)
    {
    }

    void StructParam(out Vector p)
    {
    }
    */
}

struct Vector
{
    public int X;
    public int Y;
}

