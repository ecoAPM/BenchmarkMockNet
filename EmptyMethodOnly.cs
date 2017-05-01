using System;
using BenchmarkDotNet.Attributes;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet
{
    public class EmptyMethodOnly : IMockingBenchmark
    {
        private readonly IThingy stub;
        private readonly Mock<IThingy> mock;
        private readonly IThingy sub;
        private readonly IRock<IThingy> rock;

        public EmptyMethodOnly()
        {
            stub = new ThingStub();
            mock = new Mock<IThingy>();
            sub = Substitute.For<IThingy>();
            rock = Rock.Create<IThingy>();
            rock.Handle(r => r.DoNothing());
        }

        [Benchmark(Baseline = true)]
        public void Stub() => stub.DoNothing();

        [Benchmark]
        public void Moq() => mock.Object.DoNothing();

        [Benchmark]
        public void NSubstitute() => sub.DoNothing();

        public void FakeItEasy() => throw new NotImplementedException("Never completes, probably a memory leak");

        [Benchmark]
        public void Rocks() => rock.Make().DoNothing();
    }
}