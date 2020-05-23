using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet.Benchmarks
{
    public class EmptyMethod : MockingBenchmark
    {
        [Benchmark(Baseline = true)]
        public override void Stub()
        {
            var stub = new ThingStub();
            stub.DoNothing();
        }

        [Benchmark]
        public override void FakeItEasy()
        {
            var fake = A.Fake<IThingy>();
            fake.DoNothing();
        }

        [Benchmark]
        public override void Moq()
        {
            var mock = new Mock<IThingy>();
            mock.Object.DoNothing();
        }

        [Benchmark]
        public override void NSubstitute()
        {
            var sub = Substitute.For<IThingy>();
            sub.DoNothing();
        }

        [Benchmark]
        public override void Rocks()
        {
            var chunk = Rock.Make<IThingy>();
            chunk.DoNothing();
        }

        [Benchmark]
        public override void PCLMock()
        {
            var mock = new ThingyMock();
            mock.When(x => x.DoNothing());
            mock.DoNothing();
        }
    }
}