using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        int batchSize = 10000;
        int totalCalculations = 1000000;

        BatchCalculator calculator = new BatchCalculator(batchSize, totalCalculations);

        Stopwatch sequentialStopwatch = Stopwatch.StartNew();
        calculator.ProcessSequentially();
        sequentialStopwatch.Stop();
        long sequentialTime = sequentialStopwatch.ElapsedMilliseconds;

        Stopwatch parallelStopwatch = Stopwatch.StartNew();
        calculator.ProcessInParallel();
        parallelStopwatch.Stop();
        long parallelTime = parallelStopwatch.ElapsedMilliseconds;

        Console.WriteLine($"Tiempo secuencial: {sequentialTime} ms");
        Console.WriteLine($"Tiempo en paralelo: {parallelTime} ms");
        Console.WriteLine($"Speedup: {((double)sequentialTime / parallelTime):F2}");

        Console.ReadLine();
    }
}
