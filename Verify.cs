using System;
using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;

namespace BenchmarkMockNet
{
    public class Verify : IMockingBenchmark
    {
        [Benchmark(Baseline = true)]
        public void Stub()
        {
            var stub = new ThingStub();
            stub.Do();
            if(!stub.Called) throw new Exception();
        }

        [Benchmark]
        public void Moq()
        {
            var mock = new Mock<IThingy>();
            mock.Object.Do();
            mock.Verify(m => m.Do(), Times.AtLeastOnce);
        }

        [Benchmark]
        public void NSubstitute()
        {
            var sub = Substitute.For<IThingy>();
            sub.Do();
            sub.Received().Do();
        }

        [Benchmark]
        public void FakeItEasy()
        {
            var fake = A.Fake<IThingy>();
            fake.Do();
            A.CallTo(() => fake.Do()).MustHaveHappened();
        }
    }
}