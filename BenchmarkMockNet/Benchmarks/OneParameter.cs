using System.ComponentModel;
using BenchmarkDotNet.Attributes;
using BenchmarkMockNet.PCLMock;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;
using JustMock = Telerik.JustMock.Mock;

namespace BenchmarkMockNet.Benchmarks;

[Description("A mock object is created, with no method setup, and a method with no return value requiring an `int` parameter is called")]
public class OneParameter : MockingBenchmark
{
	[Benchmark(Baseline = true)]
	public override void Stub()
	{
		var stub = new ThingStub();
		stub.OneParameter(0);
	}

	[Benchmark]
	public override void FakeItEasy()
	{
		var fake = A.Fake<IThing>();
		fake.OneParameter(0);
	}

	[Benchmark]
	public override void JustMockLite()
	{
		JustMock.Reset();
		var thing = JustMock.Create<IThing>();
		thing.OneParameter(0);
	}

	[Benchmark]
	public override void Moq()
	{
		var mock = new Mock<IThing>();
		mock.Object.OneParameter(0);
	}

	[Benchmark]
	public override void NSubstitute()
	{
		var sub = Substitute.For<IThing>();
		sub.OneParameter(0);
	}

	[Benchmark]
	public override void PCLMock()
	{
		var mock = new ThingMock();
		mock.When(x => x.OneParameter(0));
		mock.OneParameter(0);
	}

	[Benchmark]
	public override void Rocks()
	{
		var expectations = new IThingCreateExpectations();
		expectations.Methods.OneParameter(0);
		expectations.Instance().OneParameter(0);
	}
}