using System;
using BenchmarkDotNet.Attributes;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet
{
    public class EmptyReturnOnly : IMockingBenchmark<int>
    {
        private readonly IThingy stub;
        private readonly Mock<IThingy> mock;
        private readonly IThingy sub;
        private readonly IRock<IThingy> rock;

        public EmptyReturnOnly()
        {
            stub = new ThingStub();
            mock = new Mock<IThingy>();
            sub = Substitute.For<IThingy>();
            rock = Rock.Create<IThingy>();
            rock.Handle(_ => _.Zero());
        }

        [Benchmark(Baseline = true)]
        public int Stub() => stub.Zero();

        [Benchmark]
        public int Moq() => mock.Object.Zero();

        [Benchmark]
        public int NSubstitute() => sub.Zero();

        public int FakeItEasy() => throw new NotImplementedException("Never completes, probably a memory leak");

        [Benchmark]
        public int Rocks() => rock.Make().Zero();
    }
}