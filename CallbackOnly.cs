using System;
using BenchmarkDotNet.Attributes;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet
{
    public class CallbackOnly : IMockingBenchmark
    {
        private readonly IThingy stub;
        private readonly Mock<IThingy> mock;
        private readonly IThingy sub;
        private readonly IRock<IThingy> rock;
        private IThingy chunk;

        public CallbackOnly()
        {
            stub = new ThingStub();

            mock = new Mock<IThingy>();
            mock.Setup(m => m.DoSomething()).Callback(() => mock.Object.Called = true);

            sub = Substitute.For<IThingy>();
            sub.When(s => s.DoSomething()).Do(c => sub.Called = true);

            rock = Rock.Create<IThingy>();
            rock.Handle(r => r.DoSomething(), () => chunk.Called = true);
            rock.Handle(nameof(IThingy.Called));
        }

        [Benchmark(Baseline = true)]
        public void Stub() => stub.DoSomething();

        [Benchmark]
        public void Moq() => mock.Object.DoSomething();

        [Benchmark]
        public void NSubstitute() => sub.DoSomething();

        public void FakeItEasy() => throw new NotImplementedException("Never completes, probably a memory leak");

        [Benchmark]
        public void Rocks()
        {
            chunk = rock.Make();
            chunk.DoSomething();
        }
    }
}