using BenchmarkDotNet.Attributes;
using BenchmarkMockNet.PCLMock;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet.Benchmarks
{
    public class ReturnOnly : MockingBenchmark<int>
    {
        private readonly IThingy stub;
        private readonly IThingy mock;
        private readonly IThingy sub;
        private readonly IThingy fake;
        private readonly IThingy chunk;
        private readonly ThingyMock pclMock;

        public ReturnOnly()
        {
            stub = new ThingStub();

            fake = A.Fake<IThingy>();
            A.CallTo(() => fake.One()).Returns(1);

            var mockSetup = new Mock<IThingy>();
            mockSetup.Setup(m => m.One()).Returns(1);
            mock = mockSetup.Object;

            sub = Substitute.For<IThingy>();
            sub.One().Returns(1);

            var rock = Rock.Create<IThingy>();
            rock.Methods().One().Returns(1);
            chunk = rock.Instance();

            var pclMock = new ThingyMock();
            pclMock.When(x => x.One()).Return(1);
            this.pclMock = pclMock;
        }

        [Benchmark(Baseline = true)]
        public override int Stub() => stub.One();

        [Benchmark]
        public override int FakeItEasy() => fake.One();

        [Benchmark]
        public override int Moq() => mock.One();

        [Benchmark]
        public override int NSubstitute() => sub.One();

        [Benchmark]
        public override int Rocks() => chunk.One();

        [Benchmark]
        public override int PCLMock() => pclMock.One();
    }
}