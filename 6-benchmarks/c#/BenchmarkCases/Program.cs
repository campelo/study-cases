using BenchmarkDotNet.Running;

public class Program
{
    public static void Main(string[] args)
    {
        //var summary = BenchmarkRunner.Run<MapAssemblies>();
        var summary = BenchmarkRunner.Run<CreateFakeData>();
    }
}
