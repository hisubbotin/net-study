<Query Kind="Program" />

static void Main(string[] args)
{
    Counter c = new Counter(new Random().Next(10));
    c.ThresholdReached += c_ThresholdReached;
    while (true)
    {
        Console.WriteLine("adding one");
        c.Add(1);
    }
}

static void c_ThresholdReached(object sender, ThresholdReachedEventArgs e)
{
    Console.WriteLine($"{e.Threshold} was reached at {e.TimeReached}.");
    Environment.Exit(0);
}

public class ThresholdReachedEventArgs : EventArgs
{
    public int Threshold { get; set; }
    public DateTime TimeReached { get; set; }
}

class Counter
{
    private int threshold;
    private int total;

    public Counter(int passedThreshold)
    {
        threshold = passedThreshold;
    }

    public void Add(int x)
    {
        total += x;
        if (total < threshold)
            return;

        ThresholdReachedEventArgs args = new ThresholdReachedEventArgs
        {
            Threshold = threshold,
            TimeReached = DateTime.Now
        };
        OnThresholdReached(args);
    }

    protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
    {
        ThresholdReached?.Invoke(this, e);
    }

    public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
}