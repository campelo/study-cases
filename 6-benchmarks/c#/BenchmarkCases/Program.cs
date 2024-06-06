using BenchmarkDotNet.Running;

public class Program
{
    public static void Main(string[] args)
    {
        //_ = BenchmarkRunner.Run<MapAssemblies>();
        //_ = BenchmarkRunner.Run<CreateFakeData>();
        //_ = BenchmarkRunner.Run<CreateString>();
        //_ = BenchmarkRunner.Run<MockTest>();
        _ = BenchmarkRunner.Run<SleepVsDelay>();

        //BenchmarkRunner.Run<AssertTest>(
        //    DefaultConfig.Instance
        //        .WithOptions(ConfigOptions.DisableOptimizationsValidator));

        // MockTest m = new MockTest();
        // m.UsingMoq();
    }
}