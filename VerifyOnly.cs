using System;
using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet
{
    public class VerifyOnly : IMockingBenchmark
    {
        private readonly IThingy stub;
        private readonly Mock<IThingy> mock;
        private readonly IThingy sub;
        private readonly IThingy fake;
        private readonly IRock<IThingy> rock;

        public VerifyOnly()
        {
            stub = new ThingStub();
            stub.DoSomething();

            mock = new Mock<IThingy>();
            mock.Object.DoSomething();

            sub = Substitute.For<IThingy>();
            sub.DoSomething();

            fake = A.Fake<IThingy>();
            fake.DoSomething();

            rock = Rock.Create<IThingy>();
            rock.Handle(_ => _.DoSomething());
            rock.Make().DoSomething();
        }

        [Benchmark(Baseline = true)]
        public void Stub()
        {
            if (!stub.Called) throw new Exception();
        }

        [Benchmark]
        public void Moq()
        {
            mock.Verify(m => m.DoSomething(), Times.AtLeastOnce);
        }

        [Benchmark]
        public void NSubstitute()
        {
            sub.Received().DoSomething();
        }

        [Benchmark]
        public void FakeItEasy()
        {
            A.CallTo(() => fake.DoSomething()).MustHaveHappened();
        }

        [Benchmark]
        public void Rocks()
        {
            rock.Verify();
        }
    }
}