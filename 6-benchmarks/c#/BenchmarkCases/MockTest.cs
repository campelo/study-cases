using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using FakeItEasy;
using Moq;
using NSubstitute;
using Xunit;

namespace BenchmarkCases;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class MockTest
{

    [Benchmark]
    public async Task UsingNSubstituteVariableFunc()
    {
        var externalService = Substitute.For<IExternalService>();
        Func<Person?> person = () => null;

        externalService
            .GetFirst()
            .Returns(x => person());

        externalService
            .Create(Arg.Any<Person>())
            .Returns(x => {
                var p = x.Arg<Person>();
                p.Id = "fake_id";
                person = () => p;
                return p.Id;
            });
        
        MyService service = new MyService(externalService);

        var result = await service.GetFirstOrCreate();

        Assert.NotNull(result);
        Assert.Equal("fake_id", result.Id);
        Assert.Equal("Name", result.Name);
        Assert.Equal("Email", result.Email);
        Assert.Equal(30, result.Age);
    }

    [Benchmark]
    public async Task UsingNSubstitute()
    {
        var externalService = Substitute.For<IExternalService>();
        Person? person = null;

        externalService
            .GetFirst()
            .Returns(x => person);

        externalService
            .Create(Arg.Any<Person>())
            .Returns(x => {
                person = x.Arg<Person>();
                person.Id = "fake_id";
                return person.Id;
            });
        
        MyService service = new MyService(externalService);

        var result = await service.GetFirstOrCreate();

        Assert.NotNull(result);
        Assert.Equal("fake_id", result.Id);
        Assert.Equal("Name", result.Name);
        Assert.Equal("Email", result.Email);
        Assert.Equal(30, result.Age);
    }

    [Benchmark]
    public async Task UsingMoq()
    {
        var externalService = new Moq.Mock<IExternalService>();
        Person? person = null;

        externalService
            .Setup(x => x.GetFirst())
            .ReturnsAsync(() => person);

        externalService
            .Setup(x => x.Create(It.IsAny<Person>()))
            .ReturnsAsync((Person p) => {
                person = p;
                person.Id = "fake_id";
                return person.Id;
            });

        MyService service = new MyService(externalService.Object);

        var result = await service.GetFirstOrCreate();

        Assert.NotNull(result);
        Assert.Equal("fake_id", result.Id);
        Assert.Equal("Name", result.Name);
        Assert.Equal("Email", result.Email);
        Assert.Equal(30, result.Age);
    }
}

public class MyService
{
    public IExternalService ExternalService { get; set; }

    public MyService(IExternalService externalService)
    {
        ExternalService = externalService;
    }

    public async Task<Person> GetFirstOrCreate()
    {
        var person = await ExternalService.GetFirst();
        if (person is null)
        {
            person = new Person { Name = "Name", Email = "Email", Age = 30 };
            _ = await ExternalService.Create(person);
        }
        person = await ExternalService.GetFirst();
        return person;
    }
}

public interface IExternalService
{
    Task<Person?> GetFirst();
    Task<string> Create(Person person);
}
