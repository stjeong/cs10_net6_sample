using System;

class Program
{
    static void Main(string[] args)
    {
    }
}

public partial class Computer
{
    private partial void Beep();
}

public partial class Computer
{
    private partial void Beep()
    {
        Console.WriteLine("Beep");
    }
}

public partial class DBContext
{
    public partial string GetConnectionString();
}

public partial class DBContext
{
    public partial string GetConnectionString()
    {
        return "";
    }
}
