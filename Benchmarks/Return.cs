using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;
using Rocks;

namespace BenchmarkMockNet.Benchmarks
{
    public class Return : IMockingBenchmark<int>
    {
        [Benchmark(Baseline = true)]
        public int Stub()
        {
            var stub = new ThingStub();
            return stub.One();
        }

        [Benchmark]
        public int FakeItEasy()
        {
            var fake = A.Fake<IThingy>();
            A.CallTo(() => fake.One()).Returns(1);
            return fake.One();
        }

        [Benchmark]
        public int Moq()
        {
            var mock = new Mock<IThingy>();
            mock.Setup(m => m.One()).Returns(1);
            return mock.Object.One();
        }

        [Benchmark]
        public int NSubstitute()
        {
            var sub = Substitute.For<IThingy>();
            sub.One().Returns(1);
            return sub.One();
        }

        [Benchmark]
        public int PCLMock()
        {
            var mock = new ThingyMock();
            mock.When(x => x.One()).Return(1);
            return mock.One();
        }

        [Benchmark]
        public int Rocks()
        {
            var rock = Rock.Create<IThingy>();
            rock.Handle(r => r.One()).Returns(1);
            return rock.Make().One();
        }
    }
}