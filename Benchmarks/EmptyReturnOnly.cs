using BenchmarkDotNet.Attributes;
using BenchmarkMockNet.PCLMock;
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
        private readonly ThingyMock pclMock;
        private readonly IThingy rock;

        public EmptyReturnOnly()
        {
            stub = new ThingStub();
            fake = A.Fake<IThingy>();
            mock = new Mock<IThingy>().Object;
            sub = Substitute.For<IThingy>();
            pclMock = new ThingyMock();
            pclMock.When(x => x.Zero());
            rock = Rock.Make<IThingy>().Instance();
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
        public override int PCLMock() => pclMock.Zero();

        [Benchmark]
        public override int Rocks() => rock.Zero();
    }
}