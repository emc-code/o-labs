// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

SimpleWorker simpleWorker = new SimpleWorker();

int[] limits = [100000, 1000000, 10000000];

foreach (int limit in limits)
{
    Random rnd = new Random();
    int[] values = Enumerable.Range(0, limit).Select(_ => rnd.Next(-100, 100)).ToArray();

    Console.WriteLine("");
    Console.WriteLine($"limit: {limit}");
    Runner.Run(new SimpleWorker(), values);
    Runner.Run(new ThreadWorker(), values);
    Runner.Run(new LINQWorker(), values);
    Runner.Run(new ParallelLINQWorker(), values);
}




interface IWorker
{
    string GetName();
    long Calc(int[] values);
}

class Runner
{
    public static void Run(IWorker worker, int[] values)
    {
        Stopwatch sw = Stopwatch.StartNew();
        sw.Start();

        var result = worker.Calc(values);

        sw.Stop();

        Console.WriteLine($"{worker.GetName(),-20} : {sw.ElapsedMilliseconds}");
    }
}


class SimpleWorker : IWorker
{
    public long Calc(int[] values)
    {
        long result = 0;
        foreach (int value in values)
            result += value;

        return result;
    }

    public string GetName() => "Обычное";
}

class ThreadWorker : IWorker
{
    public long Calc(int[] values)
    {
        int threadAmount = 10;
        int step = values.Length / threadAmount;
        long result = 0;

        List<Thread> threads = new List<Thread>();
        Mutex mutex = new Mutex();
        for (int i = 0; i < threadAmount; i++)
        {
            int start = i * step;
            int end = (i == threadAmount - 1) ? values.Length - 1 : (i + 1) * step - 1;
            Thread thread = new Thread(() =>
            {
                var localSum = Summ(values, start, end);                
                Interlocked.Add(ref result, localSum);

            });
            threads.Add(thread);
        }

        threads.ForEach(t => t.Start());
        threads.ForEach(t => t.Join());

        return result;
    }

    public string GetName() => "Параллельное";

    private long Summ(int[] values, int start, int end)
    {
        long result = 0;

        for (int i = start; i <= end; i++)
            result += values[i];

        return result;
    }
}

class LINQWorker : IWorker
{
    public long Calc(int[] values)
    {
        return values.Sum(i => (long)i);

    }

    public string GetName() => "LINQ";
}

class ParallelLINQWorker : IWorker
{
    public long Calc(int[] values)
    {
        long result = values.AsParallel().Sum(i => (long)i);
        return result;
    }

    public string GetName() => "ParallelLINQ";
}