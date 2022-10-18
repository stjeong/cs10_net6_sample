class Program
{
    static void Main(string[] args)
    {
        IDevice device = (new Product() as IProduct).GetDevice();
        ISoundDevice soundDevice = new Headset().GetDevice();
    }
}

public interface IProduct
{
    IDevice GetDevice();
}

public class Product : IProduct
{
    public virtual IDevice GetDevice() { return new Device(); }
}

public class Headset : Product
{
    // C# 8.0 이전 컴파일 오류
    // C# 9.0 + .NET 5 환경에서 컴파일 가능
    public override ISoundDevice GetDevice()
    {
        return new SoundDevice();
    }
}

public interface IDevice
{
}

public class Device : IDevice
{
}

public interface ISoundDevice : IDevice
{
}

public class SoundDevice : ISoundDevice
{
}