using BenchmarkDotNet.Attributes;
using BenchmarkMockNet.PCLMock;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet.Benchmarks
{
	public class Construction : MockingBenchmark<IThing>
	{
		[Benchmark(Baseline = true)]
		public override IThing Stub() => new ThingStub();

		[Benchmark]
		public override IThing FakeItEasy() => A.Fake<IThing>();

		[Benchmark]
		public override IThing Moq() => new Mock<IThing>().Object;

		[Benchmark]
		public override IThing NSubstitute() => Substitute.For<IThing>();

		[Benchmark]
		public override IThing PCLMock() => new ThingMock();

		[Benchmark]
		public override IThing Rocks() => Rock.Make<IThing>().Instance();
	}
}