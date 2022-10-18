using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        {
            await foreach (int value in GenerateSequence(10))
            {
                Console.WriteLine($"{value} (tid: {Thread.CurrentThread.ManagedThreadId})");
            }

            Console.WriteLine($"Completed (tid: {Thread.CurrentThread.ManagedThreadId})");
        }

        {
            var enumerator = GenerateSequence(10).GetAsyncEnumerator();
            try
            {
                while (await enumerator.MoveNextAsync())
                {
                    int item = enumerator.Current;
                    Console.WriteLine($"{item} (tid: {Thread.CurrentThread.ManagedThreadId})");
                }

                Console.WriteLine($"Completed (tid: {Thread.CurrentThread.ManagedThreadId})");
            }
            finally
            {
                await enumerator.DisposeAsync();
            }
        }
    }

    public static async IAsyncEnumerable<int> GenerateSequence(int count)
    {
        for (int i = 0; i < count; i++)
        {
            await Task.Run(() => Thread.Sleep(100));
            yield return i;
        }
    }
}
