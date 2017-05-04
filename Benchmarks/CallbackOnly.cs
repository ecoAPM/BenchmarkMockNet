using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet.Benchmarks
{
    public class CallbackOnly : IMockingBenchmark<bool>
    {
        private readonly IThingy stub;
        private readonly IThingy mock;
        private readonly IThingy sub;
        private readonly IThingy fake;
        private readonly IThingy chunk;
        private bool mockCalled;
        private bool rockCalled;

        public CallbackOnly()
        {
            stub = new ThingStub();

            mockCalled = false;
            var mockSetup = new Mock<IThingy>();
            mockSetup.Setup(m => m.DoSomething()).Callback(() => mockCalled = true);
            mock = mockSetup.Object;

            sub = Substitute.For<IThingy>();
            sub.When(s => s.DoSomething()).Do(c => sub.Called = true);

            var fakey = new Fake<IThingy>();
            fakey.CallsTo(f => f.DoSomething()).Invokes(f => fake.Called = true);
            fake = fakey.FakedObject;

            var rock = Rock.Create<IThingy>();
            rock.Handle(r => r.DoSomething(), () => rockCalled = true);
            chunk = rock.Make();
        }

        [Benchmark(Baseline = true)]
        public bool Stub()
        {
            stub.DoSomething();
            return stub.Called;
        }

        [Benchmark]
        public bool Moq()
        {
            mock.DoSomething();
            return mockCalled;
        }

        [Benchmark]
        public bool NSubstitute()
        {
            sub.DoSomething();
            return sub.Called;
        }

        //[Benchmark]
        public bool FakeItEasy()
        {
            fake.DoSomething();
            return fake.Called;
        }

        [Benchmark]
        public bool Rocks()
        {
            chunk.DoSomething();
            return rockCalled;
        }
    }
}