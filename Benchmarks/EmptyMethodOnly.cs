using BenchmarkDotNet.Attributes;
using BenchmarkMockNet.PCLMock;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet.Benchmarks
{
    public class EmptyMethodOnly : MockingBenchmark
    {
        private readonly IThingy stub;
        private readonly IThingy fake;
        private readonly IThingy mock;
        private readonly IThingy sub;
        private readonly IThingy chunk;
        private readonly ThingyMock pclMock;

        public EmptyMethodOnly()
        {
            stub = new ThingStub();
            fake = A.Fake<IThingy>();
            mock = new Mock<IThingy>().Object;
            sub = Substitute.For<IThingy>();
            chunk = Rock.Make<IThingy>().Instance();
            pclMock = new ThingyMock();
            pclMock.When(x => x.DoNothing());
        }

        [Benchmark(Baseline = true)]
        public override void Stub() => stub.DoNothing();

        [Benchmark]
        public override void FakeItEasy() => fake.DoNothing();

        [Benchmark]
        public override void Moq() => mock.DoNothing();

        [Benchmark]
        public override void NSubstitute() => sub.DoNothing();

        [Benchmark]
        public override void Rocks() => chunk.DoNothing();

        [Benchmark]
        public override void PCLMock() => pclMock.DoNothing();
    }
}