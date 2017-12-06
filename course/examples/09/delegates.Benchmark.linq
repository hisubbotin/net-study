<Query Kind="Program" />

static void Main(string[] args)
{
	double t = Benchmark(50, () => {var xs = Enumerable.Range(0, 1000000).ToList(); });
	
	Console.WriteLine(t);
}

public static double Benchmark(int times, Action func)
{
    var watch = new System.Diagnostics.Stopwatch();
    double totalTime = 0.0;

    for (int i = 0; i < times; i++)
    {
        watch.Start();
        func();
        watch.Stop();

        totalTime += watch.ElapsedTicks;
        watch.Reset();
    }

    return totalTime / (10000 * times);
}