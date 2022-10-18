using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Computer my = new Computer();

        foreach (Device device in my)
        {
            Console.WriteLine(device.Name);
        }

        Notebook notebook = new Notebook();

        foreach (Device device in notebook)
        {
            Console.WriteLine(device.Name);
        }
    }
}

public static class NotebookExtension
{
    public static IEnumerator<Device> GetEnumerator(this Notebook instance)
    {
        foreach (Device device in instance.GetDevices())
        {
            yield return device;
        }
    }
}

public class Notebook
{
    List<Device> _parts;

    public Notebook()
    {
        _parts = new List<Device>()
        {
            new Device() { Name = "CPU"},
            new Device() { Name = "MotherBoard"},
        };
    }

    public Device[] GetDevices()
    {
        return _parts.ToArray();
    }
}

public class Computer
{
    List<Device> _parts;

    public Computer()
    {
        _parts = new List<Device>()
        {
            new Device() { Name = "CPU"},
            new Device() { Name = "MotherBoard"},
        };
    }

    public Device[] GetDevices()
    {
        return _parts.ToArray();
    }

    public PartList GetEnumerator()
    {
        return new PartList(this);
    }

    public class PartList
    {
        Device[] _devices;
        public PartList(Computer computer) { _devices = computer.GetDevices(); }

        int _current = -1;

        public Device Current
        {
            get { return _devices[_current]; }
        }

        public bool MoveNext()
        {
            if (_current >= _devices.Length - 1)
            {
                return false;
            }

            _current++;
            return true;
        }
    }
}

public record Device
{
    public string Name { get; init; }
}

#if !NET5_0
// .NET 5.0 환경이 아닌 경우 IsExternalInit 클래스를 별도로 정의해서 컴파일 가능하게 만듦
namespace System.Runtime.CompilerServices
{
    public class IsExternalInit
    {
    }
}
#endif

