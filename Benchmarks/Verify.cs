using System;
using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;
using Times = Moq.Times;

namespace BenchmarkMockNet.Benchmarks
{
    public class Verify : MockingBenchmark
    {
        [Benchmark(Baseline = true)]
        public override void Stub()
        {
            var stub = new ThingStub();
            stub.DoSomething();
            if(!stub.Called) throw new Exception();
        }

        [Benchmark]
        public override void FakeItEasy()
        {
            var fake = A.Fake<IThingy>();
            fake.DoSomething();
            A.CallTo(() => fake.DoSomething()).MustHaveHappened();
        }

        [Benchmark]
        public override void Moq()
        {
            var mock = new Mock<IThingy>();
            mock.Object.DoSomething();
            mock.Verify(m => m.DoSomething(), Times.AtLeastOnce);
        }

        [Benchmark]
        public override void NSubstitute()
        {
            var sub = Substitute.For<IThingy>();
            sub.DoSomething();
            sub.Received().DoSomething();
        }

        [Benchmark]
        public override void Rocks()
        {
            var rock = Rock.Create<IThingy>();
            rock.Handle(r => r.DoSomething());
            rock.Make().DoSomething();
            rock.Verify();
        }

        [Benchmark]
        public override void PCLMock()
        {
            var mock = new ThingyMock();
            mock.When(x => x.DoSomething());
            mock.DoSomething();
            mock.Verify(x => x.DoSomething()).WasCalledExactlyOnce();
        }
    }
}