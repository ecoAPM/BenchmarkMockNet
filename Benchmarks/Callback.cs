using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

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
        public bool FakeItEasy()
        {
            var called = false;
            var fake = A.Fake<IThingy>();
            A.CallTo(() => fake.DoSomething()).Invokes(() => called = true);
            fake.DoSomething();
            return called;
        }

        [Benchmark]
        public bool Moq()
        {
            var called = false;
            var mockSetup = new Mock<IThingy>();
            var mock = mockSetup.Object;
            mockSetup.Setup(m => m.DoSomething()).Callback(() => called = true);
            mock.DoSomething();
            return called;
        }

        [Benchmark]
        public bool NSubstitute()
        {
            var called = false;
            var sub = Substitute.For<IThingy>();
            sub.When(s => s.DoSomething()).Do(c => called = true);
            sub.DoSomething();
            return called;
        }

        [Benchmark]
        public bool Rocks()
        {
            var called = false;
            var rock = Rock.Create<IThingy>();
            rock.Handle(r => r.DoSomething(), () => called = true);
            var chunk = rock.Make();
            chunk.DoSomething();
            return called;
        }
    }
}