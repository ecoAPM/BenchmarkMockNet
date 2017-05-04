using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet.Benchmarks
{
    public class ReturnOnly : IMockingBenchmark<int>
    {
        private readonly IThingy stub;
        private readonly IThingy mock;
        private readonly IThingy sub;
        private readonly IThingy fake;
        private readonly IThingy chunk;

        public ReturnOnly()
        {
            stub = new ThingStub();

            var mockSetup = new Mock<IThingy>();
            mockSetup.Setup(m => m.One()).Returns(1);
            mock = mockSetup.Object;

            sub = Substitute.For<IThingy>();
            sub.One().Returns(1);

            var fakey = new Fake<IThingy>();
            fakey.CallsTo(f => f.One()).Returns(1);
            fake = fakey.FakedObject;

            var rock = Rock.Create<IThingy>();
            rock.Handle(r => r.One()).Returns(1);
            chunk = rock.Make();
        }

        [Benchmark(Baseline = true)]
        public int Stub() => stub.One();

        [Benchmark]
        public int Moq() => mock.One();

        [Benchmark]
        public int NSubstitute() => sub.One();

        //[Benchmark]
        public int FakeItEasy() => fake.One();

        [Benchmark]
        public int Rocks() => chunk.One();
    }
}