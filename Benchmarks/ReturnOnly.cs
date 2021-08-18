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
        private readonly IThingy _stub;
        private readonly IThingy _fake;
        private readonly IThingy _mock;
        private readonly IThingy _sub;
        private readonly ThingyMock _pcl;
        private readonly IThingy _rock;

        public ReturnOnly()
        {
            _stub = new ThingStub();

            _fake = A.Fake<IThingy>();
            A.CallTo(() => _fake.One()).Returns(1);

            var mockSetup = new Mock<IThingy>();
            mockSetup.Setup(m => m.One()).Returns(1);
            _mock = mockSetup.Object;

            _sub = Substitute.For<IThingy>();
            _sub.One().Returns(1);

            var pclMock = new ThingyMock();
            pclMock.When(x => x.One()).Return(1);
            _pcl = pclMock;

            var rock = Rock.Create<IThingy>();
            rock.Methods().One().Returns(1);
            _rock = rock.Instance();
        }

        [Benchmark(Baseline = true)]
        public override int Stub() => _stub.One();

        [Benchmark]
        public override int FakeItEasy() => _fake.One();

        [Benchmark]
        public override int Moq() => _mock.One();

        [Benchmark]
        public override int NSubstitute() => _sub.One();

        [Benchmark]
        public override int PCLMock() => _pcl.One();

        [Benchmark]
        public override int Rocks() => _rock.One();
    }
}