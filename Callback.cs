using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet
{
    public class Callback : IMockingBenchmark
    {
        [Benchmark(Baseline = true)]
        public void Stub()
        {
            var stub = new ThingStub();
            stub.DoSomething();
        }

        [Benchmark]
        public void Moq()
        {
            var mock = new Mock<IThingy>();
            mock.Setup(m => m.DoSomething()).Callback(() => mock.Object.Called = true);
            mock.Object.DoSomething();
        }

        [Benchmark]
        public void NSubstitute()
        {
            var sub = Substitute.For<IThingy>();
            sub.When(s => s.DoSomething()).Do(c => sub.Called = true);
            sub.DoSomething();
        }

        [Benchmark]
        public void FakeItEasy()
        {
            var fake = A.Fake<IThingy>();
            A.CallTo(() => fake.DoSomething()).Invokes(() => fake.Called = true);
            fake.DoSomething();
        }

        [Benchmark]
        public void Rocks()
        {
            IThingy chunk = null;
            var rock = Rock.Create<IThingy>();
            rock.Handle(r => r.DoSomething(), () => chunk.Called = true);
            rock.Handle(nameof(IThingy.Called));
            chunk = rock.Make();
            chunk.DoSomething();
        }
    }
}