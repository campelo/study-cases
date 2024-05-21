using BenchmarkCases;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Moq;

public class Program
{
    public static void Main(string[] args)
    {
        //_ = BenchmarkRunner.Run<MapAssemblies>();
        //_ = BenchmarkRunner.Run<CreateFakeData>();
        //_ = BenchmarkRunner.Run<CreateString>();
        // _ = BenchmarkRunner.Run<MockTest>();

        BenchmarkRunner.Run<AssertTest>(
            DefaultConfig.Instance
                .WithOptions(ConfigOptions.DisableOptimizationsValidator));

        // MockTest m = new MockTest();
        // m.UsingMoq();
    }
}