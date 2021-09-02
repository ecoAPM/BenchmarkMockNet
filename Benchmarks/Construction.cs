using BenchmarkDotNet.Attributes;
using BenchmarkMockNet.PCLMock;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet.Benchmarks
{
	public class Construction : MockingBenchmark<IThingy>
	{
		[Benchmark(Baseline = true)]
		public override IThingy Stub() => new ThingStub();

		[Benchmark]
		public override IThingy FakeItEasy() => A.Fake<IThingy>();

		[Benchmark]
		public override IThingy Moq() => new Mock<IThingy>().Object;

		[Benchmark]
		public override IThingy NSubstitute() => Substitute.For<IThingy>();

		[Benchmark]
		public override IThingy PCLMock() => new ThingyMock();

		[Benchmark]
		public override IThingy Rocks() => Rock.Make<IThingy>().Instance();
	}
}