using BenchmarkDotNet.Attributes;
using BenchmarkMockNet.PCLMock;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;
using JustMock = Telerik.JustMock.Mock;

namespace BenchmarkMockNet.Benchmarks;

public class Callback : MockingBenchmark<bool>
{
	[Benchmark(Baseline = true)]
	public override bool Stub()
	{
		var stub = new ThingStub();
		stub.DoSomething();
		return stub.Called;
	}

	[Benchmark]
	public override bool FakeItEasy()
	{
		var called = false;
		var fake = A.Fake<IThing>();
		A.CallTo(() => fake.DoSomething()).Invokes(() => called = true);
		fake.DoSomething();
		return called;
	}

	[Benchmark]
	public override bool JustMockLite()
	{
		JustMock.Reset();
		var called = false;
		var thing = JustMock.Create<IThing>();
		JustMock.Arrange(() => thing.DoSomething()).DoInstead(() => called = true);
		thing.DoSomething();
		return called;
	}

	[Benchmark]
	public override bool Moq()
	{
		var called = false;
		var mockSetup = new Mock<IThing>();
		var mock = mockSetup.Object;
		mockSetup.Setup(m => m.DoSomething()).Callback(() => called = true);
		mock.DoSomething();
		return called;
	}

	[Benchmark]
	public override bool NSubstitute()
	{
		var called = false;
		var sub = Substitute.For<IThing>();
		sub.When(s => s.DoSomething()).Do(c => called = true);
		sub.DoSomething();
		return called;
	}

	[Benchmark]
	public override bool PCLMock()
	{
		var called = false;
		var mock = new ThingMock();
		mock.When(x => x.DoSomething()).Do(() => called = true);
		mock.DoSomething();
		return called;
	}

	[Benchmark]
	public override bool Rocks()
	{
		var called = false;
		var rock = Rock.Create<IThing>();
		rock.Methods().DoSomething().Callback(() => called = true);
		var chunk = rock.Instance();
		chunk.DoSomething();
		return called;
	}
}
