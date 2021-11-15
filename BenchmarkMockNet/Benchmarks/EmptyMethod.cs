using BenchmarkDotNet.Attributes;
using BenchmarkMockNet.PCLMock;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;
using JustMock = Telerik.JustMock.Mock;

namespace BenchmarkMockNet.Benchmarks;

public class EmptyMethod : MockingBenchmark
{
	[Benchmark(Baseline = true)]
	public override void Stub()
	{
		var stub = new ThingStub();
		stub.DoNothing();
	}

	[Benchmark]
	public override void FakeItEasy()
	{
		var fake = A.Fake<IThing>();
		fake.DoNothing();
	}

	[Benchmark]
	public override void JustMockLite()
	{
		JustMock.Reset();
		var thing = JustMock.Create<IThing>();
		thing.DoNothing();
	}

	[Benchmark]
	public override void Moq()
	{
		var mock = new Mock<IThing>();
		mock.Object.DoNothing();
	}

	[Benchmark]
	public override void NSubstitute()
	{
		var sub = Substitute.For<IThing>();
		sub.DoNothing();
	}

	[Benchmark]
	public override void PCLMock()
	{
		var mock = new ThingMock();
		mock.When(x => x.DoNothing());
		mock.DoNothing();
	}

	[Benchmark]
	public override void Rocks()
	{
		var chunk = Rock.Create<IThing>();
		chunk.Methods().DoNothing();
		var rock = chunk.Instance();
		rock.DoNothing();
	}
}
