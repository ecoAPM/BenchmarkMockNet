using System;
using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;

namespace BenchmarkMockNet
{
    public class VerifyOnly : IMockingBenchmark
    {
        private readonly IThingy stub;
        private readonly Mock<IThingy> mock;
        private readonly IThingy sub;
        private readonly IThingy fake;

        public VerifyOnly()
        {
            stub = new ThingStub();
            stub.Do();

            mock = new Mock<IThingy>();
            mock.Object.Do();

            sub = Substitute.For<IThingy>();
            sub.Do();

            fake = A.Fake<IThingy>();
            fake.Do();
        }

        [Benchmark(Baseline = true)]
        public void Stub()
        {
            if (!stub.Called) throw new Exception();
        }

        [Benchmark]
        public void Moq()
        {
            mock.Verify(m => m.Do(), Times.AtLeastOnce);
        }

        [Benchmark]
        public void NSubstitute()
        {
            sub.Received().Do();
        }

        [Benchmark]
        public void FakeItEasy()
        {
            A.CallTo(() => fake.Do()).MustHaveHappened();
        }
    }
}