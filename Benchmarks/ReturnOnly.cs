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
        private readonly IThingy pclMock;
        private readonly IThingy sub;
        private readonly IThingy fake;
        private readonly IThingy chunk;

        public ReturnOnly()
        {
            stub = new ThingStub();

            fake = A.Fake<IThingy>();
            A.CallTo(() => fake.One()).Returns(1);

            var mockSetup = new Mock<IThingy>();
            mockSetup.Setup(m => m.One()).Returns(1);
            mock = mockSetup.Object;

            var pclMock = new ThingyMock();
            pclMock.When(x => x.One()).Return(1);
            this.pclMock = pclMock;

            sub = Substitute.For<IThingy>();
            sub.One().Returns(1);

            var rock = Rock.Create<IThingy>();
            rock.Handle(r => r.One()).Returns(1);
            chunk = rock.Make();
        }

        [Benchmark(Baseline = true)]
        public int Stub() => stub.One();

        //[Benchmark]
        public int FakeItEasy() => fake.One();

        [Benchmark]
        public int Moq() => mock.One();

        [Benchmark]
        public int NSubstitute() => sub.One();

        [Benchmark]
        public int PCLMock() => pclMock.One();

        [Benchmark]
        public int Rocks() => chunk.One();
    }
}