using AutoFixture;
using AutoFixture.AutoNSubstitute;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using AutoBogus;
using Bogus;
using System.Collections;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class CreateString
{
    private static readonly string _string = "fake string";
    private readonly IFixture _fixture;
    private readonly Faker _faker;
    private readonly YieldString _yieldString;

    public CreateString()
    {
        _fixture = new Fixture()
            .Customize(new AutoNSubstituteCustomization());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        _faker = new Faker();

        _yieldString = new YieldString();
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
    public string YieldList()
    {
        string a = _yieldString.Next;
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
    public string FixtureCreateString()
    {
        string a = _fixture.Create<string>();
        return a;
    }

    [Benchmark]
    public string FixtureCreateInt()
    {
        string a = _fixture.Create<int>().ToString();
        return a;
    }

    [Benchmark]
    public string BogusName()
    {
        string a = _faker.Name.FirstName();
        return a;
    }

    [Benchmark]
    public string BogusRandomAlphanumeric()
    {
        string a = _faker.Random.AlphaNumeric(10);
        return a;
    }

    [Benchmark]
    public string BogusIntToString()
    {
        string a = _faker.Random.Int().ToString();
        return a;
    }
}

public class YieldString : IEnumerable<string>
{
    private static readonly List<string> _stringList = new List<string>
    {
        "string 1",
        "string 2",
        "string 3",
        "string 4",
        "string 5",
        "string 6",
        "string 7",
        "string 8",
        "string 9",
        "string 10",
    };

    private IEnumerator<string> _enumerator;

    public string Next => _enumerator.MoveNext() ? _enumerator.Current : "";

    public YieldString()
    {
        _enumerator = GetEnumerator();
    }

    public IEnumerator<string> GetEnumerator()
    {
        while (true)
        {
            foreach (string str in _stringList)
            {
                yield return str;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}