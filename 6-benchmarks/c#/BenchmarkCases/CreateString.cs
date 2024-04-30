using AutoFixture;
using AutoFixture.AutoNSubstitute;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using AutoBogus;
using Bogus;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class CreateString
{
    private readonly IFixture _fixture;

    public CreateString()
    {
        _fixture = new Fixture()
            .Customize(new AutoNSubstituteCustomization());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Benchmark]
    public string RegularCreate()
    {
        string a = "a new name string";
        return a;
    }

    [Benchmark]
    public string RegularNewGuid()
    {
        string a = Guid.NewGuid().ToString();
        return a;
    }

    [Benchmark]
    public string FixtureCreate()
    {
        string a = _fixture.Create<string>();
        return a;
    }

    [Benchmark]
    public string BogusName()
    {
        string a = new Faker().Name.Locale;
        return a;
    }
}