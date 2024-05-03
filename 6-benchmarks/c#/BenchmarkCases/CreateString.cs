using AutoFixture;
using AutoFixture.AutoNSubstitute;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using AutoBogus;
using Bogus;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class CreateString
{
    private static readonly string _string = "fake string";
    private readonly IFixture _fixture;
    private readonly Faker _faker;

    public CreateString()
    {
        _fixture = new Fixture()
            .Customize(new AutoNSubstituteCustomization());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        _faker = new Faker();
    }

    [Benchmark]
    public string StaticString()
    {
        string a = _string;
        return a;
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
    public string RandomToString()
    {
        string a = new Random().Next().ToString();
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
        string a = _faker.Name.FirstName();
        return a;
    }
}