using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        {
            Action action = () => { Console.WriteLine("Action"); };
            ActionProxy<Action> proxy = new ActionProxy<Action>(action);
            proxy.Call();
        }

        {
            Action<int> action = (arg) => { Console.WriteLine($"Action<int>: {arg}"); };
            ActionProxy<Action<int>> proxy = new ActionProxy<Action<int>>(action);
            proxy.Call();
        }

        {
            EnumValueCache<Days> days = new EnumValueCache<Days>();

            Console.WriteLine(days.GetInteger(Days.Friday));
            Console.WriteLine(days.GetInteger(Days.Thursday));
        }

        unsafe
        {
            int n = 10;
            using (UnmanagedWrapper<int> intArray = new UnmanagedWrapper<int>(n))
            {
                for (int i = 0; i < n; i++)
                {
                    intArray[i] = i;
                }

                for (int i = 0; i < n; i++)
                {
                    Console.Write(intArray[i] + ",");
                }
            }
        }

        unsafe
        {
            int n = 10;
            using (UnmanagedWrapper<long> longArray = new UnmanagedWrapper<long>(n))
            {
                for (int i = 0; i < n; i++)
                {
                    longArray[i] = i;
                }

                for (int i = 0; i < n; i++)
                {
                    Console.Write(longArray[i] + ",");
                }
            }
        }
    }
}

class UnsafeMethods
{
    [DllImport("kernel32.dll")]
    public static extern void RtlZeroMemory(IntPtr dst, int length);
}

class UnmanagedWrapper<T> : IDisposable where T : unmanaged
{
    IntPtr _pArray;
    int _maxElements;

    public unsafe UnmanagedWrapper(int n)
    {
        _maxElements = n;

        int size = sizeof(T) * n;
        _pArray = Marshal.AllocCoTaskMem(size);
        UnsafeMethods.RtlZeroMemory(_pArray, size);
    }

    public unsafe T this[int idx]
    {
        get
        {
            T* ptr = ((T*)_pArray.ToPointer() + idx);
            return *ptr;
        }
        set
        {
            T* ptr = ((T*)_pArray.ToPointer() + idx);
            *ptr = value;
        }
    }

    public void Dispose()
    {
        Marshal.FreeCoTaskMem(_pArray);
    }
}

class ActionProxy<T> where T : System.Delegate /* System.MulticastDelegate */
{
    T _callbackFunc;

    public ActionProxy(T callbackFunc)
    {
        _callbackFunc = callbackFunc;
    }

    public void Call()
    {
        switch (_callbackFunc)
        {
            case Action action:
                action();
                break;

            case Action<int> action:
                action(5);
                break;
        }
    }
}

class EnumValueCache<TEnum> where TEnum : System.Enum
{
    Dictionary<TEnum, int> _enumKey = new Dictionary<TEnum, int>();

    public EnumValueCache()
    {
        int[] intValues = Enum.GetValues(typeof(TEnum)) as int[];
        TEnum[] enumValues = Enum.GetValues(typeof(TEnum)) as TEnum[];

        for (int i = 0; i < intValues.Length; i++)
        {
            _enumKey.Add(enumValues[i], intValues[i]);
        }
    }

    public int GetInteger(TEnum value)
    {
        return _enumKey[value];
    }
}

enum Days
{
    Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
}
