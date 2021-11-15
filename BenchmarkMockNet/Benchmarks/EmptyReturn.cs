using BenchmarkDotNet.Attributes;
using BenchmarkMockNet.PCLMock;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;
using JustMock = Telerik.JustMock.Mock;

namespace BenchmarkMockNet.Benchmarks;

public class EmptyReturn : MockingBenchmark<int>
{
	[Benchmark(Baseline = true)]
	public override int Stub()
	{
		var stub = new ThingStub();
		return stub.Zero();
	}

	[Benchmark]
	public override int FakeItEasy()
	{
		var fake = A.Fake<IThing>();
		return fake.Zero();
	}

	[Benchmark]
	public override int JustMockLite()
	{
		JustMock.Reset();
		var thing = JustMock.Create<IThing>();
		return thing.Zero();
	}

	[Benchmark]
	public override int Moq()
	{
		var mock = new Mock<IThing>();
		return mock.Object.Zero();
	}

	[Benchmark]
	public override int NSubstitute()
	{
		var sub = Substitute.For<IThing>();
		return sub.Zero();
	}

	[Benchmark]
	public override int PCLMock()
	{
		var mock = new ThingMock();
		mock.When(x => x.Zero());
		return mock.Zero();
	}

	[Benchmark]
	public override int Rocks()
	{
		var chunk = Rock.Create<IThing>();
		chunk.Methods().Zero().Returns(0);
		var rock = chunk.Instance();
		return rock.Zero();
	}
}
