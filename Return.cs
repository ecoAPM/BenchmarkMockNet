using BenchmarkDotNet.Attributes;
using FakeItEasy;
using Moq;
using NSubstitute;

namespace BenchmarkMockNet
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
        public int FakeItEasy()
        {
            var fake = A.Fake<IThingy>();
            A.CallTo(() => fake.One()).Returns(1);
            return fake.One();
        }
    }
}