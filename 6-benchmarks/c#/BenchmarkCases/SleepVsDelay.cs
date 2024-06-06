using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class SleepVsDelay
{
    [Benchmark]
    public async Task TaskDelay()
    {
        var task1 = new TaskDelay().Call(200);
        var task2 = new TaskDelay().Call(100);
        var task3 = new TaskDelay().Call(100);
        var task4 = new TaskDelay().Call(100);

        List<Task> tasks =
        [
            task1,
            task2,
            task3,
            task4
        ];

        await Task.WhenAll(tasks);
    }

    [Benchmark]
    public async Task ThreadSleep()
    {
        var task1 = new ThreadSleep().Call(200);
        var task2 = new ThreadSleep().Call(100);
        var task3 = new ThreadSleep().Call(100);
        var task4 = new ThreadSleep().Call(100);

        List<Task> tasks =
        [
            task1,
            task2,
            task3,
            task4
        ];

        await Task.WhenAll(tasks);
    }
}

internal class ThreadSleep
{
    public async Task Call(int milliseconds)
    {
        Thread.Sleep(milliseconds);
        await Task.CompletedTask;
    }
}

internal class TaskDelay
{
    public async Task Call(int milliseconds)
    {
        await Task.Delay(milliseconds);
    }
}
