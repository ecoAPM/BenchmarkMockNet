using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;

namespace BenchmarkMockNet.Benchmarks
{
    public class Construction : IMockingBenchmark<IThingy>
    {
        [Benchmark(Baseline = true)]
        public IThingy Stub()
        {
            return new ThingStub();
        }

        [Benchmark]
        public IThingy Moq()
        {
            return new Mock<IThingy>().Object;
        }

        [Benchmark]
        public IThingy NSubstitute()
        {
            return Substitute.For<IThingy>();
        }

        [Benchmark]
        public IThingy FakeItEasy()
        {
            return A.Fake<IThingy>();
        }
    }
}