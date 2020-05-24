using BenchmarkDotNet.Attributes;
using BenchmarkMockNet.PCLMock;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet.Benchmarks
{
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
            var fake = A.Fake<IThingy>();
            return fake.Zero();
        }

        [Benchmark]
        public override int Moq()
        {
            var mock = new Mock<IThingy>();
            return mock.Object.Zero();
        }

        [Benchmark]
        public override int NSubstitute()
        {
            var sub = Substitute.For<IThingy>();
            return sub.Zero();
        }

        [Benchmark]
        public override int Rocks()
        {
            var chunk = Rock.Make<IThingy>();
            return chunk.Zero();
        }

        [Benchmark]
        public override int PCLMock()
        {
            var mock = new ThingyMock();
            mock.When(x => x.Zero());
            return mock.Zero();
        }
    }
}