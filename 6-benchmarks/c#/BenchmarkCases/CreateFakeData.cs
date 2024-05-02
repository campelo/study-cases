using AutoFixture;
using AutoFixture.AutoFakeItEasy;
using AutoFixture.AutoMoq;
using AutoFixture.AutoNSubstitute;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using AutoBogus;
using Hl7.Fhir.Model;
using AutoBogus.FakeItEasy;
using AutoBogus.Moq;
using Bogus;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class CreateFakeData
{
    private readonly IFixture _nSubstituteFixture;
    private readonly IFixture _moqFixture;
    private readonly IFixture _fakeItEasyFixture;
    private readonly IAutoFaker _nSubstituteAutoFaker;
    private readonly IAutoFaker _moqAutoFaker;
    private readonly IAutoFaker _fakeItEasyAutoFaker;
    private readonly string _id = "123";

    public CreateFakeData()
    {
        _nSubstituteFixture = new Fixture()
            .Customize(new AutoNSubstituteCustomization());
        _nSubstituteFixture.Behaviors.Add(new OmitOnRecursionBehavior());
        // _nSubstituteFixture.OmitAutoProperties = true;

        _moqFixture = new Fixture()
            .Customize(new AutoMoqCustomization());
        _moqFixture.Behaviors.Add(new OmitOnRecursionBehavior());
        // _moqFixture.OmitAutoProperties = true;

        _fakeItEasyFixture = new Fixture()
            .Customize(new AutoFakeItEasyCustomization());
        _fakeItEasyFixture.Behaviors.Add(new OmitOnRecursionBehavior());
        // _fakeItEasyFixture.OmitAutoProperties = true;

        _nSubstituteAutoFaker = AutoFaker.Create(builder =>
        {
            builder.WithBinder<FakeItEasyBinder>();
        });

        _moqAutoFaker = AutoFaker.Create(builder =>
        {
            builder.WithBinder<MoqBinder>();
        });

        _fakeItEasyAutoFaker = AutoFaker.Create(builder =>
        {
            builder.WithBinder<FakeItEasyBinder>();
        });
    }

    [Benchmark]
    public Practitioner RegularCreate()
    {
        Practitioner a = new() { Id = _id };
        return a;
    }

    [Benchmark]
    public Practitioner NSubstituteFixtureBuild()
    {
        Practitioner a = _nSubstituteFixture
            .Build<Practitioner>()
            .With(x => x.Id, _id)
            .Create();
        return a;
    }

    [Benchmark]
    public Practitioner NSubstituteFixtureCreate()
    {
        Practitioner a = _nSubstituteFixture
            .Create<Practitioner>();
        a.Id = _id;
        return a;
    }

    [Benchmark]
    public Practitioner MoqFixtureBuild()
    {
        Practitioner a = _moqFixture
            .Build<Practitioner>()
            .With(x => x.Id, _id)
            .Create();
        return a;
    }

    [Benchmark]
    public Practitioner MoqFixtureCreate()
    {
        Practitioner a = _moqFixture
            .Create<Practitioner>();
        a.Id = _id;
        return a;
    }

    [Benchmark]
    public Practitioner FakeItEasyFixtureBuild()
    {
        Practitioner a = _fakeItEasyFixture
            .Build<Practitioner>()
            .With(x => x.Id, _id)
            .Create();
        return a;
    }

    [Benchmark]
    public Practitioner NSubstituteFixtureBuildWithOmit()
    {
        Practitioner a = _nSubstituteFixture
            .Build<Practitioner>()
            .OmitAutoProperties()
            .With(x => x.Id, _id)
            .Create();
        return a;
    }

    [Benchmark]
    public Practitioner MoqFixtureBuildWithOmit()
    {
        Practitioner a = _moqFixture
            .Build<Practitioner>()
            .OmitAutoProperties()
            .With(x => x.Id, _id)
            .Create();
        return a;
    }

    [Benchmark]
    public Practitioner FakeItEasyFixtureBuildWithOmit()
    {
        Practitioner a = _fakeItEasyFixture
            .Build<Practitioner>()
            .OmitAutoProperties()
            .With(x => x.Id, _id)
            .Create();
        return a;
    }

    [Benchmark]
    public Practitioner FakeItEasyFixtureCreateWithOmit()
    {
        Practitioner a = _fakeItEasyFixture
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

    // [Benchmark]
    // public Practitioner NSubstituteAutoBogusGenerate()
    // {
    //     Practitioner a = _nSubstituteAutoFaker
    //         .Generate<Practitioner>();
    //     a.Id = _id;
    //     return a;
    // }

    // [Benchmark]
    // public Practitioner MoqAutoBogusGenerate()
    // {
    //     Practitioner a = _moqAutoFaker
    //         .Generate<Practitioner>();
    //     a.Id = _id;
    //     return a;
    // }

    // [Benchmark]
    // public Practitioner FakeItEasyAutoBogusGenerate()
    // {
    //     Practitioner a = _fakeItEasyAutoFaker
    //         .Generate<Practitioner>();
    //     a.Id = _id;
    //     return a;
    // }
}