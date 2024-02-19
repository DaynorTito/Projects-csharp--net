class BatchCalculator
{
    private int batchSize;
    private int totalCalculations;

    public BatchCalculator(int batchSize, int totalCalculations)
    {
        this.batchSize = batchSize;
        this.totalCalculations = totalCalculations;
    }

    public void ProcessSequentially()
    {
        for (int i = 0; i < totalCalculations; i += batchSize)
        {
            PerformBatchCalculation(i, Math.Min(batchSize, totalCalculations - i));
        }
    }

    public void ProcessInParallel()
    {
        int batches = totalCalculations / batchSize;
        Thread[] threads = new Thread[batches];

        for (int i = 0; i < batches; i++)
        {
            int start = i * batchSize;
            threads[i] = new Thread(() =>
            {
                PerformBatchCalculation(start, Math.Min(batchSize, totalCalculations - start));
            });
            threads[i].Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine("All threads finished");
    }

    private void PerformBatchCalculation(int start, int count)
    {
        for (int i = start; i < start + count; i++)
        {
            bool isPrimeNumberI = IsPrime(i);
        }
    }

    private bool IsPrime(int number)
    {
        if (number < 2) return false;
        if (number < 4) return true;
        if (number % 2 == 0) return false;
        for (int i = 3; i <= Math.Sqrt(number); i += 2)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}