using System;
using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;
using Times = Moq.Times;

namespace BenchmarkMockNet.Benchmarks
{
    public class VerifyOnly : MockingBenchmark
    {
        private readonly ThingStub stub;
        private readonly IThingy fake;
        private readonly Mock<IThingy> mock;
        private readonly IThingy sub;
        private readonly IRock<IThingy> rock;
        private readonly ThingyMock pclMock;

        public VerifyOnly()
        {
            stub = new ThingStub();
            stub.DoSomething();

            fake = A.Fake<IThingy>();
            fake.DoSomething();

            mock = new Mock<IThingy>();
            mock.Object.DoSomething();

            sub = Substitute.For<IThingy>();
            sub.DoSomething();

            rock = Rock.Create<IThingy>();
            rock.Handle(r => r.DoSomething());
            rock.Make().DoSomething();

            pclMock = new ThingyMock();
            pclMock.When(x => x.DoSomething());
            pclMock.DoSomething();
        }

        [Benchmark(Baseline = true)]
        public override void Stub()
        {
            if (!stub.Called) throw new Exception();
        }

        [Benchmark]
        public override void FakeItEasy() => A.CallTo(() => fake.DoSomething()).MustHaveHappened();

        [Benchmark]
        public override void Moq() => mock.Verify(m => m.DoSomething(), Times.AtLeastOnce);

        [Benchmark]
        public override void NSubstitute() => sub.Received().DoSomething();

        [Benchmark]
        public override void Rocks() => rock.Verify();

        [Benchmark]
        public override void PCLMock() => pclMock.Verify(x => x.DoSomething()).WasCalledExactlyOnce();
    }
}