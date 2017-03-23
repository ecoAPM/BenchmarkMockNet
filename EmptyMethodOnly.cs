using System;
using BenchmarkDotNet.Attributes;
using Moq;
using NSubstitute;

namespace BenchmarkMockNet
{
    public class EmptyMethodOnly : IMockingBenchmark
    {
        private readonly IThingy stub;
        private readonly Mock<IThingy> mock;
        private readonly IThingy sub;

        public EmptyMethodOnly()
        {
            stub = new ThingStub();
            mock = new Mock<IThingy>();
            sub = Substitute.For<IThingy>();
        }

        [Benchmark(Baseline = true)]
        public void Stub() => stub.DoNothing();

        [Benchmark]
        public void Moq() => mock.Object.DoNothing();

        [Benchmark]
        public void NSubstitute() => sub.DoNothing();

        public void FakeItEasy() => throw new NotImplementedException("Never completes, probably a memory leak");
    }
}