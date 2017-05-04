using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;

namespace BenchmarkMockNet.Benchmarks
{
    public class Callback : IMockingBenchmark<bool>
    {
        [Benchmark(Baseline = true)]
        public bool Stub()
        {
            var stub = new ThingStub();
            stub.DoSomething();
            return stub.Called;
        }

        [Benchmark]
        public bool Moq()
        {
            var called = false;
            var mockSetup = new Mock<IThingy>();
            mockSetup.Setup(m => m.DoSomething()).Callback(() => called = true);
            mockSetup.Object.DoSomething();
            return called;
        }

        [Benchmark]
        public bool NSubstitute()
        {
            var sub = Substitute.For<IThingy>();
            sub.When(s => s.DoSomething()).Do(c => sub.Called = true);
            sub.DoSomething();
            return sub.Called;
        }

        [Benchmark]
        public bool FakeItEasy()
        {
            var fake = A.Fake<IThingy>();
            A.CallTo(() => fake.DoSomething()).Invokes(() => fake.Called = true);
            fake.DoSomething();
            return fake.Called;
        }
    }
}