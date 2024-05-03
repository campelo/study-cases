using BenchmarkDotNet.Running;

public class Program
{
    public static void Main(string[] args)
    {
        //_ = BenchmarkRunner.Run<MapAssemblies>();
        //_ = BenchmarkRunner.Run<CreateFakeData>();
        _ = BenchmarkRunner.Run<CreateString>();
    }
}