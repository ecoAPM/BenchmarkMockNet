using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet.Benchmarks
{
    public class EmptyMethod : IMockingBenchmark
    {
        [Benchmark(Baseline = true)]
        public void Stub()
        {
            var stub = new ThingStub();
            stub.DoNothing();
        }

        [Benchmark]
        public void FakeItEasy()
        {
            var fake = A.Fake<IThingy>();
            fake.DoNothing();
        }

        [Benchmark]
        public void Moq()
        {
            var mock = new Mock<IThingy>();
            mock.Object.DoNothing();
        }

        [Benchmark]
        public void NSubstitute()
        {
            var sub = Substitute.For<IThingy>();
            sub.DoNothing();
        }

        [Benchmark]
        public void Rocks()
        {
            var chunk = Rock.Make<IThingy>();
            chunk.DoNothing();
        }
    }
}