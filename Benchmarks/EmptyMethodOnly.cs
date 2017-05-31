using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet.Benchmarks
{
    public class EmptyMethodOnly : IMockingBenchmark
    {
        private readonly IThingy stub;
        private readonly IThingy fake;
        private readonly IThingy mock;
        private readonly IThingy pclMock;
        private readonly IThingy sub;
        private readonly IThingy chunk;

        public EmptyMethodOnly()
        {
            stub = new ThingStub();
            fake = A.Fake<IThingy>();
            mock = new Mock<IThingy>().Object;
            pclMock = new ThingyMock();
            sub = Substitute.For<IThingy>();
            chunk = Rock.Make<IThingy>();
        }

        [Benchmark(Baseline = true)]
        public void Stub() => stub.DoNothing();

        //[Benchmark]
        public void FakeItEasy() => fake.DoNothing();

        [Benchmark]
        public void Moq() => mock.DoNothing();

        [Benchmark]
        public void NSubstitute() => sub.DoNothing();

        [Benchmark]
        public void PCLMock() => pclMock.DoNothing();

        [Benchmark]
        public void Rocks() => chunk.DoNothing();
    }
}