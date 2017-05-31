using System;
using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet.Benchmarks
{
    public class VerifyOnly : IMockingBenchmark
    {
        private readonly ThingStub stub;
        private readonly IThingy fake;
        private readonly Mock<IThingy> mock;
        private readonly ThingyMock pclMock;
        private readonly IThingy sub;
        private readonly IRock<IThingy> rock;

        public VerifyOnly()
        {
            stub = new ThingStub();
            stub.DoSomething();

            fake = A.Fake<IThingy>();
            fake.DoSomething();

            mock = new Mock<IThingy>();
            mock.Object.DoSomething();

            pclMock = new ThingyMock();
            pclMock.DoSomething();

            sub = Substitute.For<IThingy>();
            sub.DoSomething();

            rock = Rock.Create<IThingy>();
            rock.Handle(r => r.DoSomething());
            rock.Make().DoSomething();
        }

        [Benchmark(Baseline = true)]
        public void Stub()
        {
            if (!stub.Called) throw new Exception();
        }

        [Benchmark]
        public void FakeItEasy() => A.CallTo(() => fake.DoSomething()).MustHaveHappened();

        [Benchmark]
        public void Moq() => mock.Verify(m => m.DoSomething(), Times.AtLeastOnce);

        [Benchmark]
        public void NSubstitute() => sub.Received().DoSomething();

        [Benchmark]
        public void PCLMock() => pclMock.Verify(x => x.DoSomething()).WasCalledExactlyOnce();

        [Benchmark]
        public void Rocks() => rock.Verify();
    }
}