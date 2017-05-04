using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;

namespace BenchmarkMockNet.Benchmarks
{
    public class EmptyReturn : IMockingBenchmark<int>
    {
        [Benchmark(Baseline = true)]
        public int Stub()
        {
            var stub = new ThingStub();
            return stub.Zero();
        }

        [Benchmark]
        public int Moq()
        {
            var mock = new Mock<IThingy>();
            return mock.Object.Zero();
        }

        [Benchmark]
        public int NSubstitute()
        {
            var sub = Substitute.For<IThingy>();
            return sub.Zero();
        }

        [Benchmark]
        public int FakeItEasy()
        {
            var fake = A.Fake<IThingy>();
            return fake.Zero();
        }
    }
}