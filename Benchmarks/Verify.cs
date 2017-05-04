using System;
using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;

namespace BenchmarkMockNet.Benchmarks
{
    public class Verify : IMockingBenchmark
    {
        [Benchmark(Baseline = true)]
        public void Stub()
        {
            var stub = new ThingStub();
            stub.DoSomething();
            if(!stub.Called) throw new Exception();
        }

        [Benchmark]
        public void Moq()
        {
            var mock = new Mock<IThingy>();
            mock.Object.DoSomething();
            mock.Verify(m => m.DoSomething(), Times.AtLeastOnce);
        }

        [Benchmark]
        public void NSubstitute()
        {
            var sub = Substitute.For<IThingy>();
            sub.DoSomething();
            sub.Received().DoSomething();
        }

        [Benchmark]
        public void FakeItEasy()
        {
            var fake = A.Fake<IThingy>();
            fake.DoSomething();
            A.CallTo(() => fake.DoSomething()).MustHaveHappened();
        }
    }
}