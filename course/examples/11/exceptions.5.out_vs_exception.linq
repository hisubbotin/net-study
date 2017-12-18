<Query Kind="Program" />

private static int TestParseWithCatch(string s)
{
    try
    {
        return int.Parse(s);
    }
    catch(FormatException e)
    {
        return 0;
    }
}

private static int TestParseWithOut(string s)
{
    if (! int.TryParse(s, out int i))
    {
        i = 0;
    }
    
    return i;
}

static void Main(string[] args)
{
    int count = 10000;
    double t = Benchmark(count, () => {int i = TestParseWithCatch("f"); });
	double t2 = Benchmark(count, () => {int i = TestParseWithOut("f"); });
    
	Console.WriteLine(t);                   // 0,01185658
    Console.WriteLine(t2.ToString("F8"));   // 0,00004262
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