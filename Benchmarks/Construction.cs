using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet.Benchmarks
{
    public class Construction : MockingBenchmark<IThingy>
    {
        [Benchmark(Baseline = true)]
        public override IThingy Stub()
        {
            return new ThingStub();
        }

        [Benchmark]
        public override IThingy FakeItEasy()
        {
            return A.Fake<IThingy>();
        }

        [Benchmark]
        public override IThingy Moq()
        {
            return new Mock<IThingy>().Object;
        }

        [Benchmark]
        public override IThingy NSubstitute()
        {
            return Substitute.For<IThingy>();
        }

        [Benchmark]
        public override IThingy Rocks()
        {
            return Rock.Make<IThingy>();
        }
    }
}