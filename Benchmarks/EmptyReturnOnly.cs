using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet.Benchmarks
{
    public class EmptyReturnOnly : IMockingBenchmark<int>
    {
        private readonly IThingy stub;
        private readonly IThingy fake;
        private readonly IThingy mock;
        private readonly IThingy sub;
        private readonly IThingy chunk;

        public EmptyReturnOnly()
        {
            stub = new ThingStub();
            fake = A.Fake<IThingy>();
            mock = new Mock<IThingy>().Object;
            sub = Substitute.For<IThingy>();
            chunk = Rock.Make<IThingy>();
        }

        [Benchmark(Baseline = true)]
        public int Stub() => stub.Zero();

        //[Benchmark]
        public int FakeItEasy() => fake.Zero();

        [Benchmark]
        public int Moq() => mock.Zero();

        [Benchmark]
        public int NSubstitute() => sub.Zero();

        [Benchmark]
        public int Rocks() => chunk.Zero();
    }
}