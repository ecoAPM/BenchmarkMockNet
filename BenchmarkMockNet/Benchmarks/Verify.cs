using System.ComponentModel;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkMockNet.PCLMock;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;
using JustMock = Telerik.JustMock.Mock;
using Times = Moq.Times;

namespace BenchmarkMockNet.Benchmarks;

[Description("Verifies that the method was called")]
public class Verify : MockingBenchmark
{
	[Benchmark(Baseline = true)]
	public override void Stub()
	{
		var stub = new ThingStub();
		stub.DoSomething();
		if (!stub.Called)
		{
			throw new TargetException();
		}
	}

	[Benchmark]
	public override void FakeItEasy()
	{
		var fake = A.Fake<IThing>();
		fake.DoSomething();
		A.CallTo(() => fake.DoSomething()).MustHaveHappened();
	}

	[Benchmark]
	public override void JustMockLite()
	{
		JustMock.Reset();
		var thing = JustMock.Create<IThing>();
		JustMock.Arrange(() => thing.DoSomething());
		thing.DoSomething();
		JustMock.Assert(thing);
	}

	[Benchmark]
	public override void Moq()
	{
		var mock = new Mock<IThing>();
		mock.Object.DoSomething();
		mock.Verify(m => m.DoSomething(), Times.AtLeastOnce);
	}

	[Benchmark]
	public override void NSubstitute()
	{
		var sub = Substitute.For<IThing>();
		sub.DoSomething();
		sub.Received().DoSomething();
	}

	[Benchmark]
	public override void PCLMock()
	{
		var mock = new ThingMock();
		mock.When(x => x.DoSomething());
		mock.DoSomething();
		mock.Verify(x => x.DoSomething()).WasCalledExactlyOnce();
	}

	[Benchmark]
	public override void Rocks()
	{
		var rock = Rock.Create<IThing>();
		rock.Methods().DoSomething();
		rock.Instance().DoSomething();
		rock.Verify();
	}
}