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
        private readonly ThingyMock pclMock;
        private readonly IThingy rock;

        public EmptyMethodOnly()
        {
            stub = new ThingStub();
            fake = A.Fake<IThingy>();
            mock = new Mock<IThingy>().Object;
            sub = Substitute.For<IThingy>();
            pclMock = new ThingyMock();
            pclMock.When(x => x.DoNothing());
            rock = Rock.Make<IThingy>().Instance();
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
        public override void PCLMock() => pclMock.DoNothing();

        [Benchmark]
        public override void Rocks() => rock.DoNothing();
    }
}