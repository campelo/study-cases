using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using FakeItEasy;
using Moq;
using Shouldly;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace BenchmarkCases;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class AssertTest
{

    [Benchmark]
    public async Task UsingAssert()
    {
        Person p1 = new Person { Name = "Name", Email = "Email", Age = 30 };
        Person p2 = new Person { Name = "Name", Email = "Email", Age = 30 };
        
        Assert.Equivalent(p1, p2);
    }

    [Benchmark]
    public async Task UsingShouldly()
    {
        Person p1 = new Person { Name = "Name", Email = "Email", Age = 30 };
        Person p2 = new Person { Name = "Name", Email = "Email", Age = 30 };

        p1.ShouldBeEquivalentTo(p2);
    }

    [Benchmark]
    public async Task UsingFluentAssertions()
    {
        Person p1 = new Person { Name = "Name", Email = "Email", Age = 30 };
        Person p2 = new Person { Name = "Name", Email = "Email", Age = 30 };

        p1.Should().BeEquivalentTo(p2);
    }
}
