using System;
using BenchmarkDotNet.Attributes;
using Moq;
using NSubstitute;

namespace BenchmarkMockNet
{
    public class ReturnOnly : IMockingBenchmark<int>
    {
        private readonly IThingy stub;
        private readonly Mock<IThingy> mock;
        private readonly IThingy sub;

        public ReturnOnly()
        {
            mock = new Mock<IThingy>();
            mock.Setup(m => m.One()).Returns(1);

            sub = Substitute.For<IThingy>();
            sub.One().Returns(1);

            stub = new ThingStub();
        }

        [Benchmark(Baseline = true)]
        public int Stub()
        {
            return stub.One();
        }

        [Benchmark]
        public int Moq()
        {
            return mock.Object.One();
        }

        [Benchmark]
        public int NSubstitute()
        {
            return sub.One();
        }

        public int FakeItEasy()
        {
            throw new NotImplementedException("Never completes, probably a memory leak");
        }
    }
}