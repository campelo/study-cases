using AutoFixture;
using AutoFixture.AutoNSubstitute;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Bogus;
using Hl7.Fhir.Model;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class CreateFakeData
{
    private readonly IFixture _fixture;
    private readonly string _id = "123";

    public CreateFakeData()
    {
        _fixture = new Fixture()
            .Customize(new AutoNSubstituteCustomization());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public Practitioner RegularCreate()
    {
        Practitioner a = new() { Id = _id };
        return a;
    }

    [Benchmark]
    public Practitioner FixtureBuild()
    {
        Practitioner a = _fixture
            .Build<Practitioner>()
            .With(x => x.Id, _id)
            .Create();
        return a;
    }

    [Benchmark]
    public Practitioner FixtureCreate()
    {
        Practitioner a = _fixture
            .Create<Practitioner>();
        a.Id = _id;
        return a;
    }

    [Benchmark]
    public Practitioner BogusGenerate()
    {
        Practitioner a = new Faker<Practitioner>().Generate();
        a.Id = _id;

        return a;
    }

    [Benchmark]
    public Practitioner BogusRuleFor()
    {
        var faker = new Faker<Practitioner>()
            .RuleFor(x => x.Id, _id);

        Practitioner a = faker.Generate();
        return a;
    }
}