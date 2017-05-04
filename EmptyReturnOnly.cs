using System;
using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;

namespace BenchmarkMockNet
{
    public class EmptyReturnOnly : IMockingBenchmark<int>
    {
        private readonly IThingy stub;
        private readonly IThingy mock;
        private readonly IThingy sub;
        private readonly IThingy fake;

        public EmptyReturnOnly()
        {
            stub = new ThingStub();
            mock = new Mock<IThingy>().Object;
            sub = Substitute.For<IThingy>();
            fake = new Fake<IThingy>().FakedObject;
        }

        [Benchmark(Baseline = true)]
        public int Stub() => stub.Zero();

        [Benchmark]
        public int Moq() => mock.Zero();

        [Benchmark]
        public int NSubstitute() => sub.Zero();

        //[Benchmark]
        public int FakeItEasy() => fake.Zero();
    }
}