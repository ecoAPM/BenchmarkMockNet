using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet.Benchmarks
{
    public class EmptyReturnOnly : MockingBenchmark<int>
    {
        private readonly IThingy stub;
        private readonly IThingy fake;
        private readonly IThingy mock;
        private readonly IThingy sub;
        private readonly IThingy chunk;
        private readonly ThingyMock pclMock;

        public EmptyReturnOnly()
        {
            stub = new ThingStub();
            fake = A.Fake<IThingy>();
            mock = new Mock<IThingy>().Object;
            sub = Substitute.For<IThingy>();
            chunk = Rock.Make<IThingy>();
            pclMock = new ThingyMock();
            pclMock.When(x => x.Zero());
        }

        [Benchmark(Baseline = true)]
        public override int Stub() => stub.Zero();

        [Benchmark]
        public override int FakeItEasy() => fake.Zero();

        [Benchmark]
        public override int Moq() => mock.Zero();

        [Benchmark]
        public override int NSubstitute() => sub.Zero();

        [Benchmark]
        public override int Rocks() => chunk.Zero();

        [Benchmark]
        public override int PCLMock() => pclMock.Zero();
    }
}