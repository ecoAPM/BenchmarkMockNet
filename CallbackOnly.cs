using System;
using BenchmarkDotNet.Attributes;
using Moq;
using NSubstitute;

namespace BenchmarkMockNet
{
    public class CallbackOnly : IMockingBenchmark
    {
        private readonly IThingy stub;
        private readonly Mock<IThingy> mock;
        private readonly IThingy sub;

        public CallbackOnly()
        {
            mock = new Mock<IThingy>();
            mock.Setup(m => m.Do()).Callback(() => mock.Object.Called = true);

            sub = Substitute.For<IThingy>();
            sub.When(s => s.Do()).Do(c => sub.Called = true);

            stub = new ThingStub();
        }

        [Benchmark(Baseline = true)]
        public void Stub()
        {
            stub.Do();
        }

        [Benchmark]
        public void Moq()
        {
            mock.Object.Do();
        }

        [Benchmark]
        public void NSubstitute()
        {
            sub.Do();
        }

        public void FakeItEasy()
        {
            throw new NotImplementedException("Never completes, probably a memory leak");
        }
    }
}