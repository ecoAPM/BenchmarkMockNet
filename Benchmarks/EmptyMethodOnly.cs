using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet.Benchmarks
{
    public class EmptyMethodOnly : IMockingBenchmark
    {
        private readonly IThingy stub;
        private readonly IThingy mock;
        private readonly IThingy sub;
        private readonly IThingy fake;
        private readonly IThingy chunk;

        public EmptyMethodOnly()
        {
            stub = new ThingStub();
            mock = new Mock<IThingy>().Object;
            sub = Substitute.For<IThingy>();
            fake = new Fake<IThingy>().FakedObject;
            chunk = Rock.Make<IThingy>();
        }

        [Benchmark(Baseline = true)]
        public void Stub() => stub.DoNothing();

        [Benchmark]
        public void Moq() => mock.DoNothing();

        [Benchmark]
        public void NSubstitute() => sub.DoNothing();

        //[Benchmark]
        public void FakeItEasy() => fake.DoNothing();

        [Benchmark]
        public void Rocks() => chunk.DoNothing();
    }
}