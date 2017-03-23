using System;
using BenchmarkDotNet.Attributes;
using Moq;
using NSubstitute;

namespace BenchmarkMockNet
{
    public class EmptyReturnOnly : IMockingBenchmark<int>
    {
        private readonly IThingy stub;
        private readonly Mock<IThingy> mock;
        private readonly IThingy sub;

        public EmptyReturnOnly()
        {
            stub = new ThingStub();
            mock = new Mock<IThingy>();
            sub = Substitute.For<IThingy>();
        }

        [Benchmark(Baseline = true)]
        public int Stub() => stub.Zero();

        [Benchmark]
        public int Moq() => mock.Object.Zero();

        [Benchmark]
        public int NSubstitute() => sub.Zero();

        public int FakeItEasy() => throw new NotImplementedException("Never completes, probably a memory leak");
    }
}